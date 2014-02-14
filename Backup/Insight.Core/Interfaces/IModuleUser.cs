using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IModuleUser
    {
        int ID { get; set; }
        int ModuleID { get; set; }
        int UserID { get; set; }
        int AccessLevel { get; set; }
    }
}
