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
using Insight.Core.Domain.Interfaces;
using System.Web.UI.HtmlControls;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Website.Views;

namespace Insight.Website.UtilityPages
{
    [PresenterType(typeof(PageManagerPresenter))]
    public partial class FilterViews : InsightBasePage, IPageManagerView
    {
        public FilterViews()
        {
            MessageBus<InsightLinkButtonArgs>.MessageReceived += new EventHandler<InsightLinkButtonArgs>(FilterViews_MessageReceived);
        }

        bool createAgain = false;
        bool _justDeleted = false;
        private bool JustDeleted
        {
            get
            {
                if (SessionManager.Current["justDeleted"] != null)
                    return (bool)SessionManager.Current["justDeleted"];
                SessionManager.Current["justDeleted"] = _justDeleted;
                return (bool)SessionManager.Current["justDeleted"];
            }
            set
            {
                _justDeleted = value;
                SessionManager.Current["justDeleted"] = _justDeleted;
            }
        }

        IList<FilterOptionsCollectionView> OptionControls
        {
            get
            {
                if (SessionManager.Current["controls"] != null)
                    return (IList<FilterOptionsCollectionView>)SessionManager.Current["controls"];
                else
                    SessionManager.Current["controls"] = new List<FilterOptionsCollectionView>();
                return (IList<FilterOptionsCollectionView>)SessionManager.Current["controls"];
            }
            set
            {
                SessionManager.Current["controls"] = value;
            }
        }

        IList<FilterOptionsCollectionView> OrControls
        {
            get
            {
                if (SessionManager.Current["ORcontrols"] != null)
                    return (IList<FilterOptionsCollectionView>)SessionManager.Current["ORcontrols"];
                else
                    SessionManager.Current["ORcontrols"] = new List<FilterOptionsCollectionView>();
                return (IList<FilterOptionsCollectionView>)SessionManager.Current["ORcontrols"];
            }
            set
            {
                SessionManager.Current["ORcontrols"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = SecurityContextManager.Current.CurrentPage.Title;
            LoadViewControls(Master.MainContent, Master.SideBar, Master.ToolBarContainer);
            if (!IsPostBack)
            {
                createAgain = true;
                BuildCondition(null, true, DateTime.Now.Ticks.ToString());
                CreateUserControls(true);
                BuildCondition(null, false, DateTime.Now.Ticks.ToString());
                CreateUserControls(false);
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            System.Web.UI.MasterPage m = Master;
            Control control = GetPostBackControl(this);
            if (control != null)
            {
                if ((control.ClientID == (lbAddAndCondtion.ClientID) || createAgain) || control.ID.Contains("options"))
                {
                    createAgain = true;
                    CreateUserControls(true);
                }

                if ((control.ClientID == (lbOrCondition.ClientID) || createAgain) || control.ID.Contains("orConditions"))
                {
                    createAgain = true;
                    CreateUserControls(false);
                }
            }
        }

        void FilterViews_MessageReceived(object sender, InsightLinkButtonArgs e)
        {
            var lb = sender as LinkButton;
            if (e.ObjectName.Contains("option"))
            {
                for (int i = OptionControls.Count - 1; i >= 0; i--)
                {
                    if (OptionControls[i].ID == lb.Parent.ID)
                    {
                        OptionControls.RemoveAt(i);
                    }
                }
            }
            else
            {
                for (int i = OrControls.Count - 1; i >= 0; i--)
                {
                    if (OrControls[i].ID == lb.Parent.ID)
                    {
                        OrControls.RemoveAt(i);
                    }
                }
            }
            ((FilterOptionsCollectionView)lb.Parent).Visible = false;
            JustDeleted = true;
        }

        protected void AddAndConditionClicked(object o, EventArgs e)
        {
            BuildCondition(null, true, DateTime.Now.Ticks.ToString());
            if (JustDeleted)
            {
                //BuildCondition(null, true, (DateTime.Now.Ticks + 1).ToString());
            }
            JustDeleted = false;
        }

        protected void AddOrConditionClicked(object o, EventArgs e)
        {
            BuildCondition(null, false, DateTime.Now.Ticks.ToString());
            if (JustDeleted)
            {
                BuildCondition(null, false, (DateTime.Now.Ticks + 1).ToString());
            }
            JustDeleted = false;
        }

        private void LoadViewControls(Control mainContent, ContentPlaceHolder sidebarContent, HtmlGenericControl toolbarContainer)
        {
            base.SelfRegister(HttpContext.Current.Handler as System.Web.UI.Page);
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

        protected override void OnUnload(EventArgs e)
        {
            MessageBus<InsightLinkButtonArgs>.MessageReceived -= new EventHandler<InsightLinkButtonArgs>(FilterViews_MessageReceived);
            base.OnUnload(e);
        }

        #region IPageManagerView Members

        public event EventHandler<Insight.Presenters.PageViewArg> OnLoadData;

        private IList<IPageApplicationView> _mainContentViews = new List<IPageApplicationView>();
        public IList<Insight.Core.Domain.Interfaces.IPageApplicationView> MainContentViews
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
        public IList<Insight.Core.Domain.Interfaces.IPageApplicationView> SideBarViews
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

        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }

        protected Control GetPostBackControl(System.Web.UI.Page page)
        {
            Control control = null;
            string ctrlname = Page.Request.Params["__EVENTTARGET"];
            if (ctrlname != null && ctrlname != String.Empty)
            {
                if (ctrlname.Split('$')[2].Contains("options") || ctrlname.Split('$')[2].Contains("orConditions"))
                {
                    var c = new Control();
                    c.ID = ctrlname;
                    return c;
                }
                else
                {
                    control = FindControlRecursive(page, ctrlname.Split('$')[2]);
                }
            }
            else
            {
                string ctrlStr = String.Empty;
                Control c = null;
                foreach (string ctl in Page.Request.Form)
                {
                    if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                    {
                        ctrlStr = ctl.Substring(0, ctl.Length - 2);
                        c = page.FindControl(ctrlStr);
                    }
                    else
                    {
                        c = page.FindControl(ctl);
                    }
                    if (c is System.Web.UI.WebControls.CheckBox ||
                    c is System.Web.UI.WebControls.CheckBoxList)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        protected void CreateUserControls(bool isAndCondition)
        {
            try
            {
                if (createAgain && phConditions != null)
                {
                    if (isAndCondition)
                    {
                        if (OptionControls != null && OptionControls.Count > 0)
                        {
                            phConditions.Controls.Clear();
                            foreach (var c in OptionControls)
                            {
                                BuildCondition(c, true, DateTime.Now.Ticks.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (OrControls != null && OrControls.Count > 0)
                        {
                            phOrConditions.Controls.Clear();
                            foreach (var c in OrControls)
                            {
                                BuildCondition(c, false, DateTime.Now.Ticks.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BuildCondition(FilterOptionsCollectionView c, bool isAndCondition, string controlID)
        {
            if (isAndCondition)
            {
                FilterOptionsCollectionView foc = new FilterOptionsCollectionView();
                foc = Page.LoadControl("~/Views/FilterOptionsCollectionView.ascx") as FilterOptionsCollectionView;
                if (c == null)
                {
                    OptionControls.Add((FilterOptionsCollectionView)foc);
                    foc.ID = "options" + controlID;
                }
                else
                    foc.ID = c.ID;
                foc.Visible = true;
                phConditions.Controls.Add(foc);
            }
            else
            {
                FilterOptionsCollectionView foc = new FilterOptionsCollectionView();
                foc = Page.LoadControl("~/Views/FilterOptionsCollectionView.ascx") as FilterOptionsCollectionView;
                if (c == null)
                {
                    OrControls.Add((FilterOptionsCollectionView)foc);
                    foc.ID = "orConditions" + controlID;
                }
                else
                    foc.ID = c.ID;
                foc.Visible = true;
                phOrConditions.Controls.Add(foc);
            }
        }
    }
}