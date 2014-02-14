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

[PresenterType(typeof(AccountPropertiesPresenter))]
public partial class Views_AccountPropertiesView : BaseWebUserControl, IAccountPropertiesView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (this.OnLoad != null)
        {
            this.OnLoad(this, EventArgs.Empty);
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

    #region IAccountPropertiesView Members

    public void LoadAccount(Account account)
    {
        if (account != null)
        {
            this.ID = account.ID;
            this.Name = account.Name;
            this.EmailDomain = account.EmailDomain;
            this.IsActive = account.IsActive;
            this.Phone = account.Phone;
            this.Fax = account.Fax;
            this.ParentAccountID = account.ParentAccountID;
            this.AccountManagerID = account.AccountManagerID;
            this.IndustryTypeID = account.IndustryTypeID;
            this.ServiceLevelAgreementID = account.ServiceLevelAgreementID;
            this.Website = account.Website;
            this.DateCreated = account.DateCreated;
            this.LastUpdated = account.LastUpdated;
        }
        else
        {
            this.IsActive = true;
        }
    }

    public void NavigateTo(string url)
    {
        HttpContext.Current.Response.Redirect(url);
    }

    #endregion

    public new event EventHandler OnLoad;
    public new event EventHandler UnloadView;
    public event EventHandler<InsightLinkButtonArgs> OnAddressEdit;

    #region IAccount Members

    public string Phone
    {
        get
        {
            return tbPhone.Text;
        }
        set
        {
            tbPhone.Text = value;
        }
    }

    public string URL
    {
        get;
        set;
    }

    public string Fax
    {
        get
        {
            return tbFax.Text;
        }
        set
        {
            tbFax.Text = value;
        }
    }

    public string Website
    {
        get
        {
            return tbWebsite.Text;
        }
        set
        {
            tbWebsite.Text = value;
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

    public string EmailDomain
    {
        get
        {
            return tbEmailDomain.Text;
        }
        set
        {
            tbEmailDomain.Text = value;
        }
    }

    public int IndustryTypeID
    {
        get
        {
            int i = 0;
            if(int.TryParse(ddlIndustryType.SelectedValue, out i))
                return i;
            return i;
        }
        set
        {
            int i = value;
            if (i == 0)
                ddlIndustryType.SelectedValue = "";
            else
                ddlIndustryType.SelectedValue = i.ToString();
        }
    }

    public int? ParentAccountID
    {
        get
        {
            int i = 0;
            if (int.TryParse(ddlParentAccount.SelectedValue, out i))
                return i;
            return null;
        }
        set
        {
            if (value != null)
            {
                int i = (int)value;
                ddlParentAccount.SelectedValue = i.ToString();
            }
            else
            {
                ddlParentAccount.SelectedValue = "";
            }
        }
    }

    public int AccountManagerID
    {
        get
        {
            int i = 0;
            if (int.TryParse(ddlAccountManager.SelectedValue, out i))
                return i;
            return i;
        }
        set
        {
            int i = (int)value;
            if (i == 0)
                ddlAccountManager.SelectedValue = "";
            else
                ddlAccountManager.SelectedValue = i.ToString();
        }
    }

    public int? ServiceLevelAgreementID
    {
        get
        {
            int i = 0;
            if (int.TryParse(ddlServiceLevelAgreement.SelectedValue, out i))
                return i;
            return null;
        }
        set
        {
            if (value != null)
            {
                int i = (int)value;
                ddlServiceLevelAgreement.SelectedValue = i.ToString();
            }
            else
            {
                ddlServiceLevelAgreement.SelectedValue = "";
            }
        }
    }

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
        get
        {
            return tbName.Text;
        }
        set
        {
            tbName.Text = value;
        }
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
