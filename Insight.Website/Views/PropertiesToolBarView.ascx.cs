using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Telerik.Web.UI;

namespace Insight.Website.Views
{
    [PresenterType(typeof(PropertiesToolBarPresenter))]
    public partial class PropertiesToolBarView : BaseWebUserControl, IPropertiesToolBarView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
        }

        protected void ButtonClicked(object o, RadToolBarEventArgs e)
        {
            switch (e.Item.Text)
            {
                case "Create New...":
                    if (this.OnCreateNewItem != null)
                    {
                        this.OnCreateNewItem(this, EventArgs.Empty);
                    }
                    break;
                case "Save":
                    if (this.OnSaveItem != null)
                    {
                        this.OnSaveItem(this, EventArgs.Empty);
                    }
                    break;
                case "Save & Return":
                    if (this.OnSaveAndReturn != null)
                    {
                        this.OnSaveAndReturn(this, EventArgs.Empty);
                    }
                    break;
                case "Cancel":
                    if (this.OnCancel != null)
                    {
                        this.OnCancel(this, EventArgs.Empty);
                    }
                    break;
                case "Undo":
                    if (this.OnUndo != null)
                    {
                        this.OnUndo(this, EventArgs.Empty);
                    }
                    break;
                case "Export":
                    if (this.OnExport != null)
                    {
                        this.OnExport(this, EventArgs.Empty);
                    }
                    break;
            }
        }

        #region IPropertiesToolBarView Members

        public bool DisplayToolBar
        {
            get
            {
                return divPropertiesToolBar.Visible;
            }
            set
            {
                divPropertiesToolBar.Visible = value;
            }
        }

        public string ExportFormat
        {
            get
            {
                return ((RadComboBox)((RadToolBarItem)rtbProperties.FindButtonByCommandName("ExportDDL")).FindControl("ddlExport")).SelectedValue;
            }
        }

        #endregion

        #region IPropertiesView Members

        public event EventHandler OnSaveItem;

        public event EventHandler OnDeleteItem;

        public event EventHandler OnCreateNewItem;

        public event EventHandler OnSaveAndReturn;

        public event EventHandler OnCloneItem;

        public event EventHandler OnCancel;

        public event EventHandler OnUndo;

        public event EventHandler OnEmailItem;

        public event EventHandler OnPrintItem;

        public event EventHandler OnExport;

        #endregion
    }

}