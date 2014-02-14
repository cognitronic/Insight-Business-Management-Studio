using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IManufacturer : IItem, IHasItemType
    {
        string ManufacturerName { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Website { get; set; }
        string Comments { get; set; }
        bool IsActive { get; set; }
    }
}
