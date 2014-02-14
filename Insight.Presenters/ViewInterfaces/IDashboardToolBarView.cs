using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IDashboardToolBarView : IView
    {
        bool DisplayToolBar { get; set; }
        event EventHandler OnRefresh;
    }
}
