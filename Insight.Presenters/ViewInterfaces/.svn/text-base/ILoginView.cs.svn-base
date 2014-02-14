using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters.ViewInterfaces
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
