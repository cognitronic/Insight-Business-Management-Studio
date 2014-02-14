using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Web.Utils;

[PresenterType(typeof(MasterPageHeaderPresenter))]
public partial class Views_MasterPageHeaderView : BaseWebUserControl, IMasterPageHeaderView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (this.LoadView != null)
        {
            this.LoadView(this, EventArgs.Empty);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void SearchClicked(object o, EventArgs e)
    {
        if (this.OnSearch != null)
        {
            this.OnSearch(this, EventArgs.Empty);
        }
    }

    protected void LogoutClicked(object o, EventArgs e)
    {
        if (this.OnLogout != null)
        {
            this.OnLogout(this, EventArgs.Empty);
        }
    }

    #region IMasterPageHeaderView Members

    public bool DisplayLoggedOnUser
    {
        get
        {
            return loggedinuser.Visible;
        }
        set
        {
            loggedinuser.Visible = value;
        }
    }

    public bool DisplaySearch
    {
        get
        {
            return headersearch.Visible;
        }
        set
        {
            headersearch.Visible = value;
        }
    }

    public bool DisplayLogo
    {
        get
        {
            return logo.Visible;
        }
        set
        {
            logo.Visible = value;
        }
    }

    public bool DisplaySettingsLinks
    {
        get
        {
            return settingsLinks.Visible;
        }
        set
        {
            settingsLinks.Visible = value;
        }
    }

    public bool DisplayPrimaryNav
    {
        get
        {
            return primarynav.Visible;
        }
        set
        {
            primarynav.Visible = value;
        }
    }

    public bool DisplaySubNav
    {
        get
        {
            return subnav.Visible;
        }
        set
        {
            subnav.Visible = value;
        }
    }

    public string PrimaryNavText
    {
        get
        {
            return primarynav.InnerHtml;
        }
        set
        {
            primarynav.InnerHtml = value;
        }
    }

    public string SubNavText
    {
        get
        {
            return subnav.InnerHtml;
        }
        set
        {
            subnav.InnerHtml = value;
        }
    }

    public string LoggedOnUser
    {
        get
        {
            return lblCurrentUser.Text;
        }
        set
        {
            lblCurrentUser.Text = value;
        }
    }

    public void BuildMainNav()
    { 
    
    }
    public event EventHandler OnSearch;
    public event EventHandler OnLogout;
    public event EventHandler LoadView;

    #endregion
}
