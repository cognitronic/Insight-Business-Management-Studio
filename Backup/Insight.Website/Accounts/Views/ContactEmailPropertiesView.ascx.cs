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

[PresenterType(typeof(ContactEmailPropertiesPresenter))]
public partial class Accounts_Views_ContactEmailPropertiesView : BaseWebUserControl, IContactEmailPropertiesView
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

    #region IBasePropertiesView<IContactEmail> Members

    public void LoadItem(Insight.Core.Interfaces.IContactEmail t)
    {
        tbEmail.Text = t.Email;
        ddlEmailType.SelectedValue = t.EmailTypeID.ToString();
        lblDateCreated.Text = t.DateCreated.ToString();
        lblLastUpdated.Text = t.LastUpdated.ToString();
        lblID.Text = t.ID.ToString();
    }

    public void NavigateTo(string url)
    {
        HttpContext.Current.Response.Redirect(url);
    }

    #endregion

    public new event EventHandler LoadView;
    public new event EventHandler UnloadView;

    #region IContactEmail Members

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

    public int ContactID
    {
        get;
        set;
    }

    public string Email
    {
        get
        {
            return tbEmail.Text;
        }
        set
        {
            tbEmail.Text = value;
        }
    }

    public int EmailTypeID
    {
        get
        {
            int i = 0;
            if (int.TryParse(ddlEmailType.SelectedValue, out i))
                return i;
            return i;
        }
        set
        {
            int i = (int)value;
            if (i == 0)
                ddlEmailType.SelectedValue = "";
            else
                ddlEmailType.SelectedValue = i.ToString();
        }
    }

    public ClientContact ContactReference
    {
        get;
        set;
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

    #endregion

    #region IItem Members


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
        get { return ItemType.CONTACTEMAIL; }
    }

    public object ItemReference
    {
        get;
        set;
    }

    public string URL
    {
        get;
        set;
    }

    #endregion
}
