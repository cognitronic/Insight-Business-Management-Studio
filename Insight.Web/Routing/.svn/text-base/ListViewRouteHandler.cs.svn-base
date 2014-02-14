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
using Insight.Core.Domain;

namespace Insight.Web.Routing
{
    public class ListViewRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public ListViewRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;
            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Title;
            item.ItemReference = item;
            item.URL = "/ListViews";
            HttpPageHelper.CurrentItem = item;

            InsightBasePage page;
            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;
            return page;
        }
        #endregion
    }
}
