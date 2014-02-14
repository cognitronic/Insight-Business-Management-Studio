using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IVendor : IItem, IHasItemType
    {
        string VendorName { get; set; }
        bool IsActive { get; set; }
    }
}
