using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class Manufacturer : IManufacturer
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual string ManufacturerName { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Website { get; set; }
        public virtual string Comments { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
