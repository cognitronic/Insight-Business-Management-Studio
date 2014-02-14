using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Security
{
    /// <summary>
    /// SessionManager stores an instance if an ISessionProvider for state management.  This
    /// allows the Presentation project to avoid references to System.Web.  Consumers implement
    /// ISessionProvider based on how state is managed.  In the case of ASP.NET, the 
    /// implementation would wrap the System.Web.SessionState.HttpSessionState object
    /// </summary>
    public class SessionManager
    {
        private static SessionManager _sessionManager = new SessionManager();
        private static ISessionProvider _session;

        private SessionManager()
        {
        }

        public static ISessionProvider Current
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }
    }
}
