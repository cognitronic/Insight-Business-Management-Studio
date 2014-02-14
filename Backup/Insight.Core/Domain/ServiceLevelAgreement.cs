using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class ServiceLevelAgreement : IServiceLevelAgreement
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }

        public ServiceLevelAgreement()
        {
            this.TypeOfItem = ItemType.SERVICELEVELAGREEMENT;
        }
    }
}
