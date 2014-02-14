using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class ModuleUser : IModuleUser
    {
        public virtual int ID { get; set; }
        public virtual int ModuleID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int AccessLevel { get; set; }
    }
}
