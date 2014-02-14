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
using IdeaSeed.Core.Utils;
using IdeaSeed.Core.Security;

namespace Insight.Presenters
{
    public class UserPropertiesPresenter : Presenter
    {
        IUserPropertiesView _view;

        public UserPropertiesPresenter(IUserPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IUserPropertiesView>();
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
            if (!IsInsert<User>())
            {
                _view.LoadItem(GetCurrentItemReference<User>());
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
                    _view.NavigateTo(SecurityContextManager.Current.BaseURL + "/Admin/Users/New");
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
                    if (!IsInsert<User>())
                    {
                        _view.LoadItem(GetCurrentItemReference<User>());
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
            var item = new User();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<User>())
            {
                item = GetCurrentItemReference<User>();
            }
            else
            {
                item.DateCreated = DateTime.Now;
                item.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
                item.Password = SecurityUtils.GetMd5Hash(SecurityUtils.GeneratePassword());
                item.PasswordAnswer = SecurityUtils.GetMd5Hash("changeme");
                item.PasswordLastChangedDate = DateTime.Now;
                item.PasswordQuestion = "The answer is changeme";
                item.LastLoginDate = DateTime.Now;
            }
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.Avatar = _view.Avatar;
            item.CellPhone = Utilities.FormatPhoneNumberForStorage(_view.CellPhone);
            item.FirstName = _view.FirstName;
            item.HomePhone = Utilities.FormatPhoneNumberForStorage(_view.HomePhone);
            item.DepartmentID = _view.DepartmentID;
            item.LastName = _view.LastName;
            item.WorkPhone = Utilities.FormatPhoneNumberForStorage(_view.WorkPhone);
            item.Description = _view.Description;
            item.IsActive = _view.IsActive;
            item.Email = _view.Email;
            item.LastUpdated = DateTime.Now;
            if(!item.UserName.Equals(_view.UserName))
                if(SecurityServices.IsUsernameAvailable(_view.UserName))
                    item.UserName = _view.UserName;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            item.IMHandle = _view.IMHandle;
            item.Name = _view.Name;
            new UserServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
            else
                _view.LoadItem(item);

        }

        void ClearControls()
        {
            _view.Avatar = "";
            _view.CellPhone = "";
            _view.Description = "";
            _view.FirstName = "";
            _view.HomePhone = "";
            _view.IsActive = false;
            _view.DepartmentID = 0;
            _view.ItemReference = null;
            _view.LastName = "";
            _view.UserName = "";
            _view.MarkedForDeletion = false;
            _view.Message = "";
            _view.Name = "";
            _view.IMHandle = "";
            _view.WorkPhone = "";
            _view.Email = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
