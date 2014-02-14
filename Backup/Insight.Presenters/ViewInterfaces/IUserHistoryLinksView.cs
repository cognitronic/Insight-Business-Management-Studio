using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IUserHistoryLinksView : IView
    {
        string HistoryLinks { get; set; }
        event EventHandler OnLoadLinks;
    }
}
