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
using Insight.Core.Security;
using Insight.Core.Domain;

[PresenterType(typeof(PageManagerPresenter))]
public partial class Accounts_ContactProperties : AccountsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Page.Title = "Contact Properties - " + ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
        base.LoadViewControls(Master.MainContent, Master.SideBar, Master.ToolBarContainer);
    }
}
