using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Insight.Web.Bases;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using IdeaSeed.Core.Web;
using Insight.Core.Domain;
using Insight.Core.Interfaces;
using Insight.Persistence.Repositories;
using Insight.Web.Utils;
using Insight.Core.Security;
using Insight.Core.Utils;
using Insight.Services;

namespace Insight.Web.Routing
{
    public class AccountAddressRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public AccountAddressRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;

            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            string accountName = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountName"]);
            string isnew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);
            string accountID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountID"]);
            string addressID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["addressID"]);
            //if (!string.IsNullOrEmpty(accountID))
            //{
            //    var account = new AccountRepository().GetByID(Convert.ToInt16(accountID), false);
            //    account.Description = account.EmailDomain;
            //    var item = new Item();
            //    item.Description = account.EmailDomain;
            //    item.ItemReference = account;
            //    HttpPageHelper.CurrentItem = item;
            //}
            //if (!string.IsNullOrEmpty(accountName))
            //{
            //    var a = new AccountRepository().GetByName(accountName.Replace("-", " "));
            //    a.Description = a.EmailDomain;
            //    var item = new Item();
            //    item.Description = a.EmailDomain;
            //    item.ItemReference = a;
            //    HttpPageHelper.CurrentItem = item;
            //}

            if (string.IsNullOrEmpty(isnew))
            {
                if (!string.IsNullOrEmpty(addressID)) //We're looking at an address properties
                {
                    if (!string.IsNullOrEmpty(accountID) || !string.IsNullOrEmpty(accountName))
                    {
                        var address = new AccountServices().GetAddressByAddressID(Convert.ToInt32(addressID));
                        var item = new Item();
                        item.Description = address.Description;
                        item.Name = accountName + " " + address.Title + " " + p.Title;
                        address.Name = accountName;
                        item.ItemReference = address;
                        HttpPageHelper.CurrentItem = item;
                    }
                }
                else //this is the address list page
                {
                    if (!string.IsNullOrEmpty(accountName))
                    {
                        var account = new AccountServices().GetByAccountName(accountName.Replace("-", " "));
                        var item = new Item();
                        item.Name = account.Name + " Address List";
                        item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                        account.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                        item.ItemReference = account;
                        HttpPageHelper.CurrentItem = item;
                    }
                }
            }
            else
            {
                var address = new AccountAddress();
                if (!string.IsNullOrEmpty(accountName))
                {
                    var account = new AccountServices().GetByAccountName(accountName.Replace("-", " "));
                    var item = new Item();
                    item.Description = account.ID.ToString();
                    item.Name = account.Name + " " + address.Title + " " + p.Title;
                    //address.Name = account.Name;
                    //address.AccountID = account.ID;
                    item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                    item.ItemReference = item;
                    HttpPageHelper.CurrentItem = item;
                }
                else if (!string.IsNullOrEmpty(accountID))
                {
                    var account = new AccountRepository().GetByID(Convert.ToInt16(accountID), false);
                    var item = new Item();
                    item.Description = "New Address";
                    item.Name = account.Name + " " + address.Title + " " + p.Title;
                    address.Name = account.Name;
                    item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                    address.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                    address.AccountID = account.ID;
                    item.ItemReference = address;
                    HttpPageHelper.CurrentItem = item;
                }
            }

            



            InsightBasePage page;

            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
