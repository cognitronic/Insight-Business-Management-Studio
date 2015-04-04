﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.IO;

namespace Insight.Core.Utils
{
    public class JSONSerializationHelper
    {
        public static string Serialize<T>(T obj)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static T Deserialize<T>(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                T obj = Activator.CreateInstance<T>();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
                ms.Dispose();
                
                return obj;
            }
            return default(T);
        }

    }
}
