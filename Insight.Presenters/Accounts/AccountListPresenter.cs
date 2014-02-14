using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces.Accounts;
using Insight.Core.Security;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Services;


namespace Insight.Presenters.Accounts
{
    public class AccountListPresenter : Presenter
    {
        IAccountListView _view;

        public AccountListPresenter(IAccountListView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAccountListView>();
            _view.OnItemSelected += new EventHandler<InsightLinkButtonArgs>(OnAccountSelected);
            _view.OnGetItems += new EventHandler<InsightGridArg>(OnGetAccounts);
            _view.InitView += new EventHandler(_view_Init);
            _view.LoadView += new EventHandler(_view_Load);
            _view.OnItemsDataBound += new EventHandler<InsightGridItemEventArgs>(_view_OnItemsDataBound);
            _view.UnloadView += new EventHandler(_view_UnloadView);

            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);

            MessageBus<InsightGridArg>.MessageReceived += new EventHandler<InsightGridArg>(Presenter_MessageReceived);
            MessageBus<InsightFiltersViewArg>.MessageReceived += new EventHandler<InsightFiltersViewArg>(Presenter_MessageReceived);
        }

        void _view_OnItemsDataBound(object sender, InsightGridItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        void Presenter_MessageReceived(object sender, InsightFiltersViewArg e)
        {
            throw new NotImplementedException();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
            MessageBus<InsightGridArg>.MessageReceived -= Presenter_MessageReceived;
            MessageBus<InsightFiltersViewArg>.MessageReceived -= Presenter_MessageReceived;
            
            //update the current user's grid page size preference.
            if(SecurityContextManager.Current != null)
            SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize = _view.PageSize;
        }

        void Presenter_MessageReceived(object sender, InsightGridArg e)
        {
            _view.PageSize = e.PageSize;
            GetAccountsResults(e);
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "New":
                    string url = SecurityContextManager.Current.BaseURL + ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).URL + "/New";
                    _view.NavigateTo(url);
                    break;
                case "Print":
                    break;
                case "ExportPDF":
                    break;
                case "ExportExcel":
                    break;
                case "Email":
                    break;
                case "ListTypeList":
                    break;
                case "ListTypeDetails":
                    break;
            }
        }

        void _view_Load(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            if (SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize > 0)
                _view.PageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize;
            else
                _view.PageSize = 5;
        }

        void _view_Init(object sender, EventArgs e)
        {
            _view.PageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize;
        }

        void OnAccountSelected(object o, InsightLinkButtonArgs e)
        { 
            string url = SecurityContextManager.Current.BaseURL + "/Accounts/Name=" + e.ObjectName.Replace(" ", "-") + "/Properties";
            _view.NavigateTo(url);
        }

        void OnGetAccounts(object o, InsightGridArg e)
        {
            if (e.ListType == 0)
                e.ListType = GridListType.LIST;
            GetAccountsResults(e);
        }

        void GetAccountsResults(InsightGridArg e)
        {
            int count = 0;
            _view.ResultSet = new Insight.Services.AccountServices().GetAllAccounts(_view.CurrentPageIndex, _view.PageSize, out count);
            _view.VirtualItemCount = count;
            _view.LoadResultSet(e);
        }
    }
}
