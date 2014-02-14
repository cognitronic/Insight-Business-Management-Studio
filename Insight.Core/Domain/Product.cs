using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class Product : IProduct
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual string PartNumber { get; set; }
        public virtual string InternalSKU { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int UnitID { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal RetailPrice { get; set; }
        public virtual decimal Markup { get; set; }
        public virtual int ManufacturerID { get; set; }
        public virtual string Model { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual int QtyInStock { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
