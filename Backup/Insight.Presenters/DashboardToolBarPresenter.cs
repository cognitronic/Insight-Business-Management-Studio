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
    public class DashboardToolBarPresenter : Presenter
    {
        IDashboardToolBarView _toolbarView;

        public DashboardToolBarPresenter(IDashboardToolBarView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _toolbarView = base.GetView<IDashboardToolBarView>();
            var appContext = SessionManager.Current["ApplicationContext"] as ApplicationContext;
            _toolbarView.OnRefresh += new EventHandler(_toolbarView_OnRefresh);
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void _toolbarView_OnRefresh(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Refresh");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _toolbarView.DisplayToolBar = ApplicationContext.DisplayMainToolBar;
        }
    }
}
