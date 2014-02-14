using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IIndustryType
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
