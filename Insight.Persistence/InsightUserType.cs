using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using NHibernate.UserTypes;

using System.Data;

using NHibernate.SqlTypes;

using System.Drawing;

using NHibernate;

using System.IO;

using System.Drawing.Imaging;

namespace Insight.Persistence
{
    public class InsightUserType : IUserType
    {
        #region IUserType Members

        public object Assemble(object cached, object owner)
        {
            return (cached);
        }

        public object DeepCopy(object value)
        {
            if (value == null)
            {

                return (null);

            }

            else
            {

                return ((value as ICloneable).Clone());

            }
        }

        public object Disassemble(object value)
        {
            return (value);
        }

        public int GetHashCode(object x)
        {
            return (x != null ? x.GetHashCode() : 0);
        }

        public bool IsMutable
        {
            get
            {

                return (false);

            }
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            Byte[] data = NHibernateUtil.Binary.NullSafeGet(rs, names[0]) as Byte[];

            if (data != null)
            {

                using (Stream stream = new MemoryStream(data))
                {

                    Image image = Image.FromStream(stream);

                    return (image);

                }

            }

            else
            {

                return (null);

            }
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {

                NHibernateUtil.Binary.NullSafeSet(cmd, null, index);

            }

            else
            {

                using (MemoryStream stream = new MemoryStream())
                {

                    Image image = value as Image;

                    image.Save(stream, ImageFormat.Png);

                    NHibernateUtil.String.NullSafeSet(cmd, stream.GetBuffer(), index);

                }

            }
        }

        public object Replace(object original, object target, object owner)
        {
            return (original);
        }

        public Type ReturnedType
        {
            get
            {

                return (typeof(Image));

            }
        }

        public SqlType[] SqlTypes
        {
            get
            {

                return (new SqlType[] { new SqlType(DbType.Binary) });

            }
        }

        Boolean IUserType.Equals(Object o1, Object o2)
        {

            return (Object.Equals(o1, o2));

        }

        #endregion
    }
}
