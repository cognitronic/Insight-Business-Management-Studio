using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Services;

namespace Insight.Presenters
{
    public class QuicklinksPresenter : Presenter
    {
        IQuicklinksView _linksView;

        public QuicklinksPresenter(IQuicklinksView view, 
            ISessionProvider session, 
            ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _linksView = base.GetView<IQuicklinksView>();
            _linksView.OnLoadLinks += new EventHandler(_linksView_OnLoadLinks);
        }

        void _linksView_OnLoadLinks(object sender, EventArgs e)
        {
            var appview = new PageViewServices().GetPageApplicationViewsByPageIDApplicationViewID(SecurityContextManager.Current.CurrentPage.ID, 9);
            var links = Insight.Core.Utils.JSONSerializationHelper.Deserialize<List<HistoryLink>>(appview.ViewProperties);
            var sb = new StringBuilder();
            foreach (var link in links)
            {
                string s = "";
                if (SessionManager.Current[ResourceStrings.Session_CurrentItem] != null)
                {
                    s = link.URL.Replace("[url]", ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).URL);
                }
                sb.Append("<div><a href='");
                sb.Append(SecurityContextManager.Current.BaseURL);
                //sb.Append("/");
                //sb.Append(link.URL);
                sb.Append(s);
                sb.Append("' title='");
                sb.Append(link.URL);
                sb.Append("'>");
                sb.Append("<img src='");
                sb.Append(link.IconPath);
                sb.Append("' border='0' /> ");
                sb.Append(link.Text);
                sb.Append("</a></div>");
            }
            _linksView.QuickLinks = sb.ToString();
        }
    }
}
