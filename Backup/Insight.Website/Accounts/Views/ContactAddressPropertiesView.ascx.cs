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

[PresenterType(typeof(ContactAddressPropertiesPresenter))]
public partial class Accounts_Views_ContactAddressPropertiesView : BaseWebUserControl, IContactAddressPropertiesView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (this.LoadView != null)
        {
            this.LoadView(this, EventArgs.Empty);
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

    public void NavigateTo(string url)
    {
        HttpContext.Current.Response.Redirect(url);
    }

    public new event EventHandler LoadView;
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

    #region IContactAddress Members

    public int ContactID
    {
        get;
        set;
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
        get { return ItemType.CONTACTADDRESS; }
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

    #region IBasePropertiesView<IContactAddress> Members

    public void LoadItem(Insight.Core.Interfaces.IContactAddress t)
    {
        lblDateCreated.Text = t.DateCreated.ToString();
        lblID.Text = t.ID.ToString();
        lblLastUpdated.Text = t.LastUpdated.ToString();
        tbAddress1.Text = t.Address1;
        tbAddress2.Text = t.Address2;
        tbCity.Text = t.City;
        tbTitle.Text = t.Title;
        tbZip.Text = t.Zip;
        ddlState.SelectedValue = t.State;
        ddlAddressType.SelectedValue = t.AddressTypeID.ToString();
    }

    #endregion

    #region IContactAddress Members


    public ClientContact ContactReference
    {
        get;
        set;
    }

    public int AddressTypeID
    {
        get
        {
            int i = 0;
            if (int.TryParse(ddlAddressType.SelectedValue, out i))
                return i;
            return i;
        }
        set
        {
            int i = (int)value;
            if (i == 0)
                ddlAddressType.SelectedValue = "";
            else
                ddlAddressType.SelectedValue = i.ToString();
        }
    }

    #endregion

    #region IHasAddress Members

    AddressType Insight.Core.Interfaces.IHasAddress.AddressType
    {
        get;
        set;
    }

    #endregion
}
