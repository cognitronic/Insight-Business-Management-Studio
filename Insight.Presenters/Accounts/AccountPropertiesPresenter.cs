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
    public class AccountPropertiesPresenter : Presenter
    {
        IAccountPropertiesView _view;

        public AccountPropertiesPresenter(IAccountPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAccountPropertiesView>();
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);
            _view.OnLoad += new EventHandler(_view_OnLoad);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
        }

        void _view_OnLoad(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            if (!IsInsert<Account>())
            {
                _view.LoadAccount(GetCurrentItemReference<Account>());
            }
            else
            {
                _view.IsActive = true;
            }
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            { 
                case "New":
                    _view.NavigateTo(SecurityContextManager.Current.BaseURL + "/Accounts/New");
                    break;
                case "Save":
                    SaveAccount();
                    break;
                case "SaveReturn":
                    SaveAccount();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<Account>())
                    {
                        _view.LoadAccount(GetCurrentItemReference<Account>());
                    }
                    else
                    {
                        ClearControls();
                    }
                    break;
                case "ExportPDF":
                    _view.ServiceLevelAgreementID = 1;
                    break;
                case "ExportExcel":
                    _view.ServiceLevelAgreementID = 2;
                    break;
                case "Cancel":
                    NavigateBack();
                    break;
            }
        }

        void SaveAccount()
        {
            var account = new Account();
            string url = "";
            bool isInsert = false;
            if (!IsInsert<Account>())
            {
                account = GetCurrentItemReference<Account>();
            }
            else
            {
                account.DateCreated = DateTime.Now;
                account.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                url = SecurityContextManager.Current.BaseURL + "/Accounts/Name=";
                isInsert = true;
            }
            account.AccountManagerID = _view.AccountManagerID;
            account.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            account.Description = _view.Description;
            account.EmailDomain = _view.EmailDomain;
            account.Fax = _view.Fax;
            account.IndustryTypeID = _view.IndustryTypeID;
            account.IsActive = _view.IsActive;
            account.LastUpdated = DateTime.Now;
            account.MarkedForDeletion = _view.MarkedForDeletion;
            account.Name = _view.Name;
            account.ParentAccountID = _view.ParentAccountID;
            account.Phone = _view.Phone;
            account.ServiceLevelAgreementID = _view.ServiceLevelAgreementID;
            account.Website = _view.Website;
            new AccountServices().SaveAccount(account);
            if (isInsert)
                _view.NavigateTo(url + account.Name.Replace(" ", "-") + "/Properties");
            else
                _view.LoadAccount(account);
        }

        void ClearControls()
        {
            _view.AccountManagerID = 0;
            _view.EmailDomain = "";
            _view.Fax = "";
            _view.IndustryTypeID = 0;
            _view.IsActive = false;
            _view.ItemReference = null;
            _view.Name = "";
            _view.ParentAccountID = 0;
            _view.Phone = "";
            _view.ServiceLevelAgreementID = 0;
            _view.Website = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
