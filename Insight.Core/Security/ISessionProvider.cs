using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Security
{
    // This interface abstracts session state so ASP.NET, WinForms, or any other
    // view-based project can use state management without forcing this project
    // to have a direct reference to System.Web.
    public interface ISessionProvider
    {
        object this[string name] { get; set; }
        object this[int index] { get; set; }
    }
}
