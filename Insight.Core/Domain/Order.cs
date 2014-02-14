using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;
using Insight.Core.Domain;

namespace Insight.Core.Domain
{
    public class Order : IOrder
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual int OrderStatusID { get; set; }
        public virtual int AccountID { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual bool IsTaxExempt { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual string Notes { get; set; }
        public virtual int AccountContactID { get; set; }
        public virtual int RequestedBy { get; set; }
        public virtual string ClientPO { get; set; }
        public virtual decimal TotalCost { get; set; }
        public virtual decimal TotalSale { get; set; }
        public virtual decimal TotalProfit { get; set; }
        public virtual string Title { get; set; }
        public virtual Account Account { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
        public virtual User RequestedByUser { get; set; }
        public virtual OrderStatus Status { get; set; }
    }
}
