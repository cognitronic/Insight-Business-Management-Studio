using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class ProductType : IProductType
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string ProductTypeName { get; set; }
    }
}
