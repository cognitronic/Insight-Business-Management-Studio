using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
using Insight.Core.Domain;
using Insight.Web.Security;
using Insight.Persistence.Repositories;
using System.Configuration;
using System.Web.UI.HtmlControls;
using Insight.Web.Bases;
using Insight.Web.Utils;
using Insight.Core.Security;
using Insight.Services;


namespace Insight.Web.Routing
{
    public class UtilityRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public UtilityRouteHandler(string virtualPath)
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
