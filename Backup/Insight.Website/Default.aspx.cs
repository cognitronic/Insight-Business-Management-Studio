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
public partial class _Default : InsightBasePage, IPageManagerView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.Page.Title = "Home page";
        LoadViewControls(Master.MainContent, Master.SideBar, Master.ToolBarContainer);
    }

    private void LoadViewControls(Control mainContent, ContentPlaceHolder sidebarContent, HtmlGenericControl toolbarContainer)
    {
        base.SelfRegister(HttpContext.Current.Handler as Page);
        if (this.OnLoadData != null)
        {
            this.OnLoadData(this, new PageViewArg());
        }

        foreach (var view in MainContentViews)
        {
            Control c = LoadControl(view.ApplicationView.Path);
            mainContent.Controls.Add(c);
        }
        foreach (var sidebar in SideBarViews)
        {
            Control c = LoadControl(sidebar.ApplicationView.Path);
            sidebarContent.Controls.Add(c);
        }

        Control toolbar = LoadControl(ToolBarView.ApplicationView.Path);
        toolbarContainer.Controls.Add(toolbar);
    }

    #region IPageManagerView Members

    public event EventHandler<Insight.Presenters.PageViewArg> OnLoadData;

    private IList<IPageApplicationView> _mainContentViews = new List<IPageApplicationView>();
    public IList<Insight.Core.Interfaces.IPageApplicationView> MainContentViews
    {
        get
        {
            return _mainContentViews;
        }
        set
        {
            _mainContentViews = value;
        }
    }

    private IList<IPageApplicationView> _sideBarViews = new List<IPageApplicationView>();
    public IList<Insight.Core.Interfaces.IPageApplicationView> SideBarViews
    {
        get
        {
            return _sideBarViews;
        }
        set
        {
            _sideBarViews = value;
        }
    }

    public IPageApplicationView ToolBarView
    {
        get;
        set;
    }

    #endregion
}
