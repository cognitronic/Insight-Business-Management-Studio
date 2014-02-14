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

[PresenterType(typeof(AccountListPresenter))]
public partial class Views_AccountListView : BaseWebUserControl, IAccountListView
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
        //LoadAccounts(false);
    }

    protected void ItemCommand(object o, GridCommandEventArgs e)
    { 
        
    }

    protected void ViewAccountClicked(object o, EventArgs e)
    {
        var lb = o as IdeaSeed.Web.UI.LinkButton;
        var args = new InsightLinkButtonArgs();
        args.ObjectID = Convert.ToInt32(lb.Attributes["accountid"]);
        args.ObjectName = lb.Attributes["accountname"];
        if (OnItemSelected != null)
        {
            OnItemSelected(this, args);
        }
    }

    #region IAccountListView Members

    public event EventHandler<InsightLinkButtonArgs> OnItemSelected;

    public event EventHandler<InsightGridArg> OnGetItems;

    public event EventHandler<InsightGridItemEventArgs> OnItemsDataBound;

    public new event EventHandler InitView;
    public new event EventHandler LoadView;
    public new event EventHandler UnloadView;

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

    public IList<Account> ResultSet { get; set; }

    public GridListType ListType { get; set; }

    public int PageSize 
    {
        get
        {
            return rgAccounts.PageSize;
        }
        set
        {
            rgAccounts.PageSize = value;
        }
    }

    public int VirtualItemCount
    {
        get
        {
            return rgAccounts.VirtualItemCount;
        }
        set
        {
            rgAccounts.VirtualItemCount = value;
        }
    }

    public int CurrentPageIndex
    {
        get
        {
            return rgAccounts.CurrentPageIndex;
        }
        set
        {
            rgAccounts.CurrentPageIndex = value;
        }
    }

    public void LoadResultSet(InsightGridArg args)
    {
        rgAccounts.DataSource = null;
        rgAccounts.PageSize = this.PageSize;
        //rgAccounts.VirtualItemCount = this.VirtualItemCount;
        rgAccounts.DataSource = ResultSet;
        if (args.BindData)
        {
            rgAccounts.DataBind();
        }
    }

    public void NavigateTo(string url)
    {
        HttpContext.Current.Response.Redirect(url);
    }

    public void RebindGrid()
    {
        rgAccounts.PageSize = this.PageSize;
        rgAccounts.Rebind();
    }



    #endregion
}
