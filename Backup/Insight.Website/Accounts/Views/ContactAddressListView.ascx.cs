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
using System.Data;
using IdeaSeed.Core.Utils;
using System.Text;
using System.IO;
using System.Configuration;
using Insight.Core.Interfaces;

[PresenterType(typeof(ContactAddressListPresenter))]
public partial class Accounts_Views_ContactAddressListView : BaseWebUserControl, IContactAddressListView
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

    protected void DetailsNeedDataSource(object o, RadListViewNeedDataSourceEventArgs e)
    {
        var args = new InsightGridArg();
        args.BindData = false;
        args.ListType = this.ListType;
        if (this.OnGetItems != null)
        {
            this.OnGetItems(this, args);
        }
    }

    protected void ItemCommand(object o, GridCommandEventArgs e)
    {

    }

    protected void ItemDataBound(object o, GridItemEventArgs e)
    {
        //if (e.Item is GridEditableItem)
        //{
        //    var name = e.Item.FindControl("lblAccount") as IdeaSeed.Web.UI.Label;
        //    var lb = e.Item.FindControl("lbEdit") as IdeaSeed.Web.UI.LinkButton;
        //    if (name != null)
        //    {
        //        if (this.OnItemsDataBound != null)
        //        {
        //            var args = new InsightGridItemEventArgs();
        //            args.Item = ((ClientContact)e.Item.DataItem);
        //            this.OnItemsDataBound(this, args);
        //        }
        //        name.Text = this.AccountName;
        //        lb.Attributes.Add("accountname", this.AccountName);
        //    }
        //}
    }

    protected void DetailsItemDataBound(object o, RadListViewItemEventArgs e)
    {
        //if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
        //{
        //    var detailContact = e.Item.FindControl("lblDetailContactType") as IdeaSeed.Web.UI.Label;
        //    var detailAccount = e.Item.FindControl("lblDetailAccountName") as IdeaSeed.Web.UI.Label;
        //    var avatar = e.Item.FindControl("imgContact") as Image;
        //    if (detailContact != null)
        //    {
        //        if (this.OnItemsDataBound != null)
        //        {
        //            var args = new InsightGridItemEventArgs();
        //            args.Item = ((ClientContact)((RadListViewDataItem)e.Item).DataItem);
        //            this.OnItemsDataBound(this, args);
        //        }
        //        detailAccount.Text = this.AccountName;
        //    }

        //    if (avatar != null)
        //    {
        //        if (!string.IsNullOrEmpty(((ClientContact)((RadListViewDataItem)e.Item).DataItem).AvatarPath))
        //        {
        //            avatar.ImageUrl = ResourceStrings.Contact_AvatarPath + ((ClientContact)((RadListViewDataItem)e.Item).DataItem).AvatarPath;
        //        }
        //        else
        //        {
        //            avatar.ImageUrl = ResourceStrings.NoImageFound;
        //        }
        //    }
        //}
    }

    protected void ViewItemClicked(object o, EventArgs e)
    {
        var lb = o as IdeaSeed.Web.UI.LinkButton;
        var args = new InsightLinkButtonArgs();
        args.ObjectID = Convert.ToInt32(lb.Attributes["itemid"]);
        args.ObjectName = lb.Attributes["accountname"];
        if (OnItemSelected != null)
        {
            OnItemSelected(this, args);
        }
    }

    #region IContactAddressListView Members

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

    public string AccountName
    {
        get;
        set;
    }

    #endregion

    #region IBaseListView<ContactAddress> Members

    public IList<IContactAddress> ResultSet
    {
        get;
        set;
    }

    public void LoadResultSet(InsightGridArg args)
    {
        if (args.ListType == GridListType.LIST)
        {
            rgList.Visible = true;
            dlDetails.Visible = false;
            dlDetails.DataSource = null;
            rgList.DataSource = null;
            rgList.PageSize = this.PageSize;
            rgList.DataSource = ResultSet;
            if (args.BindData)
            {
                rgList.DataBind();
            }
        }
        else
        {
            rgList.Visible = false;
            dlDetails.Visible = true;
            dlDetails.DataSource = null;
            rgList.DataSource = null;
            dlDetails.PageSize = this.PageSize;
            dlDetails.DataSource = ResultSet;
            dlDetails.DataBind();
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

    public GridListType ListType { get; set; }

    #endregion
}
