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

[PresenterType(typeof(ContactPropertiesPresenter))]
public partial class Accounts_Views_ContactPropertiesView : BaseWebUserControl, IContactPropertiesView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (this.LoadView != null)
        {
            this.LoadView(this, EventArgs.Empty);
        }
    }

    protected void EditEmailClicked(object o, EventArgs e)
    { 
        
    }

    protected void EditAddressClicked(object o, EventArgs e)
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

    #region IBasePropertiesView<Contact> Members

    public void LoadItem(ClientContact c)
    {
        tbAvatarPath.Text = c.AvatarPath;
        tbCellPhone.Text = IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(c.CellPhone);
        tbFirstName.Text = c.FirstName;
        tbHomePhone.Text = IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(c.HomePhone);
        tbLastName.Text = c.LastName;
        tbLocation.Text = c.Location;
        tbTitle.Text = c.Title;
        tbWorkPhone.Text = IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(c.WorkPhone);
        cbIsActive.Checked = c.IsActive;
        cbIsKeyContact.Checked = c.IsKeyContact;
        ddlAccount.SelectedValue = c.AccountID.ToString();
        lblDateCreated.Text = c.DateCreated.ToString();
        lblID.Text = c.ID.ToString();
        lblLastUpdated.Text = c.LastUpdated.ToString();
        tbPrimaryEmail.Text = c.PrimaryEmail;
    }

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

    #region IContact Members

    public string PrimaryEmail
    {
        get
        {
            return tbPrimaryEmail.Text;
        }
        set
        {
            tbPrimaryEmail.Text = value;
        }
    }

    public ItemType ContactType
    {
        get;
        set;
    }

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

    public string FirstName
    {
        get
        {
            return tbFirstName.Text;
        }
        set
        {
            tbFirstName.Text = value;
        }
    }

    public string LastName
    {
        get
        {
            return tbLastName.Text;
        }
        set
        {
            tbLastName.Text = value;
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

    public string WorkPhone
    {
        get
        {
            return tbWorkPhone.Text;
        }
        set
        {
            tbWorkPhone.Text = value;
        }
    }

    public string CellPhone
    {
        get
        {
            return tbCellPhone.Text;
        }
        set
        {
            tbCellPhone.Text = value;
        }
    }

    public string HomePhone
    {
        get
        {
            return tbHomePhone.Text;
        }
        set
        {
            tbHomePhone.Text = value;
        }
    }

    public string Location
    {
        get
        {
            return tbLocation.Text;
        }
        set
        {
            tbLocation.Text = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return cbIsActive.Checked;
        }
        set
        {
            cbIsActive.Checked = value;
        }
    }

    public bool IsKeyContact
    {
        get
        {
            return cbIsKeyContact.Checked;
        }
        set
        {
            cbIsKeyContact.Checked = value;
        }
    }

    public string AvatarPath
    {
        get
        {
            return tbAvatarPath.Text;
        }
        set
        {
            tbAvatarPath.Text = value;
        }
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

    public string URL
    {
        get;
        set;
    }

    public string Name
    {
        get
        {
            return tbFirstName.Text + " " + tbLastName.Text;
        }
        set
        {
        }
    }

    public string Description
    {
        get;
        set;
    }

    public ItemType TypeOfItem
    {
        get { return ItemType.CONTACT; }
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
