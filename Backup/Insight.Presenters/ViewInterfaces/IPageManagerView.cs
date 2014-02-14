using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IPageManagerView : IView
    {
        event EventHandler<PageViewArg> OnLoadData;
        IList<IPageApplicationView> MainContentViews { get; set; }
        IList<IPageApplicationView> SideBarViews { get; set; }
        IPageApplicationView ToolBarView { get; set; }
    }
}
