<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Insight.Core" %>
<%@ Import Namespace="Insight.Core.Domain" %>
<%@ Import Namespace="Insight.Core.Utils" %>
<%@ Import Namespace="Insight.Core.Security" %>
<%@ Import Namespace="Insight.Services" %>
<%@ Import Namespace="Insight.Web.Routing" %>
<script runat="server">

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
        UserServices.SaveUserPreferences(SecurityContextManager.Current.CurrentUser);

    }

    void Application_BeginRequest(object sender, EventArgs e)
    { 
        HttpContext.Current.Items["ApplicationContext"] = new ApplicationContext();
    }
       
</script>
