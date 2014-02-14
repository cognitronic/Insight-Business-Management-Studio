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
    public class ContactAddressPropertiesPresenter : Presenter
    {
        IContactAddressPropertiesView  _view;

        public ContactAddressPropertiesPresenter(IContactAddressPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IContactAddressPropertiesView>();
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            if (!IsInsert<ContactAddress>())
            {
                _view.LoadItem(GetCurrentItemReference<ContactAddress>());
            }
            else
            {
                _view.ContactID = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).ID;
            }
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "New":
                    _view.NavigateTo(ReplaceURLSegment(SecurityContextManager.Current.CurrentURL, 9, "New"));
                    break;
                case "Save":
                    SaveItem();
                    break;
                case "SaveReturn":
                    SaveItem();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<ContactAddress>())
                    {
                        _view.LoadItem(GetCurrentItemReference<ContactAddress>());
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

        void SaveItem()
        {
            var item = new ContactAddress();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<ContactAddress>())
            {
                item = GetCurrentItemReference<ContactAddress>();
            }
            else
            {
                item.DateCreated = DateTime.Now;
                item.EnteredBy = _view.EnteredBy;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.Address1 = _view.Address1;
            item.Address2 = _view.Address2;
            item.AddressTypeID = _view.AddressTypeID;
            item.AddressType = _view.AddressType;
            item.City = _view.City;
            item.ContactID = _view.ContactID;
            item.State = _view.State;
            item.Title = _view.Title;
            item.Zip = _view.Zip;
            item.LastUpdated = DateTime.Now;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            new AccountServices().SaveContactAddress(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
        }

        void ClearControls()
        {
            _view.Address1 = "";
            _view.Address2 = "";
            _view.AddressTypeID = 0;
            _view.City = "";
            _view.ContactID = 0;
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
