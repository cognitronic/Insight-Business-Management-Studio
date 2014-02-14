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
    public class PropertiesToolBarPresenter : Presenter
    {
        IPropertiesToolBarView _view;

        public PropertiesToolBarPresenter(IPropertiesToolBarView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IPropertiesToolBarView>();
            _view.OnCancel += new EventHandler(_view_OnCancel);
            _view.OnCloneItem += new EventHandler(_view_OnCloneItem);
            _view.OnCreateNewItem += new EventHandler(_view_OnCreateNewItem);
            _view.OnDeleteItem += new EventHandler(_view_OnDeleteItem);
            _view.OnEmailItem += new EventHandler(_view_OnEmailItem);
            _view.OnExport += new EventHandler(_view_OnExport);
            _view.OnUndo += new EventHandler(_view_OnUndo);
            _view.OnPrintItem += new EventHandler(_view_OnPrintItem);
            _view.OnSaveAndReturn += new EventHandler(_view_OnSaveAndReturn);
            _view.OnSaveItem += new EventHandler(_view_OnSaveItem);

            var appContext = SessionManager.Current[ResourceStrings.Session_ApplicationContext] as ApplicationContext;
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void _view_OnUndo(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Undo");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _view.DisplayToolBar = ApplicationContext.DisplayMainToolBar;
        }

        void _view_OnSaveItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Save");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnSaveAndReturn(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("SaveReturn");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
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

        void _view_OnDeleteItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Delete");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnCreateNewItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("New");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnCloneItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Clone");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _view_OnCancel(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Cancel");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }
    }
}
