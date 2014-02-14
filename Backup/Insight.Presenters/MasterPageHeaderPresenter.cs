using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Services;

namespace Insight.Presenters
{
    public class MasterPageHeaderPresenter : Presenter
    {
        IMasterPageHeaderView _headerView;

        public MasterPageHeaderPresenter(IMasterPageHeaderView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _headerView = base.GetView<IMasterPageHeaderView>();
            _headerView.OnLogout += new EventHandler(_headerView_OnLogout);
            _headerView.OnSearch += new EventHandler(_headerView_OnSearch);
            _headerView.InitView += new EventHandler(_headerView_InitView);
            _headerView.LoadView += new EventHandler(_headerView_LoadView);
            var appContext = SessionManager.Current[ResourceStrings.Session_ApplicationContext] as ApplicationContext;
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _headerView.DisplayLoggedOnUser = ApplicationContext.DisplayLoggedOnUser;
            _headerView.DisplayLogo = ApplicationContext.DisplayLogo;
            _headerView.DisplaySearch = ApplicationContext.DisplaySearch;
            _headerView.DisplaySettingsLinks = ApplicationContext.DisplaySettingsLinks;
            _headerView.DisplaySubNav = ApplicationContext.DisplaySubNav;
            _headerView.DisplayPrimaryNav = ApplicationContext.DisplayPrimaryNav;
        }

        void _headerView_LoadView(object sender, EventArgs e)
        {
            _headerView.PrimaryNavText = ApplicationContext.PrimaryNavText;
            _headerView.SubNavText = ApplicationContext.SubNavText;
            _headerView.LoggedOnUser = this.SecurityContext.CurrentUser.FirstName +
                " " + this.SecurityContext.CurrentUser.LastName;
        }

        void _headerView_InitView(object sender, EventArgs e)
        {
            
        }

        void _headerView_OnSearch(object sender, EventArgs e)
        {
           
        }

        void _headerView_OnLogout(object sender, EventArgs e)
        {
            var user = new User();
            user = SecurityContextManager.Current.CurrentUser;
            UserServices.SaveUserPreferences(user);
            SecurityContextManager.Current.SignOutUser();
        }
    }
}
