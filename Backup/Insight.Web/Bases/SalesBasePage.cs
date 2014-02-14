using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web.UI;
using IdeaSeed.Web;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Insight.Core.Security;
using Insight.Web.Security;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Interfaces;

namespace Insight.Web.Bases
{
    [PresenterType(typeof(PageManagerPresenter))]
    public class SalesBasePage : InsightBasePage, IPageManagerView
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(PageLoad);
            base.OnInit(e);
        }

        protected void PageLoad(object o, EventArgs e)
        {
        }

        protected void LoadViewControls(Control mainContent, ContentPlaceHolder sidebarContent, HtmlGenericControl toolbarContainer)
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
}
