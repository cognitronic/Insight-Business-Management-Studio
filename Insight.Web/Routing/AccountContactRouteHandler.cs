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
    public class AccountContactRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public AccountContactRouteHandler(string virtualPath)
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
            string contactID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["contactID"]);
            if (!string.IsNullOrEmpty(contactID))
            {
                var contact = new AccountServices().GetContactByID(Convert.ToInt32(contactID));
                if (contact != null && contact.ID > 0)
                {
                    
                    var item = new Item();
                    item.Description = "";
                    contact.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString();
                    item.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString();
                    item.Name = contact.FirstName + " " + contact.LastName + " - " + contact.ContactAccount.Name + " Contact";
                    contact.Name = item.Name;
                    item.ItemReference = contact;
                    HttpPageHelper.CurrentItem = item;
                }
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
            else if (!string.IsNullOrEmpty(accountID))
            {
                var a = new AccountRepository().GetByID(Convert.ToInt32(accountID), false);
                a.Description = a.EmailDomain;
                var item = new Item();
                item.Description = a.EmailDomain;
                item.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                a.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                item.Name = a.Name + " - " + p.Title;
                item.ItemReference = a;
                HttpPageHelper.CurrentItem = item;
            }
            else
            {
                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Title;
                item.URL = "/Accounts";
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