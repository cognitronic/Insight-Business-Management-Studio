using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using IdeaSeed.Web.UI;
using Insight.Web.Bases;
using Insight.Core.Domain;
using Insight.Web.Controls;
using IdeaSeed.Core.Utils;

namespace Insight.Website.Views
{
    [ViewStateModeById]
    [PresenterType(typeof(UserListPresenter))]
    public partial class UserListView : BaseWebUserControl, IUserListView
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
            //            args.Item = ((Contact)e.Item.DataItem);
            //            this.OnItemsDataBound(this, args);
            //        }
            //        name.Text = this.AccountName;
            //        lb.Attributes.Add("accountname", this.AccountName);
            //    }
            //}
        }

        protected void DetailsItemDataBound(object o, RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
            {
                var lb = e.Item.FindControl("lbDetailViewItem") as IdeaSeed.Web.UI.LinkButton;
                var avatar = e.Item.FindControl("imgUser") as Telerik.Web.UI.RadBinaryImage;
                if (lb != null)
                {
                    if (this.OnItemsDataBound != null)
                    {
                        var args = new InsightGridItemEventArgs();
                        args.Item = ((User)((RadListViewDataItem)e.Item).DataItem);
                        this.OnItemsDataBound(this, args);
                    }
                }

                if (avatar != null)
                {
                    if (!string.IsNullOrEmpty(((User)((RadListViewDataItem)e.Item).DataItem).Avatar))
                    {
                        avatar.ImageUrl = ((User)((RadListViewDataItem)e.Item).DataItem).Avatar;
                    }
                    else
                    {
                        avatar.ImageUrl = ResourceStrings.NoImageFound;
                    }
                }
            }
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

        #region IBaseListView<Contact> Members

        public string ViewTitle
        {
            get
            {
                return lblViewTitle.Text;
            }
            set
            {
                lblViewTitle.Text = value;
            }
        }

        public IList<User> ResultSet
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
                dlDetails.Visible = true;
                dlDetails.DataSource = null;
                rgList.DataSource = null;
                dlDetails.PageSize = this.PageSize;
                dlDetails.DataSource = ResultSet;
                dlDetails.DataBind();
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

        public GridListType ListType { get; set; }

        #endregion
    }
}