using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Core.Security;

namespace Insight.Core.Security
{
    public interface ISecurityContext
    {
        bool IsAuthenticated { get; set; }
        Module CurrentModule { get; set; }
        User CurrentUser { get; set; }
        Page CurrentPage { get; set; }
        string BaseURL { get; set; }
        string CurrentURL { get; }
        string PreviousURL { get; set; }
        AccessLevels CurrentAccessLevel { get; set; }
        event EventHandler SignOut;
        void SignOutUser();
    }
}
