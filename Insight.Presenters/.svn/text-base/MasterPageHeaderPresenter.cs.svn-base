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
    public class MasterPageHeaderPresenter : Presenter
    {
        IMasterPageHeaderView _view;

        public MasterPageHeaderPresenter(IMasterPageHeaderView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IMasterPageHeaderView>();
            _view.OnLogout += new EventHandler(_view_OnLogout);
            _view.OnSearch += new EventHandler(_view_OnSearch);
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            var appContext = SessionManager.Current[ResourceStrings.Session_ApplicationContext] as ApplicationContext;
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _view.DisplayLoggedOnUser = ApplicationContext.DisplayLoggedOnUser;
            _view.DisplayLogo = ApplicationContext.DisplayLogo;
            _view.DisplaySearch = ApplicationContext.DisplaySearch;
            _view.DisplaySettingsLinks = ApplicationContext.DisplaySettingsLinks;
            _view.DisplaySubNav = ApplicationContext.DisplaySubNav;
            _view.DisplayPrimaryNav = ApplicationContext.DisplayPrimaryNav;
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.PrimaryNavText = ApplicationContext.PrimaryNavText;
            _view.SubNavText = ApplicationContext.SubNavText;
            _view.LoggedOnUser = this.SecurityContext.CurrentUser.FirstName +
                " " + this.SecurityContext.CurrentUser.LastName;
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }

        void _view_OnSearch(object sender, EventArgs e)
        {
           
        }

        void _view_OnLogout(object sender, EventArgs e)
        {
            var user = new User();
            user = SecurityContextManager.Current.CurrentUser;
            UserServices.SaveUserPreferences(user);
            SecurityContextManager.Current.SignOutUser();
        }
    }
}
