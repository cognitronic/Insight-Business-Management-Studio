using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IQuicklinksView : IView
    {
        string QuickLinks { get; set; }
        event EventHandler OnLoadLinks;
    }
}
