using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    [Serializable]
    public class Account : IAccount
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        public virtual string Description { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Website { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string EmailDomain { get; set; }
        public virtual int IndustryTypeID { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual int? ParentAccountID { get; set; }
        public virtual int AccountManagerID { get; set; }
        public virtual int? ServiceLevelAgreementID { get; set; }
        public virtual Account ParentAccount { get; set; }
        public virtual User AccountManager { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        //TODO: Create ServiceLevelAgreement property
        //public virtual ServiceLevelAgreement? AccountServiceLevelAgreement { get; set; }

        public Account()
        { 
            this.TypeOfItem = ItemType.ACCOUNT;
        }
    }
}
