using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Presenters;
using Insight.Web.Utils;
using Insight.Web.Security;
using Insight.Core.Security;
using Insight.Services;
using System.Web;

namespace Insight.Web.Bases
{
    public class BaseMasterPage : System.Web.UI.MasterPage, IView
    {
        public string Message { get; set; }
        public string ViewTitle { get; set; }
        public event EventHandler InitView;
        public event EventHandler LoadView;
        public event EventHandler UnloadView;

        protected T RegisterView<T>() where T : Presenter
        {
            return PresentationManager.RegisterView<T>(typeof(T), this, new WebSessionProvider());
        }

        protected void SelfRegister(System.Web.UI.UserControl control)
        {
            if (control != null && control is IView)
            {
                object[] attributes = control.GetType().GetCustomAttributes(typeof(PresenterTypeAttribute), true);

                if (attributes != null && attributes.Length > 0)
                {
                    foreach (Attribute viewAttribute in attributes)
                    {
                        if (viewAttribute is PresenterTypeAttribute)
                        {
                            PresentationManager.RegisterView((viewAttribute as PresenterTypeAttribute).PresenterType, control as IView, new WebSessionProvider(), new WebSecurityContext());
                            break;
                        }
                    }
                }
            }
        }

        protected override void  OnLoad(EventArgs e)
        {
            if (SessionManager.Current != null)
            {
                BuildNav();
            }
 	         base.OnPreRender(e);
        }

        public void BuildNav()
        {
            var sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var page in new PageServices().GetRootNodes())
            {
                string[] routes = page.URLRoute.ToLower().Split('/');
                if (routes[0] == HttpContext.Current.Request.Url.Segments[1].Replace("/", "").ToLower())
                {
                    sb.Append("<li id='current'>");
                    sb.Append("<a href='");
                    sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
                    sb.Append("/");
                    sb.Append(page.URLRoute);
                    sb.Append("' alt='");
                    sb.Append(page.Name);
                    sb.Append("'>");
                    sb.Append(page.Name);
                    sb.Append("</a>");
                    sb.Append("</li>");
                    //BuildSubNav(page.ID);
                }
                else
                {
                    sb.Append("<li>");
                    sb.Append("<a href='");
                    sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
                    sb.Append("/");
                    sb.Append(page.URLRoute);
                    sb.Append("' alt='");
                    sb.Append(page.Name);
                    sb.Append("'>");
                    if (!string.IsNullOrEmpty(page.IconPath))
                    {
                        sb.Append("<img src='");
                        sb.Append(page.IconPath);
                        sb.Append("' border='0' /> ");
                    }
                    sb.Append(page.Name);
                    sb.Append("</a>");
                    sb.Append("</li>");
                }
            }
            sb.Append("</ul>");
            ApplicationContext.PrimaryNavText = sb.ToString();
        }

        public void BuildSubNav(int parentID)
        {
            var list = new PageServices().GetSubNav(parentID);
            if (list != null)
            {
                var sb = new StringBuilder();
                sb.Append("<ul>");
                foreach (var page in list)
                {
                    sb.Append("<li>");
                    sb.Append("<a href='");
                    sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
                    sb.Append("/");
                    sb.Append(page.URLRoute);
                    sb.Append("' alt='");
                    sb.Append(page.Name);
                    sb.Append("'>");
                    if (!string.IsNullOrEmpty(page.IconPath))
                    {
                        sb.Append("<img src='");
                        sb.Append(page.IconPath);
                        sb.Append("' border='0' /> ");
                    }
                    sb.Append(page.Name);
                    sb.Append("</a>");
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
                ApplicationContext.SubNavText = sb.ToString();
            }
        }
    }
}
