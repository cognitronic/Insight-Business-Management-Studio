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
    public class AddressPropertiesPresenter : Presenter
    {
        IAddressPropertiesView _view;

        public AddressPropertiesPresenter(IAddressPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAddressPropertiesView>();
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
            LoadAddress();
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "New":
                    string url = SecurityContextManager.Current.CurrentURL + "/New";
                    _view.NavigateTo(url);
                    break;
                case "Save":
                    SaveAddress();
                    break;
                case "SaveReturn":
                    SaveAddress();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<AccountAddress>())
                    {
                        _view.LoadAddress(GetCurrentItemReference<AccountAddress>());
                    }
                    else
                    {
                        ClearControls();
                    }
                    break;
                case "ExportPDF":
                    
                    break;
                case "ExportExcel":
                    
                    break;
                case "Cancel":
                    NavigateBack();
                    break;
            }
        }

        void SaveAddress()
        {
            var address = new AccountAddress();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<AccountAddress>())
            {
                address = GetCurrentItemReference<AccountAddress>();
            }
            else
            {
                address.DateCreated = DateTime.Now;
                address.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            address.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            address.Description = _view.Description;
            address.LastUpdated = DateTime.Now;
            address.MarkedForDeletion = _view.MarkedForDeletion;
            address.Name = _view.Name;
            address.AccountID = _view.AccountID;
            address.Address1 = _view.Address1;
            address.Address2 = _view.Address2;
            address.AddressType = _view.AddressType;
            address.City = _view.City;
            address.State = _view.State;
            address.Title = _view.Title;
            address.Zip = _view.Zip;
            new AccountServices().SaveAccountAddress(address);
            if(isInsert)
                _view.NavigateTo(url + address.ID.ToString());
        }

        void LoadAddress()
        {
            if (!IsInsert<AccountAddress>())
            {
                _view.LoadAddress(GetCurrentItemReference<AccountAddress>());
            }
            else
            {
                _view.AccountID = Convert.ToInt32(((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Description);
            }
        }

        void ClearControls()
        {
            _view.AccountID = 0;
            _view.Address1 = "";
            _view.Address2 = "";
            _view.AddressType = "";
            _view.City = "";
            _view.State = "";
            _view.Title = "";
            _view.Zip = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
