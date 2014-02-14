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

[PresenterType(typeof(ListToolBarPresenter))]
public partial class Views_ListToolBarView : BaseWebUserControl, IListToolBarView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (this.OnToolBarLoad != null)
        {
            this.OnToolBarLoad(this, EventArgs.Empty);
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
        }
    }

    protected void ListTypeSelectedIndexChanged(object o, EventArgs e)
    {
        var args = new InsightGridArg();
        args.ListType = CurrentListType;
        args.BindData = true;
        args.PageSize = Convert.ToInt16(((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue);
        if (this.OnListTypeChanged != null)
        {
            this.OnListTypeChanged(this, args);
        }
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
        get
        {
            if (GridListType.LIST.ToString() == ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("ListType")).FindControl("ddlListType")).SelectedValue)
                return GridListType.LIST;
            return GridListType.DETAIL;
        }
        set
        {
            ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("ListType")).FindControl("ddlListType")).SelectedValue = value.ToString();
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

    public event EventHandler OnFilterViewChanged;

    public event EventHandler<InsightFiltersViewArg> OnManageFilterView;

    public event EventHandler<InsightGridArg> OnPageSizeChanged;

    #endregion
}
