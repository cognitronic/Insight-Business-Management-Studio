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
    public class DashboardToolBarPresenter : Presenter
    {
        IDashboardToolBarView _view;

        public DashboardToolBarPresenter(IDashboardToolBarView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IDashboardToolBarView>();
            var appContext = SessionManager.Current[ResourceStrings.Session_ApplicationContext] as ApplicationContext;
            _view.OnRefresh += new EventHandler(_view_OnRefresh);
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void _view_OnRefresh(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Refresh");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _view.DisplayToolBar = ApplicationContext.DisplayMainToolBar;
        }
    }
}
