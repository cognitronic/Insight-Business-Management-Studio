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
using Telerik.Web.UI;

[PresenterType(typeof(DashboardToolBarPresenter))]
public partial class Views_DashboardToolBarView : BaseWebUserControl, IDashboardToolBarView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
    }

    protected void ButtonClicked(object o, RadToolBarEventArgs e)
    {
        switch (e.Item.Text)
        {
            case "Refresh":
                if (this.OnRefresh != null)
                {
                    this.OnRefresh(this, EventArgs.Empty);
                }
                break;
        }
    }

    #region IMainToolBarView Members

    public event EventHandler OnRefresh;

    public bool DisplayToolBar
    {
        get
        {
            return mainToolBar.Visible;
        }
        set
        {
            mainToolBar.Visible = value;
        }
    }

    #endregion
}
