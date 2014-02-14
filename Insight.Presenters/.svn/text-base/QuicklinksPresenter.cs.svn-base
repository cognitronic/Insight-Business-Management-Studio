using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;
using Insight.Services;

namespace Insight.Presenters
{
    public class QuicklinksPresenter : Presenter
    {
        IQuicklinksView _view;

        public QuicklinksPresenter(IQuicklinksView view, 
            ISessionProvider session, 
            ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IQuicklinksView>();
            _view.OnLoadLinks += new EventHandler(_view_OnLoadLinks);
        }

        void _view_OnLoadLinks(object sender, EventArgs e)
        {
            var appview = new PageViewServices().GetPageApplicationViewsByPageIDApplicationViewID(SecurityContextManager.Current.CurrentPage.ID, 9);
            var links = Insight.Services.Utils.JSONSerializationHelper.Deserialize<List<HistoryLink>>(appview.ViewProperties);
            var sb = new StringBuilder();
            foreach (var link in links)
            {
                string s = "";
                if (SessionManager.Current[ResourceStrings.Session_CurrentItem] != null)
                {
                    if (link.URL.Contains("[propurl]"))
                    {
                        s = link.URL.Replace("[propurl]", PropQuickLinkURL(SecurityContextManager.Current.CurrentURL));
                    }
                    else
                    {
                        s = link.URL.Replace("[url]", SecurityContextManager.Current.BaseURL + ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).URL);
                    }
                    
                }
                sb.Append("<div><a href='");
                //sb.Append("/");
                //sb.Append(link.URL);
                sb.Append(s);
                sb.Append("' title='");
                sb.Append(((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name);
                sb.Append("'>");
                sb.Append("<img src='");
                sb.Append(link.IconPath);
                sb.Append("' border='0' /> ");
                sb.Append(link.Text);
                sb.Append("</a></div>");
            }
            _view.QuickLinks = sb.ToString();
        }

        private string PropQuickLinkURL(string url)
        {
            string retVal = "";
            string[] segments = url.Split('/');
            if (segments.Length >= 5)
            {
                for (int i = 0; i < segments.Length; i++)
                {
                    if(i < (segments.Length -2))
                        retVal += segments[i] + "/";
                }
                return retVal.Remove(retVal.Length - 1);
            }
            return url;
        } 
    }
}
