using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;

namespace Insight.Presenters
{
    public class AdminDashboardPresenter : Presenter
    {
        IAdminDashboardView _view;

        public AdminDashboardPresenter(IAdminDashboardView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAdminDashboardView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
        }
    }
}
