using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Interfaces;
using System.Web.UI.HtmlControls;

[PresenterType(typeof(PageManagerPresenter))]
public partial class Accounts_AccountsList : AccountsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Page.Title = "Accounts List";
        base.LoadViewControls(Master.MainContent, Master.SideBar, Master.ToolBarContainer);
    }
}
