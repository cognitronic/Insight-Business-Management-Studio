using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
using Insight.Core.Domain;
using Insight.Web.Security;
using System.Configuration;
using System.Web.UI.HtmlControls;
using Insight.Web.Bases;
using Insight.Web.Utils;
using Insight.Core.Security;
using Insight.Services;
using Insight.Core.Domain.Interfaces;

namespace Insight.Web.Routing
{
    public class UserRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public UserRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            string userID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["userID"]);
            string username = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["username"]);
            string isNew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);

            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;
            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            if (!string.IsNullOrEmpty(userID))
            {
                var u = new UserServices().GetByID(Convert.ToInt32(userID));
                var item = new Item();
                item.URL = "/Admin/Users/ID=" + u.ID.ToString();
                item.Name = "Users - " + u.FirstName + " " + u.LastName + " (" + u.UserName + ")";
                item.ItemReference = u;
                HttpPageHelper.CurrentItem = item;
            }
            else if (!string.IsNullOrEmpty(username))
            {
                var u = new UserServices().GetByUserName(username);
                var item = new Item();
                item.URL = "/Admin/Users/Username=" + u.ID.ToString();
                item.Name = "Users - " + u.FirstName + " " + u.LastName + " (" + u.UserName + ")";
                item.ItemReference = u;
                HttpPageHelper.CurrentItem = item;
            }
            else if (!string.IsNullOrEmpty(isNew))
            {
                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Title;
                item.ItemReference = item;
                item.URL = "/Admin/Users/New";
                HttpPageHelper.CurrentItem = item;
            }
            else
            {
                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Title;
                item.ItemReference = item;
                item.URL = "/Admin";
                HttpPageHelper.CurrentItem = item;
            }
            InsightBasePage page;
            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_DefaultVirtualPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;
            return page;
        }
        #endregion
    }
}
