using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Routing;

namespace Insight.Web.Routing
{
    public class ApplicationRoute
    {
        public ApplicationRoute() { }
        public ApplicationRoute(int applicationid, string domain, string routeUrl, string name, string seoPath, int pageID, RouteValueDictionary routeValueDictionary)
        {
            ApplicationID = applicationid;
            Domain = domain;
            RouteURL = routeUrl;
            Name = name;
            SEOPath = seoPath;
            PageID = pageID;
            RouteValueDictionary = routeValueDictionary;
        }
        public int ApplicationID { get; set; }
        public string Domain { get; set; }
        public string RouteURL { get; set; }
        public string Name { get; set; }
        public string SEOPath { get; set; }
        public int PageID { get; set; }
        public RouteValueDictionary RouteValueDictionary { get; set; }
    }
}
