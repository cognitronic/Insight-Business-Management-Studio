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
using Insight.Web.Utils;
using Insight.Presenters.ViewInterfaces;
using Insight.Presenters;
using Insight.Web.Security;
using Insight.Core.Security;
using Insight.Services;
using Insight.Core.Domain;
using Insight.Core.Interfaces;

namespace Insight.Web.Bases
{
    public class InsightBasePage : System.Web.UI.Page, IView
    {
        #region Declarations
        protected const string TITLE_TEXT = "{~ Insight Business Management Studio ~} ";

        public event EventHandler InitView;
        public event EventHandler LoadView;
        public event EventHandler UnloadView;
        #endregion

        #region Properties
        public string ViewTitle { get; set; }
        public string Message { get; set; }
        public PageViewArg CurrentPageViewArg { get; set; }
        
        #endregion

        #region Events

        #region Overriden Events
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!HttpPageHelper.IsValidRequest)
            {
                HttpContext.Current.Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute(ResourceStrings.Page_Default));
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Security Checking
            if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser.ID == 0)
            {
                new WebSecurityContext().SignOutUser();
            }

            if (HttpPageHelper.CurrentPage != null)
            {
                if (SecurityContextManager.Current != null)
                {
                    SecurityContextManager.Current.CurrentPage = HttpPageHelper.CurrentPage;
                    SecurityContextManager.Current.CurrentAccessLevel = (AccessLevels)new SecurityServices().GetCurrentPageAccessLevel(SecurityContextManager.Current);
                    if (HttpPageHelper.CurrentItem != null)
                        SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateUserHistoryLinks();
        }

        protected override void  OnSaveStateComplete(EventArgs e)
        {
 	         base.OnSaveStateComplete(e);
             try
             {
                 if (SecurityContextManager.Current.CurrentURL != SecurityContextManager.Current.BaseURL + HttpContext.Current.Request.UrlReferrer.AbsolutePath)
                 {
                     SecurityContextManager.Current.PreviousURL = SecurityContextManager.Current.BaseURL + HttpContext.Current.Request.UrlReferrer.AbsolutePath;
                 }
             }
             catch (Exception exc)
             { 
                
             }
        }

        #endregion


        #endregion

        #region Methods

        protected void ShowModal(Control page, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "key", "ShowModal('" + message.Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("'", "") + "');", true);
        }

        protected void UpdateUserHistoryLinks()
        { 
            var link = new HistoryLink();
            if (HttpPageHelper.CurrentItem.Name.Length > 20)
            {
                link.Text = HttpPageHelper.CurrentItem.Name.Substring(0, 20) + "...";
            }
            else
            {
                link.Text = HttpPageHelper.CurrentItem.Name;
            }
            link.Title = HttpPageHelper.CurrentItem.Name;
            link.URL = HttpContext.Current.Request.Url.AbsoluteUri;
            link.IconPath = ResourceStrings.Icon_HistoryLink;
            if (SecurityContextManager.Current.CurrentUser.UserPreferences == null)
            {
                SecurityContextManager.Current.CurrentUser.UserPreferences = new UserPreferences();
            }
            //Only add the link if it's not already in the collection
            bool exists = false;
            foreach (var l in ((List<HistoryLink>)SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks))
            {
                if (l.URL == link.URL)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                ((List<HistoryLink>)SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks).Add(link);
            }
            //if (link.URL != ((List<HistoryLink>)SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks)[((List<HistoryLink>)SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks).Count - 1].URL)
            //{
            //    ((List<HistoryLink>)SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks).Add(link);
            //}
            //Keeps the history link collection at 10 items.
            if (SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks.Count > 10)
            {
                SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks.RemoveAt(0);
            }
        }

        #endregion

        #region MVP Hookup Code
        protected T RegisterView<T>() where T : Presenter
        {
            return PresentationManager.RegisterView<T>(typeof(T), this, new WebSessionProvider());
        }

        protected void SelfRegister(System.Web.UI.Page page)
        {
            if (page != null && page is IView)
            {
                object[] attributes = page.GetType().GetCustomAttributes(typeof(PresenterTypeAttribute), true);

                if (attributes != null && attributes.Length > 0)
                {
                    foreach (Attribute viewAttribute in attributes)
                    {
                        if (viewAttribute is PresenterTypeAttribute)
                        {
                            PresentationManager.RegisterView((viewAttribute as PresenterTypeAttribute).PresenterType, page as IView, new WebSessionProvider(), new WebSecurityContext());
                            break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
