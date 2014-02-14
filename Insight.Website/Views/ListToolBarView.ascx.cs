using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Web.Utils;
using Telerik.Web.UI;

namespace Insight.Website.Views
{
    [PresenterType(typeof(ListToolBarPresenter))]
    public partial class ListToolBarView : BaseWebUserControl, IListToolBarView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.OnToolBarLoad != null)
            {
                this.OnToolBarLoad(this, EventArgs.Empty);
            }
            if (!IsPostBack)
            {
                ((RadToolBarButton)((RadToolBarItem)rtbList.FindButtonByCommandName("ListView"))).Checked = true;
                LoadViewsDDL();
            }
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
                case "Export":
                    if (this.OnExport != null)
                    {
                        this.OnExport(this, EventArgs.Empty);
                    }
                    break;
                case "List":
                    var args = new InsightGridArg();
                    CurrentListType = GridListType.LIST;
                    args.ListType = CurrentListType;
                    args.BindData = true;
                    args.PageSize = Convert.ToInt16(((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue);
                    ((RadToolBarButton)((RadToolBarItem)rtbList.FindButtonByCommandName("DetailView"))).Checked = false;
                    ((RadToolBarButton)((RadToolBarItem)rtbList.FindButtonByCommandName("ListView"))).Checked = true;
                    if (this.OnListTypeChanged != null)
                    {
                        this.OnListTypeChanged(this, args);
                    }
                    break;
                case "Detail":
                    args = new InsightGridArg();
                    CurrentListType = GridListType.DETAIL;
                    args.ListType = CurrentListType;
                    args.BindData = true;
                    args.PageSize = Convert.ToInt16(((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue);
                     ((RadToolBarButton)((RadToolBarItem)rtbList.FindButtonByCommandName("DetailView"))).Checked = true;
                    ((RadToolBarButton)((RadToolBarItem)rtbList.FindButtonByCommandName("ListView"))).Checked = false;
                    if (this.OnListTypeChanged != null)
                    {
                        this.OnListTypeChanged(this, args);
                    }
                    break;
            }
        }

        protected void ViewsSelectedIndexChanged(object o, EventArgs e)
        {
            //var args = new InsightGridArg();
            //args.ListType = CurrentListType;
            //args.BindData = true;
            //args.PageSize = Convert.ToInt16(((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue);
            var args = new InsightListViewEventArgs();
            args.SelectedViewID = this.SelectedListViewID;
            if (this.OnListViewChanged != null)
            {
                this.OnListViewChanged(this, args);
            }
        }

        public void NavigateTo(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }
        protected void GridPageSizeChanged(object o, EventArgs e)
        {
            var args = new InsightGridArg();
            args.ListType = CurrentListType;
            args.BindData = true;
            args.PageSize = Convert.ToInt16(((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue);
            if (this.OnPageSizeChanged != null)
            {
                this.OnPageSizeChanged(this, args);
            }
        }

        #region IListToolBarView Members

        public bool DisplayToolBar
        {
            get
            {
                return divListToolBar.Visible;
            }
            set
            {
                divListToolBar.Visible = value;
            }
        }

        public string ExportFormat
        {
            get
            {
                return ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("ExportDDL")).FindControl("ddlExport")).SelectedValue;
            }
        }

        public GridListType CurrentListType
        {
            get;
            set;
        }

        public string SelectedListViewID
        {
            get
            {
                return ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Views")).FindControl("ddlViews")).SelectedValue;
            }
            set
            {
                ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Views")).FindControl("ddlViews")).SelectedValue = value;
            }
        }

        public string SelectedPageSize
        {
            get
            {
                return ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue;
            }
            set
            {
                ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue = value;
            }
        }

        public event EventHandler OnEmailItem;

        public event EventHandler OnPrintItem;

        public event EventHandler OnToolBarLoad;

        public event EventHandler OnExport;

        public event EventHandler OnCreateNewItem;

        public event EventHandler<InsightGridArg> OnListTypeChanged;

        public event EventHandler<InsightListViewEventArgs> OnListViewChanged;

        public event EventHandler<InsightGridArg> OnPageSizeChanged;

        #endregion

        private void LoadViewsDDL()
        {
            var combo = ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Views")).FindControl("ddlViews"));
            combo.Items.Add(new RadComboBoxItem("", ""));
            combo.Items.Add(new RadComboBoxItem("Add New View", ""));

        }
    }

}