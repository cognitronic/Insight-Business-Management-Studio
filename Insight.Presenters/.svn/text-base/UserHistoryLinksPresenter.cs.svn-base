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
    public class UserHistoryLinksPresenter : Presenter
    {
        IUserHistoryLinksView _view;

        public UserHistoryLinksPresenter(IUserHistoryLinksView view, 
            ISessionProvider session, 
            ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IUserHistoryLinksView>();
            _view.OnLoadLinks += new EventHandler(_view_OnLoadLinks);
            
        }

        void _view_OnLoadLinks(object sender, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentUser != null && SecurityContextManager.Current.CurrentUser.ID != 0)
            {
                var sb = new StringBuilder();
                foreach (var link in SecurityContextManager.Current.CurrentUser.UserPreferences.HistoryLinks.Reverse())
                {
                    sb.Append("<div><a href='");
                    sb.Append(link.URL);
                    sb.Append("' title='");
                    sb.Append(link.Title);
                    sb.Append("'>");
                    sb.Append("<img src='");
                    sb.Append(link.IconPath);
                    sb.Append("' border='0' /> ");
                    sb.Append(link.Text);
                    sb.Append("</a></div>");
                }
                _view.HistoryLinks = sb.ToString();
            }
        }
    }
}
