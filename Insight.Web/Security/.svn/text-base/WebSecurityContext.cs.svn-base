using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeed.Web.UI;
using IdeaSeed.Core.Web;
using Telerik.Web.UI;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;
using System.Web.Security;
using Insight.Core.Domain;
using Insight.Core.Security;
using Insight.Presenters;

namespace Insight.Web.Security
{
    public class WebSecurityContext : ISecurityContext
    {
        public WebSecurityContext()
        {
            this.SignOut += new EventHandler(WebSecurityContext_SignOut);
        }

        void WebSecurityContext_SignOut(object sender, EventArgs e)
        {
            SecurityContextManager.Current = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(ResourceStrings.Page_Login);
        }
        
        public bool IsAuthenticated
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_IsAuthenticated] != null)
                {
                    return (bool)SessionManager.Current[ResourceStrings.Session_IsAuthenticated];
                }
                else
                {
                    SignOutUser();
                    return false;
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_IsAuthenticated] = value;
            }
        }

        public Insight.Core.Domain.Page CurrentPage
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentPage] != null)
                {
                    return (Insight.Core.Domain.Page)SessionManager.Current[ResourceStrings.Session_CurrentPage];
                }
                return new Insight.Core.Domain.Page();
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentPage] = value;
            }
        }

        public User CurrentUser
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentUser] != null)
                {
                    return (User)SessionManager.Current[ResourceStrings.Session_CurrentUser];
                }
                return new User();
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentUser] = value;
            }
        }

        public string BaseURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
                else
                {
                    SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = value;
            }
        }

        public string PreviousURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL].ToString();
                }
                return ResourceStrings.Page_Default;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL] = value;
            }
        }

        public string CurrentURL
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }
        
        public Module CurrentModule
        {
            get;
            set;
        }

        public AccessLevels CurrentAccessLevel
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] != null)
                {
                    return (AccessLevels)SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel];
                }
                return AccessLevels.NOACCESS;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] = value;
            }
        }

        public event EventHandler SignOut;

        protected virtual void OnSignOut(EventArgs e)
        {
            var handler = this.SignOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SignOutUser()
        {
            this.OnSignOut(EventArgs.Empty);
        }
    }
}
