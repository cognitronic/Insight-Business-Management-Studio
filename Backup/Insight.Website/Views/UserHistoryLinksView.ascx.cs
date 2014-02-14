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

[PresenterType(typeof(UserHistoryLinksPresenter))]
public partial class Views_UserHistoryLinksView : BaseWebUserControl, IUserHistoryLinksView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.SelfRegister(this);
        if (OnLoadLinks != null)
        {
            this.OnLoadLinks(this, EventArgs.Empty);
        }
    }

    #region IUserHistoryLinksView Members

    public event EventHandler OnLoadLinks;

    public string HistoryLinks
    {
        get
        {
            return portletContent.InnerHtml;
        }
        set
        {
            portletContent.InnerHtml = value;
        }
    }

    #endregion
}
