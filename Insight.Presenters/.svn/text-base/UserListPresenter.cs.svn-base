using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;
using Insight.Services;

namespace Insight.Presenters
{
    public class UserListPresenter: Presenter
    {
        IUserListView _view;

        public UserListPresenter(IUserListView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IUserListView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.OnGetItems += new EventHandler<InsightGridArg>(_view_OnGetItems);
            _view.OnItemSelected += new EventHandler<InsightLinkButtonArgs>(_view_OnItemSelected);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.InitView += new EventHandler(_view_InitView);
            _view.OnItemsDataBound += new EventHandler<InsightGridItemEventArgs>(_view_OnItemsDataBound);
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);
            MessageBus<InsightGridArg>.MessageReceived += new EventHandler<InsightGridArg>(Presenter_MessageReceived);
            MessageBus<InsightFiltersViewArg>.MessageReceived += new EventHandler<InsightFiltersViewArg>(Presenter_MessageReceived);
        }

        void _view_OnItemsDataBound(object sender, InsightGridItemEventArgs e)
        {
            var item = (User)e.Item;
        }

        void Presenter_MessageReceived(object sender, InsightFiltersViewArg e)
        {
            throw new NotImplementedException();
        }

        void Presenter_MessageReceived(object sender, InsightGridArg e)
        {
            _view.ListType = e.ListType;
            _view.PageSize = e.PageSize;
            GetItemResults(e);
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "New":
                    _view.NavigateTo(SecurityContextManager.Current.CurrentURL + "/New");
                    break;
                case "Print":
                    break;
                case "ExportPDF":
                    break;
                case "ExportExcel":
                    break;
                case "Email":
                    break;
            }
        }

        void _view_InitView(object sender, EventArgs e)
        {
            _view.PageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize;
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
            MessageBus<InsightGridArg>.MessageReceived -= Presenter_MessageReceived;
            MessageBus<InsightFiltersViewArg>.MessageReceived -= Presenter_MessageReceived;

            //update the current user's grid page size preference.
            if (SecurityContextManager.Current != null)
                SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize = _view.PageSize;
        }

        void _view_OnItemSelected(object sender, InsightLinkButtonArgs e)
        {
            string url = SecurityContextManager.Current.CurrentURL + "/ID=" + e.ObjectID.ToString();
            _view.NavigateTo(url);
        }

        void _view_OnGetItems(object sender, InsightGridArg e)
        {
            if (e.ListType == 0)
                e.ListType = GridListType.LIST;
            GetItemResults(e);
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            _view.PageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize;
        }

        void GetItemResults(InsightGridArg e)
        {
            int count = 0;
            _view.ResultSet = new UserServices().
                GetPagedList(_view.CurrentPageIndex, _view.PageSize, out count).
                ToList<User>();
            _view.VirtualItemCount = count;
            _view.LoadResultSet(e);
        }
    }
}
