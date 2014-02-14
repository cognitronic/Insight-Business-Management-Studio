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
    public class PageManagerPresenter : Presenter
    {
        IPageManagerView _view;

        public PageManagerPresenter(IPageManagerView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IPageManagerView>();
            _view.OnLoadData += new EventHandler<PageViewArg>(_view_OnLoadData);
        }

        void _view_OnLoadData(object sender, PageViewArg e)
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
                            _view.MainContentViews.Add(view);
                            break;
                        case ApplicationViewLayout.TOOLBAR:
                            _view.ToolBarView = view;
                            break;
                        case ApplicationViewLayout.SIDEBAR:
                            _view.SideBarViews.Add(view);
                            break;
                    }
                }
            }
            //_view.MainContentViews = 
        }

    }
}
