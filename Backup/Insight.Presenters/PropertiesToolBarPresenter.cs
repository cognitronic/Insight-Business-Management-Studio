using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Services;

namespace Insight.Presenters
{
    public class PropertiesToolBarPresenter : Presenter
    {
        IPropertiesToolBarView _propertiesToolBarView;

        public PropertiesToolBarPresenter(IPropertiesToolBarView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _propertiesToolBarView = base.GetView<IPropertiesToolBarView>();
            _propertiesToolBarView.OnCancel += new EventHandler(_propertiesToolBarView_OnCancel);
            _propertiesToolBarView.OnCloneItem += new EventHandler(_propertiesToolBarView_OnCloneItem);
            _propertiesToolBarView.OnCreateNewItem += new EventHandler(_propertiesToolBarView_OnCreateNewItem);
            _propertiesToolBarView.OnDeleteItem += new EventHandler(_propertiesToolBarView_OnDeleteItem);
            _propertiesToolBarView.OnEmailItem += new EventHandler(_propertiesToolBarView_OnEmailItem);
            _propertiesToolBarView.OnExport += new EventHandler(_propertiesToolBarView_OnExport);
            _propertiesToolBarView.OnUndo += new EventHandler(_propertiesToolBarView_OnUndo);
            _propertiesToolBarView.OnPrintItem += new EventHandler(_propertiesToolBarView_OnPrintItem);
            _propertiesToolBarView.OnSaveAndReturn += new EventHandler(_propertiesToolBarView_OnSaveAndReturn);
            _propertiesToolBarView.OnSaveItem += new EventHandler(_propertiesToolBarView_OnSaveItem);

            var appContext = SessionManager.Current["ApplicationContext"] as ApplicationContext;
            appContext.UpdateMasterPageControls += new EventHandler(appContext_UpdateMasterPageControls);
        }

        void _propertiesToolBarView_OnUndo(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Undo");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void appContext_UpdateMasterPageControls(object sender, EventArgs e)
        {
            _propertiesToolBarView.DisplayToolBar = ApplicationContext.DisplayMainToolBar;
        }

        void _propertiesToolBarView_OnSaveItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Save");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnSaveAndReturn(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("SaveReturn");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnPrintItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Print");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnExport(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Export" + _propertiesToolBarView.ExportFormat);
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnEmailItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Email");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnDeleteItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Delete");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnCreateNewItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("New");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnCloneItem(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Clone");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }

        void _propertiesToolBarView_OnCancel(object sender, EventArgs e)
        {
            var arg = new InsightToolBarButtonClickedArg("Cancel");
            MessageBus<InsightToolBarButtonClickedArg>.SendMessage(this, arg);
        }
    }
}
