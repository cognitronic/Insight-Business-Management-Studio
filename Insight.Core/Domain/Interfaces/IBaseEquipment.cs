using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces
{
    public interface IBaseEquipment : IAuditable, IItem
    {
        int EquipmentTypeID { get; set; }
        string SerializedProperties { get; set; }

    }
}
