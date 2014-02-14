using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IProductType : IItem
    {
        string ProductTypeName { get; set; }
    }
}
