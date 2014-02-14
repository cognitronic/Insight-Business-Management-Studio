using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;
using Insight.Services;

namespace Insight.Presenters
{
    public class LoginPresenter : Presenter
    {
        ILoginView _view;

        #region Constructors
        //public LoginPresenter(ILoginView view)
        //    : this(view, null)
        //{ }

        //public LoginPresenter(ILoginView view, ISessionProvider session)
        //    : base(view, session)
        //{
        //    _view = base.GetView<ILoginView>();
        //    _view.OnLogin += new EventHandler(_view_OnLogin);
        //}

        public LoginPresenter(ILoginView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<ILoginView>();
            _view.OnLogin += new EventHandler(_view_OnLogin);
            _view.InitView += new EventHandler(_view_Init);
            _view.LoadView += new EventHandler(_view_Load);
        }

        void _view_Load(object sender, EventArgs e)
        {
            ApplicationContext.ShowMasterPageHeaderControls(false);
            var ac = SessionManager.Current[ResourceStrings.Session_ApplicationContext] as ApplicationContext;
            ac.FireUpdateMasterPageControls();
        }

        void _view_Init(object sender, EventArgs e)
        {
            
        }
        #endregion


        void _view_OnLogin(object sender, EventArgs e)
        {
            string userName = _view.UserName;
            string password = _view.Password;

            // Example of managing state without referencing System.Web
            //if (this.Session != null && Session["userName"] == null)
            //{
            //    Session["userName"] = userName;
            //}

            var response = new SecurityServices().AuthenticateUser(userName, password, "", this.SecurityContext);
            if (response.IsAuthenticated)
            {
                _view.LoginSuccessful();
            }
            else
            {
                _view.LoginFailed();
            }
        }
    }
}
