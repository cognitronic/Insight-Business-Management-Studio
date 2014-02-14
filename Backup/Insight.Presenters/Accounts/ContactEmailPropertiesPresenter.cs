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
    public class ContactEmailPropertiesPresenter : Presenter
    {
        IContactEmailPropertiesView  _view;

        public ContactEmailPropertiesPresenter(IContactEmailPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IContactEmailPropertiesView>();
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
            if (!IsInsert<ContactEmail>())
            {
                _view.LoadItem(GetCurrentItemReference<ContactEmail>());
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
                case "Save":
                    SaveItem();
                    break;
                case "SaveReturn":
                    SaveItem();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<ContactEmail>())
                    {
                        _view.LoadItem(GetCurrentItemReference<ContactEmail>());
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
            var item = new ContactEmail();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<ContactEmail>())
            {
                item = GetCurrentItemReference<ContactEmail>();
            }
            else
            {
                item.DateCreated = DateTime.Now;
                item.EnteredBy = _view.EnteredBy;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.Email = _view.Email;
            item.EmailTypeID = _view.EmailTypeID;
            item.ContactID = _view.ContactID;
            item.LastUpdated = DateTime.Now;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            new AccountServices().SaveContactEmail(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
        }

        void ClearControls()
        {
            _view.Email = "";
            _view.EmailTypeID = 0;
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
