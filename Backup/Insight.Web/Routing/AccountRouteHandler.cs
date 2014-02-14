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
    public class AccountRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public AccountRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;

            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            string accountName = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountname"]);
            string accountID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountid"]);
            string isNew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);
            if (!string.IsNullOrEmpty(accountID))
            {
                var account = new AccountRepository().GetByID(Convert.ToInt16(accountID), false);
                account.Description = account.EmailDomain;
                var item = new Item();
                item.Description = account.EmailDomain;
                item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                account.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                item.Name = account.Name + " - " + p.Title;
                item.ItemReference = account;
                HttpPageHelper.CurrentItem = item;
            }
            else if (!string.IsNullOrEmpty(accountName))
            {
                var a = new AccountRepository().GetByName(accountName.Replace("-", " "));
                a.Description = a.EmailDomain;
                var item = new Item();
                item.Description = a.EmailDomain;
                item.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                a.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                item.Name = a.Name + " - " + p.Title;
                item.ItemReference = a;
                HttpPageHelper.CurrentItem = item;
            }
            else if (!string.IsNullOrEmpty(isNew))
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/Accounts/New";
                item.Name = p.Title;
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
            }
            else
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/Accounts";
                item.Name = p.Title;
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
            }

            

            InsightBasePage page;

            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }
    }
}
