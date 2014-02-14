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
using Insight.Core.Domain;
using System.Collections.Generic;
using System.Web.Routing;

namespace Insight.Web.Routing
{
    public class RouteBuilder
    {
        public RouteCollection Routes { get; private set; }
        public RouteBuilder(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Run()
        {

            Route defaultRoute = new Route("Home", new DefaultRouteHandler("~/Default.aspx"));
            Routes.Add(defaultRoute);

            BuildUtilityRoutes();
            BuildListViewRoutes();
            BuildAdminDashboardRoutes();
        }

        public void BuildUtilityRoutes()
        {
            Route loginRoute = new Route("Login", new UtilityRouteHandler("~/UtilityPages/Login.aspx"));
            Routes.Add(loginRoute);
            
        }

        public void BuildListViewRoutes()
        {
            Route listViewRoute = new Route("ListViews/ID={viewID}", new ListViewRouteHandler("~/UtilityPages/FilterViews.aspx"));
            listViewRoute.Constraints = new RouteValueDictionary { { "viewID", @"^\d+" } };
            Routes.Add(listViewRoute);

            Route listViewNewRoute = new Route("ListViews/{new}", new ListViewRouteHandler("~/UtilityPages/FilterViews.aspx"));
            listViewNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(listViewNewRoute);
        }

        public void BuildUserRoutes()
        {
            Route userByIDRoute = new Route("Admin/Users/ID={userID}", new UserRouteHandler("~/Admin/Users/Properties.aspx"));
            userByIDRoute.Constraints = new RouteValueDictionary { { "userID", @"^\d+" } };
            Routes.Add(userByIDRoute);

            Route userByUsernameRoute = new Route("Admin/Users/Username={username}", new UserRouteHandler("~/Admin/Users/Properties.aspx"));
            userByUsernameRoute.Constraints = new RouteValueDictionary { { "username", @"^\D+" } };
            Routes.Add(userByUsernameRoute);

            Route newUserRoute = new Route("Admin/Users/{new}", new UserRouteHandler("~/Admin/Users/Properties.aspx"));
            newUserRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(newUserRoute);

            Route userListRoute = new Route("Admin/Users", new UserRouteHandler("~/Admin/Users/List.aspx"));
            Routes.Add(userListRoute);
        }

        public void BuildAdminDashboardRoutes()
        {
            BuildUserRoutes();

            Route userListRoute = new Route("Admin/Dashboard", new AdminRouteHandler("~/Admin/Dashboard.aspx"));
            Routes.Add(userListRoute);
        }
    }
}
