using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Insight.Presenters;
using Insight.Presenters.UtilityPages;
using Insight.Presenters.ViewInterfaces.UtilityPages;

[PresenterType(typeof(LoginPresenter))]
public partial class Views_LoginView : BaseWebUserControl, ILoginView
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
            lblLoginMessage.Visible = false;
        }
    }

    protected void LoginClicked(object o, EventArgs e)
    {
        if (this.OnLogin != null)
        {
            this.OnLogin(this, EventArgs.Empty);
        }
    }

    protected void ForgotPasswordClicked(object o, EventArgs e)
    {
        Response.Redirect("~/ForgotPassword");
    }

    #region ILoginView Members
    public event EventHandler OnLogin;
    public event EventHandler LoadView;

    string ILoginView.UserName
    {
        get { return tbUsername.Text; }
    }

    string ILoginView.Password
    {
        get { return this.tbPassword.Text; }
    }

    void ILoginView.LoginSuccessful()
    {
        Response.Redirect("Home");
    }

    void ILoginView.LoginFailed()
    {
        lblLoginMessage.Visible = true;
        lblLoginMessage.Text = "Invalid username or password.  Please try again.";
    }

    #endregion
}
