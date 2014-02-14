using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IOrderDetail : IItem, IHasItemType
    {
        int OrderID { get; set; }
        int ProductID { get; set; }
        int Qty { get; set; }
        DateTime DueDate { get; set; }
        DateTime ETA { get; set; }
        decimal Cost { get; set; }
        decimal MarkUp { get; set; }
        int MarkUpType { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        string TrackingNumber { get; set; }
        int VendorID { get; set; }
        bool Received { get; set; }
        string Notes { get; set; }
        decimal ShippingCost { get; set; }
        decimal ShippingMarkup { get; set; }
        decimal Tax { get; set; }
        string VendorOrderNumber { get; set; }
        Order Order { get; set; }
        Product Product { get; set; }

    }
}
