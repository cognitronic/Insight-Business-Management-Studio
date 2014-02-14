using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
using Insight.Core.Domain;
using System.Configuration;
using System.Web.UI.HtmlControls;
using Insight.Web.Bases;
using Insight.Web.Utils;

namespace Insight.Web.Routing
{
    public class ErrorRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public ErrorRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            var page = new System.Web.UI.Page();
            page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));


            HttpPageHelper.IsValidRequest = true;

            return page;
        }
        #endregion
    }
}
