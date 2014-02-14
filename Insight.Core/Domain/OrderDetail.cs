using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class OrderDetail : IOrderDetail
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual int OrderID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int Qty { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime ETA { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal MarkUp { get; set; }
        public virtual int MarkUpType { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual string TrackingNumber { get; set; }
        public virtual int VendorID { get; set; }
        public virtual bool Received { get; set; }
        public virtual string Notes { get; set; }
        public virtual decimal ShippingCost { get; set; }
        public virtual decimal ShippingMarkup { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual string VendorOrderNumber { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
