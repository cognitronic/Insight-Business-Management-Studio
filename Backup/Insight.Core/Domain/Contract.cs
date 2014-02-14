using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class Contract : IContract
    {
        public virtual int ID { get; set; }
        public virtual int AccountID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int ServiceLevelAgreementID { get; set; }
        public virtual string ContractNumber { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual int ContractTypeID { get; set; }
        public virtual int ContractHours { get; set; }
        public virtual int ContractHoursUOMID { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
    }
}
