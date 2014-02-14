using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Insight.Presenters;
using Insight.Presenters.Accounts;
using Insight.Presenters.ViewInterfaces.Accounts;
using Telerik.Web.UI;
using Insight.Core.Domain;

[PresenterType(typeof(AddressListPresenter))]
public partial class Accounts_Views_AddressListView : BaseWebUserControl, IAddressListView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (!IsPostBack)
        {
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            if (this.OnGetItems != null)
            {
                var args = new InsightGridArg();
                args.BindData = true;
                args.ListType = GridListType.LIST;
                this.OnGetItems(this, args);
            }
        }
    }

    protected void ToggleGridSelectedState(object o, EventArgs e)
    {

    }

    protected override void OnUnload(EventArgs e)
    {
        base.OnUnload(e);
        if (this.UnloadView != null)
        {
            this.UnloadView(this, EventArgs.Empty);
        }
    }

    protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
    {
        var args = new InsightGridArg();
        args.BindData = false;
        if (this.OnGetItems != null)
        {
            this.OnGetItems(this, args);
        }
    }

    protected void ItemCommand(object o, GridCommandEventArgs e)
    {

    }

    protected void ViewItemClicked(object o, EventArgs e)
    {
        var lb = o as IdeaSeed.Web.UI.LinkButton;
        var args = new InsightLinkButtonArgs();
        args.ObjectID = Convert.ToInt32(lb.Attributes["itemid"]);
        args.ObjectName = lb.Attributes["itemname"];
        if (OnItemSelected != null)
        {
            OnItemSelected(this, args);
        }
    }

    #region IBaseListView<Account> Members

    public string ViewTitle
    {
        get
        {
            return lblListTitle.Text;
        }
        set
        {
            lblListTitle.Text = value;
        }
    }

    public IList<AccountAddress> ResultSet
    {
        get;
        set;
    }

    public GridListType ListType { get; set; }

    public void LoadResultSet(InsightGridArg args)
    {
        if (args.ListType == GridListType.LIST)
        {
            rgList.Visible = true;
            dlAddresses.Visible = false;
            dlAddresses.DataSource = null;
            rgList.DataSource = null;
            rgList.PageSize = this.PageSize;
            //rgAccounts.VirtualItemCount = this.VirtualItemCount;
            rgList.DataSource = ResultSet;
            if (args.BindData)
            {
                rgList.DataBind();
            }
            //divListView.Visible = true;
            //divDetailView.Visible = false;
        }
        else
        {
            rgList.Visible = false;
            dlAddresses.Visible = true;
            dlAddresses.DataSource = null;
            rgList.DataSource = null;
            dlAddresses.DataSource = ResultSet;
            dlAddresses.DataBind();
            //divListView.Visible = false;
            //divDetailView.Visible = true;
        }
    }

    public int PageSize
    {
        get
        {
            return rgList.PageSize;
        }
        set
        {
            rgList.PageSize = value;
        }
    }

    public int CurrentPageIndex
    {
        get
        {
            return rgList.CurrentPageIndex;
        }
        set
        {
            rgList.CurrentPageIndex = value;
        }
    }

    public void NavigateTo(string url)
    {
        HttpContext.Current.Response.Redirect(url);
    }

    public int VirtualItemCount
    {
        get
        {
            return rgList.VirtualItemCount;
        }
        set
        {
            rgList.VirtualItemCount = value;
        }
    }

    public void RebindGrid()
    {
        rgList.PageSize = this.PageSize;
        rgList.Rebind();
    }

    public event EventHandler<InsightLinkButtonArgs> OnItemSelected;

    public event EventHandler<InsightGridArg> OnGetItems;

    public event EventHandler<InsightGridItemEventArgs> OnItemsDataBound;

    public new event EventHandler LoadView;
    public new event EventHandler UnloadView;

    #endregion
}
