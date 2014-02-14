using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Insight.Presenters;
using Insight.Core.Security;

namespace Insight.Web.Security
{
    // <summary>
    /// WebSessionProvider wraps asp.net's session object for use with the MVP
    /// pattern.  The presentation library shouldn't know about anything "downstram," 
    /// which means no references to System.Web etc.  Because the class implements
    /// ISessionProvider (in the Presentation project), state can still be maintained 
    /// using the HttpSessionState object. 
    /// </summary>
    public class WebSessionProvider : ISessionProvider
    {
        private HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public void Add(string name, object value)
        {
            Session.Add(name, value);
        }

        public void Clear()
        {
            Session.Clear();
        }

        public bool Contains(string name)
        {
            return Session[name] != null;
        }

        #region ISessionProvider Members

        object ISessionProvider.this[string name]
        {
            get
            {
                return Session[name];
            }
            set
            {
                Session[name] = value;
            }
        }

        object ISessionProvider.this[int index]
        {
            get
            {
                return Session[index];
            }
            set
            {
                Session[index] = value;
            }
        }

        #endregion
    }
}
