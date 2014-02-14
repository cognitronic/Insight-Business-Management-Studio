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
using Insight.Persistence.Repositories;
using Insight.Web.Utils;
using Insight.Services;

namespace Insight.Web.Routing
{
    public class SalesRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public SalesRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.CurrentItem = null;
            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Title;
            item.ItemReference = item;
            HttpPageHelper.CurrentItem = item;

            InsightBasePage page;

            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }
    }
}
