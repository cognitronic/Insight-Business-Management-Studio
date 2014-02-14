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
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Services;

[PresenterType(typeof(AddressPropertiesPresenter))]
public partial class Views_AddressPropertiesView : BaseWebUserControl, IAddressPropertiesView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (!IsPostBack)
        {
            if (this.OnLoad != null)
            {
                this.OnLoad(this, EventArgs.Empty);
            }
        }
    }

    protected override void OnUnload(EventArgs e)
    {
        base.OnUnload(e);
        if (this.UnloadView != null)
        {
            this.UnloadView(this, EventArgs.Empty);
        }
    }

    #region IAddressPropertiesView Members

    public void LoadAddress(AccountAddress address)
    {
        if (address == null || address.ID == 0)
        {
            ddlAccount.SelectedValue = address.Description;
        }
        else
        {
            ddlAccount.SelectedValue = address.AccountID.ToString();
        }
        lblDateCreated.Text = address.DateCreated.ToString();
        lblID.Text = address.ID.ToString();
        lblLastUpdated.Text = address.LastUpdated.ToString();
        tbAddress1.Text = address.Address1;
        tbAddress2.Text = address.Address2;
        tbCity.Text = address.City;
        tbTitle.Text = address.Title;
        tbZip.Text = address.Zip;
        ddlAddressType.SelectedValue = address.AddressType;
        ddlState.SelectedValue = address.State;
    }

    public void NavigateTo(string url)
    {
        HttpContext.Current.Response.Redirect(url);
    }

    public new event EventHandler OnLoad;
    public new event EventHandler UnloadView;

    public string ViewTitle
    {
        get
        {
            return lblPropertiesTitle.Text;
        }
        set
        {
            lblPropertiesTitle.Text = value;
        }
    }
    #endregion

    #region IAccountAddress Members

    public int AccountID
    {
        get
        {
            int i = 0;
            if (int.TryParse(ddlAccount.SelectedValue, out i))
                return i;
            return i;
        }
        set
        {
            int i = (int)value;
            if (i == 0)
                ddlAccount.SelectedValue = "";
            else
                ddlAccount.SelectedValue = i.ToString();
        }
    }

    public string Title
    {
        get
        {
            return tbTitle.Text;
        }
        set
        {
            tbTitle.Text = value;
        }
    }

    public string AddressType
    {
        get
        {
            return ddlAddressType.SelectedValue;
        }
        set
        {
            ddlAddressType.SelectedValue = value;
        }
    }

    public string Address1
    {
        get
        {
            return tbAddress1.Text;
        }
        set
        {
            tbAddress1.Text = value;
        }
    }

    public string Address2
    {
        get
        {
            return tbAddress2.Text;
        }
        set
        {
            tbAddress2.Text = value;
        }
    }

    public string City
    {
        get
        {
            return tbCity.Text;
        }
        set
        {
            tbCity.Text = value;
        }
    }

    public string State
    {
        get
        {
            return ddlState.SelectedValue;
        }
        set
        {
            ddlState.SelectedValue = value;
        }
    }

    public string Zip
    {
        get
        {
            return tbZip.Text;
        }
        set
        {
            tbZip.Text = value;
        }
    }

    public string URL
    {
        get;
        set;
    }
    #endregion

    #region IItem Members

    public new int ID
    {
        get
        {
            int i = 0;
            if (int.TryParse(lblID.Text, out i))
                return i;
            return i;
        }
        set
        {
            int i = value;
            lblID.Text = i.ToString();
        }
    }

    public string Name
    {
        get;
        set;
    }

    public string Description
    {
        get;
        set;
    }

    public ItemType TypeOfItem
    {
        get { return ItemType.ACCOUNT; }
    }

    #endregion

    #region IAuditable Members

    public int EnteredBy
    {
        get;
        set;
    }

    public int ChangedBy
    {
        get;
        set;
    }

    public DateTime DateCreated
    {
        get
        {
            return DateTime.Parse(lblDateCreated.Text);
        }
        set
        {
            lblDateCreated.Text = value.ToString();
        }
    }

    public DateTime LastUpdated
    {
        get
        {
            return DateTime.Parse(lblLastUpdated.Text);
        }
        set
        {
            lblLastUpdated.Text = value.ToString();
        }
    }

    public bool MarkedForDeletion
    {
        get;
        set;
    }

    public object ItemReference
    {
        get;
        set;
    }

    #endregion
}
