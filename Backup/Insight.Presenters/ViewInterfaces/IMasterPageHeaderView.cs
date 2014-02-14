using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IMasterPageHeaderView : IView
    {
        bool DisplayLoggedOnUser { get; set; }
        bool DisplaySearch { get; set; }
        bool DisplayLogo { get; set; }
        bool DisplaySettingsLinks { get; set; }
        bool DisplayPrimaryNav { get; set; }
        bool DisplaySubNav { get; set; }
        event EventHandler OnSearch;
        event EventHandler OnLogout;
        string PrimaryNavText { get; set; }
        string SubNavText { get; set; }
        string LoggedOnUser { get; set; }
    }
}
