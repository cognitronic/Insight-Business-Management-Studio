using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;
using Insight.Services.Utils;

namespace Insight.Presenters
{
    public class FiltersPropertiesPresenter : Presenter
    {
        IFiltersPropertiesView _view;

        public FiltersPropertiesPresenter(IFiltersPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IFiltersPropertiesView>();
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
            if (!IsInsert<BaseListFilter>())
            {
                _view.LoadItem(GetCurrentItemReference<BaseListFilter>());
            }
            else
            {
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
                    if (!IsInsert<BaseListFilter>())
                    {
                        _view.LoadItem(GetCurrentItemReference<BaseListFilter>());
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
            var item = new BaseListFilter();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<BaseListFilter>())
            {
                item = GetCurrentItemReference<BaseListFilter>();
            }
            else
            {
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            item.UserID = SecurityContextManager.Current.CurrentUser.ID;
            item.PageID = SecurityContextManager.Current.CurrentPage.ID;
            item.Name = _view.Name;
            item.IsDefault = _view.IsDefault;
            item.SearchCriterion = _view.SearchCriterion;
            item.SearchPropertyControls = _view.SearchPropertyControls;
            item.Description = _view.Description;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            //new ContactServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
            else
                _view.LoadItem(item);

        }

        void ClearControls()
        {
            _view.Name = "";
            _view.UserID = 0;
            _view.PageID = 0;
            _view.Description = "";
            _view.IsDefault = false;
            _view.SearchPropertyControls = "";
            _view.SearchCriterion = "";
            _view.MarkedForDeletion = false;
            _view.Message = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
