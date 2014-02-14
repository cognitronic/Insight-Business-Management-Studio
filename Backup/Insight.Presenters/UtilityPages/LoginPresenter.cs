using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces.UtilityPages;
using Insight.Core.Security;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Services;

namespace Insight.Presenters.UtilityPages
{
    public class LoginPresenter : Presenter
    {
        ILoginView _loginView;

        #region Constructors
        public LoginPresenter(ILoginView view)
            : this(view, null)
        { }

        public LoginPresenter(ILoginView view, ISessionProvider session)
            : base(view, session)
        {
            _loginView = base.GetView<ILoginView>();
            _loginView.OnLogin += new EventHandler(_loginView_OnLogin);
        }

        public LoginPresenter(ILoginView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _loginView = base.GetView<ILoginView>();
            _loginView.OnLogin += new EventHandler(_loginView_OnLogin);
            _loginView.InitView += new EventHandler(_loginView_Init);
            _loginView.LoadView += new EventHandler(_loginView_Load);
        }

        void _loginView_Load(object sender, EventArgs e)
        {
            ApplicationContext.ShowMasterPageHeaderControls(false);
            var ac = SessionManager.Current["ApplicationContext"] as ApplicationContext;
            ac.FireUpdateMasterPageControls();
        }

        void _loginView_Init(object sender, EventArgs e)
        {
            
        }
        #endregion


        void _loginView_OnLogin(object sender, EventArgs e)
        {
            string userName = _loginView.UserName;
            string password = _loginView.Password;

            // Example of managing state without referencing System.Web
            if (this.Session != null && Session["userName"] == null)
            {
                Session["userName"] = userName;
            }

            var response = new SecurityServices().AuthenticateUser(userName, password, "", this.SecurityContext);
            if (response.IsAuthenticated)
            {
                _loginView.LoginSuccessful();
            }
            else
            {
                _loginView.LoginFailed();
            }
            //if (userName.Equals("user") && password.Equals("pass"))
            //{
            //    _loginView.LoginSuccessful();
                
            //}
            //else
            //{
            //    _loginView.LoginFailed();
            //}
        }
    }
}
