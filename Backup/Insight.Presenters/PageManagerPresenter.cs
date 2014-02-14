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
    public class PageManagerPresenter : Presenter
    {
        IPageManagerView _pageManagerView;

        public PageManagerPresenter(IPageManagerView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _pageManagerView = base.GetView<IPageManagerView>();
            _pageManagerView.OnLoadData += new EventHandler<PageViewArg>(_pageManagerView_OnLoadData);
        }

        void _pageManagerView_OnLoadData(object sender, PageViewArg e)
        {
            var views = new PageViewServices().GetPageApplicationViewsByPageID(this.SecurityContext.CurrentPage.ID);
            var list = new List<ApplicationView>();
            foreach (var view in views)
            {
                if (view.ApplicationView != null)
                {
                    switch (view.ViewLayout)
                    { 
                        case ApplicationViewLayout.MAIN:
                            _pageManagerView.MainContentViews.Add(view);
                            break;
                        case ApplicationViewLayout.TOOLBAR:
                            _pageManagerView.ToolBarView = view;
                            break;
                        case ApplicationViewLayout.SIDEBAR:
                            _pageManagerView.SideBarViews.Add(view);
                            break;
                    }
                }
            }
            //_pageManagerView.MainContentViews = 
        }

    }
}
