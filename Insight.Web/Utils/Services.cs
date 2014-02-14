using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Data;
using Telerik.Web.UI;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;
using IdeaSeed.Core.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections;

namespace Insight.Web.Utils
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Services
    {
        // Add [WebGet] attribute to use HTTP GET
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        [OperationContract]
        public RadComboBoxItemData[] GetProductsByName(RadComboBoxContext context)
        {
            List<RadComboBoxItemData> suggestions = new List<RadComboBoxItemData>(context.NumberOfItems);
            if (context != null && !string.IsNullOrEmpty(context.Text))
            {
                var products = new ProductRepository().GetByProductName(context.Text);
                RadComboBoxData data = new RadComboBoxData();
                try
                {
                    int itemsPerRequest = 10;
                    int itemOffset = context.NumberOfItems;
                    int endOffset = itemOffset + itemsPerRequest;
                    if (endOffset > products.Count)
                    {
                        endOffset = products.Count;
                    }
                    if (endOffset == products.Count)
                    {
                        data.EndOfItems = true;
                    }
                    else
                    {
                        data.EndOfItems = false;
                    }
                    suggestions = new List<RadComboBoxItemData>(endOffset - itemOffset);
                    for (int i = itemOffset; i < endOffset; i++)
                    {
                        RadComboBoxItemData itemData = new RadComboBoxItemData();
                        itemData.Text = products[i].PartNumber;
                        itemData.Value = products[i].ID.ToString();

                        suggestions.Add(itemData);
                    }

                    if (products.Count > 0)
                    {
                        data.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), products.Count.ToString());
                    }
                    else
                    {
                        data.Message = "No matches";
                    }
                }
                catch (Exception e)
                {
                    data.Message = e.Message;
                }

                data.Items = suggestions.ToArray();
                return data.Items;
            }
            return suggestions.ToArray();
        }

        [OperationContract]
        public RadComboBoxItemData[] GetProductsByModel(RadComboBoxContext context)
        {
            List<RadComboBoxItemData> suggestions = new List<RadComboBoxItemData>(context.NumberOfItems);
            if (context != null && !string.IsNullOrEmpty(context.Text))
            {
                var products = new ProductRepository().GetByModel(context.Text);

                RadComboBoxData data = new RadComboBoxData();
                try
                {
                    int itemsPerRequest = 10;
                    int itemOffset = context.NumberOfItems;
                    int endOffset = itemOffset + itemsPerRequest;
                    if (endOffset > products.Count)
                    {
                        endOffset = products.Count;
                    }
                    if (endOffset == products.Count)
                    {
                        data.EndOfItems = true;
                    }
                    else
                    {
                        data.EndOfItems = false;
                    }
                    suggestions = new List<RadComboBoxItemData>(endOffset - itemOffset);
                    for (int i = itemOffset; i < endOffset; i++)
                    {
                        RadComboBoxItemData itemData = new RadComboBoxItemData();
                        itemData.Text = products[i].PartNumber;
                        itemData.Value = products[i].ID.ToString();

                        suggestions.Add(itemData);
                    }

                    if (products.Count > 0)
                    {
                        data.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), products.Count.ToString());
                    }
                    else
                    {
                        data.Message = "No matches";
                    }
                }
                catch (Exception e)
                {
                    data.Message = e.Message;
                }

                data.Items = suggestions.ToArray();
                return data.Items;
            }
            return suggestions.ToArray();
        }

        [OperationContract]
        public RadComboBoxItemData[] GetProductsBySKU(RadComboBoxContext context)
        {
            //if (context != null && !string.IsNullOrEmpty(context.Text))
            //{
            //    DataSet ds = Utilities.ExecuteStoredProc(ConfigurationManager.AppSettings["DBNAME"], "selectProductsBySKUForAutoComplete", "sku", context.Text);

            //    List<RadComboBoxItemData> suggestions = new List<RadComboBoxItemData>(context.NumberOfItems);
            //    RadComboBoxData data = new RadComboBoxData();
            //    try
            //    {
            //        int itemsPerRequest = 10;
            //        int itemOffset = context.NumberOfItems;
            //        int endOffset = itemOffset + itemsPerRequest;
            //        if (endOffset > ds.Tables[0].Rows.Count)
            //        {
            //            endOffset = ds.Tables[0].Rows.Count;
            //        }
            //        if (endOffset == ds.Tables[0].Rows.Count)
            //        {
            //            data.EndOfItems = true;
            //        }
            //        else
            //        {
            //            data.EndOfItems = false;
            //        }
            //        suggestions = new List<RadComboBoxItemData>(endOffset - itemOffset);
            //        for (int i = itemOffset; i < endOffset; i++)
            //        {
            //            RadComboBoxItemData itemData = new RadComboBoxItemData();
            //            itemData.Text = ds.Tables[0].Rows[i]["product"].ToString();
            //            itemData.Value = ds.Tables[0].Rows[i]["productid"].ToString();

            //            suggestions.Add(itemData);
            //        }

            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            data.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), ds.Tables[0].Rows.Count.ToString());
            //        }
            //        else
            //        {
            //            data.Message = "No matches";
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        data.Message = e.Message;
            //    }

            //    data.Items = suggestions.ToArray();
            //    return data;
            //}
            return null;
        }

        [OperationContract]
        public RadComboBoxItemData[] GetProductsByDescription(RadComboBoxContext context)
        {
            List<RadComboBoxItemData> suggestions = new List<RadComboBoxItemData>(context.NumberOfItems);
            if (context != null && !string.IsNullOrEmpty(context.Text))
            {
                var products = new ProductRepository().GetByDescription(context.Text);
                RadComboBoxData data = new RadComboBoxData();
                try
                {
                    int itemsPerRequest = 10;
                    int itemOffset = context.NumberOfItems;
                    int endOffset = itemOffset + itemsPerRequest;
                    if (endOffset > products.Count)
                    {
                        endOffset = products.Count;
                    }
                    if (endOffset == products.Count)
                    {
                        data.EndOfItems = true;
                    }
                    else
                    {
                        data.EndOfItems = false;
                    }
                    suggestions = new List<RadComboBoxItemData>(endOffset - itemOffset);
                    for (int i = itemOffset; i < endOffset; i++)
                    {
                        RadComboBoxItemData itemData = new RadComboBoxItemData();
                        itemData.Text = products[i].PartNumber;
                        itemData.Value = products[i].ID.ToString();

                        suggestions.Add(itemData);
                    }

                    if (products.Count > 0)
                    {
                        data.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), products.Count.ToString());
                    }
                    else
                    {
                        data.Message = "No matches";
                    }
                }
                catch (Exception e)
                {
                    data.Message = e.Message;
                }

                data.Items = suggestions.ToArray();
                return data.Items;
            }
            return suggestions.ToArray();
        }

        [OperationContract]
        public RadComboBoxData GetProductsByProductID(RadComboBoxContext context)
        {
            //if (context != null && !string.IsNullOrEmpty(context.Text))
            //{
            //    DataSet ds = Utilities.ExecuteStoredProc(ConfigurationManager.AppSettings["DBNAME"], "selectProductsByNameForAutoComplete", "product", context.Text);

            //    List<RadComboBoxItemData> suggestions = new List<RadComboBoxItemData>(context.NumberOfItems);
            //    RadComboBoxData data = new RadComboBoxData();
            //    try
            //    {
            //        int itemsPerRequest = 10;
            //        int itemOffset = context.NumberOfItems;
            //        int endOffset = itemOffset + itemsPerRequest;
            //        if (endOffset > ds.Tables[0].Rows.Count)
            //        {
            //            endOffset = ds.Tables[0].Rows.Count;
            //        }
            //        if (endOffset == ds.Tables[0].Rows.Count)
            //        {
            //            data.EndOfItems = true;
            //        }
            //        else
            //        {
            //            data.EndOfItems = false;
            //        }
            //        suggestions = new List<RadComboBoxItemData>(endOffset - itemOffset);
            //        for (int i = itemOffset; i < endOffset; i++)
            //        {
            //            RadComboBoxItemData itemData = new RadComboBoxItemData();
            //            itemData.Text = ds.Tables[0].Rows[i]["product"].ToString();
            //            itemData.Value = ds.Tables[0].Rows[i]["productid"].ToString();

            //            suggestions.Add(itemData);
            //        }

            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            data.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), ds.Tables[0].Rows.Count.ToString());
            //        }
            //        else
            //        {
            //            data.Message = "No matches";
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        data.Message = e.Message;
            //    }

            //    data.Items = suggestions.ToArray();
            //    return data;
            //}
            return null;
        }
    }
}
