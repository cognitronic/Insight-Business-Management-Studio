using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Web.Routing;
using System.Web.Routing;

namespace Insight.Website
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new Insight.Web.Utils.AssemblyResourceProvider());
            RouteBuilder builder = new RouteBuilder(RouteTable.Routes);
            builder.Run();

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items[ResourceStrings.Session_ApplicationContext] = new ApplicationContext();
        }

    }
}
