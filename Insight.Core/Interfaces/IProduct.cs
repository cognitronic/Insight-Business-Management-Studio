using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IProduct : IItem, IHasItemType
    {
        ProductType ProductType { get; set; }
        int ProductTypeID { get; set; }
        string PartNumber { get; set; }
        string InternalSKU { get; set; }
        bool IsActive { get; set; }
        int UnitID { get; set; }
        decimal UnitPrice { get; set; }
        decimal RetailPrice { get; set; }
        decimal Markup { get; set; }
        int ManufacturerID { get; set; }
        string Model { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        int QtyInStock { get; set; }
        Manufacturer Manufacturer { get; set; }
    }
}
