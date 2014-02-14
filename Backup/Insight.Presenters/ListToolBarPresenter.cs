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
    public class ListToolBarPresenter : Presenter
    {
        IListToolBarView _listToolBarView;

        public ListToolBarPresenter(IListToolBarView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _listToolBarView = base.GetView<IListToolBarView>();
            _listToolBarView.OnCreateNewItem += new EventHandler(_listToolBarView_OnCreateNewItem);
            _listToolBarView.OnEmailItem += new EventHandler(_listToolBarView_OnEmailItem);
            _listToolBarView.OnExport += new EventHandler(_listToolBarView_OnExport);
            _listToolBarView.OnPrintItem += new EventHandler(_listToolBarView_OnPrintItem);
            _listToolBarView.OnListTypeChanged += new EventHandler<InsightGridArg>(_listToolBarView_OnListTypeChanged);
            _listToolBarView.OnManageFilterView += new EventHandler<InsightFiltersViewArg>(_listToolBarView_OnManageFilterView);
            _listToolBarView.OnToolBarLoad += new EventHandler(_listToolBarView_OnToolBarLoad);
            _listToolBarView.OnPageSizeChanged += new EventHandler<InsightGridArg>(_listToolBarView_OnPageSizeChanged);
            var appContext = SessionManager.Current["ApplicationContext"] as ApplicationContext;
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void _listToolBarView_OnToolBarLoad(object sender, EventArgs e)
        {
            _listToolBarView.SelectedPageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize.ToString();
        }

        void _listToolBarView_OnPageSizeChanged(object sender, InsightGridArg e)
        {
            MessageBus<InsightGridArg>.SendMessage(this, e);
        }

        void _listToolBarView_OnManageFilterView(object sender, InsightFiltersViewArg e)
        {
            //var arg = new InsightFiltersViewArg(e.CommandName);
            MessageBus<InsightFiltersViewArg>.SendMessage(this, e);
        }

        void _listToolBarView_OnListTypeChanged(object sender, InsightGridArg e)
        {
            MessageBus<InsightGridArg>.SendMessage(this, e);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _listToolBarView.DisplayToolBar = ApplicationContext.DisplayMainToolBar;
        }

        void _listToolBarView_OnPrintItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Print");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _listToolBarView_OnExport(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Export" + _listToolBarView.ExportFormat);
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _listToolBarView_OnEmailItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Email");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _listToolBarView_OnCreateNewItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("New");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }
    }
}
