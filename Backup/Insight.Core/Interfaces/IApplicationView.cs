using System;
using System.Collections.Generic;
using System.Linq;
using Insight.Core.Security;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IApplicationView
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Path { get; set; }
        AccessLevels AccessLevel { get; set; }
    }
}
