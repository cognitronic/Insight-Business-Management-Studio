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
    public class ContactPropertiesPresenter : Presenter
    {
        IContactPropertiesView _view;

        public ContactPropertiesPresenter(IContactPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IContactPropertiesView>();
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
            if (!IsInsert<ClientContact>())
            {
                _view.LoadItem(GetCurrentItemReference<ClientContact>());
            }
            else
            {
                _view.AccountID = GetCurrentItemReference<Account>().ID;
                _view.IsActive = true;
            }
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "Save":
                    SaveItem();
                    break;
                case "SaveReturn":
                    SaveItem();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<ClientContact>())
                    {
                        _view.LoadItem(GetCurrentItemReference<ClientContact>());
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
            var item = new ClientContact();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<ClientContact>())
            {
                item = GetCurrentItemReference<ClientContact>();
            }
            else
            {
                item.DateCreated = DateTime.Now;
                item.EnteredBy = _view.EnteredBy;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.AvatarPath = _view.AvatarPath;
            item.CellPhone = _view.CellPhone;
            item.FirstName = _view.FirstName;
            item.HomePhone = _view.HomePhone;
            item.IsKeyContact = _view.IsKeyContact;
            item.AccountID = _view.AccountID;
            item.LastName = _view.LastName;
            item.Location = _view.Location;
            item.Title = _view.Title;
            item.WorkPhone = _view.WorkPhone;
            item.Description = _view.Description;
            item.IsActive = _view.IsActive;
            item.PrimaryEmail = _view.PrimaryEmail;
            item.LastUpdated = DateTime.Now;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            item.Name = _view.Name;
            new AccountServices().SaveContact(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());

        }

        void ClearControls()
        {
            _view.AvatarPath = "";
            _view.CellPhone = "";
            _view.Description = "";
            _view.FirstName = "";
            _view.HomePhone = "";
            _view.IsActive = false;
            _view.IsKeyContact = false;
            _view.AccountID = 0;
            _view.ItemReference = null;
            _view.LastName = "";
            _view.Location = "";
            _view.MarkedForDeletion = false;
            _view.Message = "";
            _view.Name = "";
            _view.Title = "";
            _view.WorkPhone = "";
            _view.PrimaryEmail = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }

        
    }
}
