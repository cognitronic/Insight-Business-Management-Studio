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
    public class ListToolBarPresenter : Presenter
    {
        IListToolBarView _view;

        public ListToolBarPresenter(IListToolBarView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IListToolBarView>();
            _view.OnCreateNewItem += new EventHandler(_view_OnCreateNewItem);
            _view.OnEmailItem += new EventHandler(_view_OnEmailItem);
            _view.OnExport += new EventHandler(_view_OnExport);
            _view.OnPrintItem += new EventHandler(_view_OnPrintItem);
            _view.OnListTypeChanged += new EventHandler<InsightGridArg>(_view_OnListTypeChanged);
            _view.OnListViewChanged += new EventHandler<InsightListViewEventArgs>(_view_OnListViewChanged);
            _view.OnToolBarLoad += new EventHandler(_view_OnToolBarLoad);
            _view.OnPageSizeChanged += new EventHandler<InsightGridArg>(_view_OnPageSizeChanged);
            var appContext = SessionManager.Current[ResourceStrings.Session_ApplicationContext] as ApplicationContext;
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void _view_OnListViewChanged(object sender, InsightListViewEventArgs e)
        {
            if(!string.IsNullOrEmpty(_view.SelectedListViewID))
                _view.NavigateTo("/ListViews/ID=" + _view.SelectedListViewID);
            else
                _view.NavigateTo("/ListViews/New");
        }

        void _view_OnToolBarLoad(object sender, EventArgs e)
        {
            _view.SelectedPageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize.ToString();
        }

        void _view_OnPageSizeChanged(object sender, InsightGridArg e)
        {
            MessageBus<InsightGridArg>.SendMessage(this, e);
        }

        void _view_OnManageFilterView(object sender, InsightFiltersViewArg e)
        {
            //var arg = new InsightFiltersViewArg(e.CommandName);
            MessageBus<InsightFiltersViewArg>.SendMessage(this, e);
        }

        void _view_OnListTypeChanged(object sender, InsightGridArg e)
        {
            MessageBus<InsightGridArg>.SendMessage(this, e);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _view.DisplayToolBar = ApplicationContext.DisplayMainToolBar;
        }

        void _view_OnPrintItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Print");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnExport(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Export" + _view.ExportFormat);
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnEmailItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Email");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnCreateNewItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("New");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }
    }
}
