using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;

namespace Insight.Presenters.ViewInterfaces.UtilityPages
{
    public interface ILoginView : IView
    {
        string UserName { get; }
        string Password { get; }
        void LoginSuccessful();
        void LoginFailed();
        event EventHandler OnLogin;
    }
}
