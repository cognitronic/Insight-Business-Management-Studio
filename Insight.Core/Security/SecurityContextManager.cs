using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Core.Security
{
    public class SecurityContextManager
    {
        private static ISecurityContext _securityContext;

        private SecurityContextManager() 
        {
            
        }

        public static ISecurityContext Current
        {
            get
            {
                return _securityContext;
            }
            set
            {
                _securityContext = value;
            }
        }
    }
}
