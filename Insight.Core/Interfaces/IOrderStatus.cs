using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IOrderStatus : IItem
    {
        string Status { get; set; }
    }
}
