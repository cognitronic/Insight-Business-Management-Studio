using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;
using Insight.Core.Domain;

namespace Insight.Core.Domain
{
    public class OrderStatus : IOrderStatus
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; }
    }
}
