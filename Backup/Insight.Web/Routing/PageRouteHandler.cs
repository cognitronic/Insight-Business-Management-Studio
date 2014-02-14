using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
using Insight.Web.Bases;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace Insight.Web.Routing
{
    public class PageRouteHandler : IRouteHandler
    {
        private Insight.Core.Domain.Page pageService = new Insight.Core.Domain.Page();

        public string VirtualPath { get; set; }
        public string Domain { get; set; }

        public PageRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        public PageRouteHandler(string virtualPath, string domain)
        {
            this.VirtualPath = virtualPath;
            this.Domain = domain;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            ////IF ROUTE HANDLER IS INSTANTIATED THEN IS VALID REQUEST.
            //HttpPageHelper.IsValidRequest = true;

            //CmsApplicationsService appService = new CmsApplicationsService();

            ////CAST REQUEST CONTEXT TO CONTEXT WRAPPER TO GRAB QUERY STRING INFO
            //HttpContextWrapper context = (HttpContextWrapper)requestContext.HttpContext;

            ////SET DOMAIN FROM QUERY STRING IF IN DEBUG MODE
            ////if (!bool.Parse(ConfigurationManager.AppSettings["DEBUG_MODE"]))
            ////{
            ////    Domain = context.Request.Url.GetLeftPart(UriPartial.Authority).ToLower().Replace("http://", "");
            ////}

            //CmsApplications app = DataRepository.CmsApplicationsProvider.GetByDomain(Domain);

            ////GET REQUESTED PAGE INFORMATION
            //string pageName = HttpUtility.HtmlDecode((string)requestContext.RouteData.DataTokens["PageName"]);
            //string parentName = HttpUtility.HtmlDecode((string)requestContext.RouteData.DataTokens["ParentName"]);
            //string parentID = HttpUtility.HtmlDecode((string)requestContext.RouteData.DataTokens["ParentID"]);
            //HttpPageHelper.RequestedApp = app;

            //CmsPages currentpage = new CmsPages();

            //if (string.IsNullOrEmpty(parentName))
            //{
            //    if (pageName != null)
            //    {
            //        //Find parent page
            //        currentpage = new CmsPagesService().GetByNameParentNameApplication(pageName.Replace("-", " "), null, app.Applicationid)[0];
            //    }
            //    else
            //    {
            //        //Find parent page
            //        currentpage = new CmsPagesService().GetByNameParentNameApplication("Home", null, app.Applicationid)[0];
            //    }
            //}
            //else
            //{
            //    //Find page by parent
            //    int? pid = Convert.ToInt32(parentID);
            //    var pages = DataRepository.CmsPagesProvider.GetByPagenameParentidApplicationid(pageName, pid, app.Applicationid);
            //    //IF PAGE IS INACTIVE THEN GET MAINTENANCE PAGE
            //    if (!pages.Isactive)
            //    {
            //        currentpage = GetMaintenancePage(app);
            //    }
            //    else
            //    {
            //        currentpage = pages;
            //    }
            //}

            //DPBasePage page;
            ////Start page lifecycle 
            //if (currentpage != null)
            //{
            //    page = (DPBasePage)BuildManager.CreateInstanceFromVirtualPath(currentpage.Routeurl, typeof(Page));
            //}
            //else
            //{
            //    page = (DPBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(Page));
            //}

            //if (currentpage != null)
            //{
            //    page.CurrentPage = currentpage;
            //    HttpPageHelper.RequestedPage = currentpage;
            //    HttpPageHelper.ShowPanel = currentpage.Showpanelheader;
            //    HttpPageHelper.ShowNewsLetter = currentpage.Shownewsletter;
            //    HttpPageHelper.ShowBannerImages = currentpage.Showbannerimages;
            //    HttpPageHelper.PanelHeaderText = currentpage.Pagetitle;
            //}
            InsightBasePage page = new InsightBasePage();
            return page;
        }

        //private CmsPages GetMaintenancePage(CmsApplications app)
        //{
        //    return pageService.GetByPagenameParentidApplicationid(ConfigurationManager.AppSettings["MAINTENANCEURL"], null, app.Applicationid);
        //}
        #endregion
    }
}
