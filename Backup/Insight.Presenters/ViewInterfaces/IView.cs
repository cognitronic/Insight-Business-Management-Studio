using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IView
    {
        string Message { get; set; }
        string ViewTitle { get; set; }
        event EventHandler InitView;
        event EventHandler LoadView;
        event EventHandler UnloadView;
    }
}
