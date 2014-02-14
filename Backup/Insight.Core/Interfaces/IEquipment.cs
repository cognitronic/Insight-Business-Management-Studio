using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IEquipment : IAuditable, IItem
    {
        int EquipmentTypeID { get; set; }
        string SerializedProperties { get; set; }

    }
}
