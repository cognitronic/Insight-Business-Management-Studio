using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Security;

namespace Insight.Core.Domain.Interfaces.Services
{
    public interface ISecurityServices
    {
        AuthenticationResponse AuthenticateUser(string userName, string password, string url, ISecurityContext securityContext);
        void Signout();
        void CreateAuthenticationTicket();
    }
}
