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
        if (this.LoadView != null)
        {
            this.LoadView(this, EventArgs.Empty);
        }
        if (!IsPostBack)
        {
            if (this.OnGetAccounts != null)
            {
                var args = new InsightGridArg();
                args.BindData = true;
                this.OnGetAccounts(this, args);
            }
        }
    }

    protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
    {
        var args = new InsightGridArg();
        args.BindData = false;
        if (this.OnGetAccounts != null)
        {
            this.OnGetAccounts(this, args);
        }
        LoadAccounts(false);
    }

    protected void ItemCommand(object o, GridCommandEventArgs e)
    { 
        
    }

    #region IAccountListView Members

    public event EventHandler OnAccountSelected;

    public event EventHandler<InsightGridArg> OnGetAccounts;

    public event EventHandler InitView;
    public event EventHandler LoadView;

    public string TestLabel 
    { 
        get 
        { 
            return lblTest.Text; 
        } 
        set 
        { 
            lblTest.Text = value; 
        } 
    }

    public IList<Account> AccountsList { get; set; }

    public void LoadAccounts(bool bindData)
    {
        rgAccounts.DataSource = AccountsList;
        if (bindData)
        {
            rgAccounts.DataBind();
        }
    }



    #endregion
}
