using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class ContactEmail : IContactEmail
    {
        public virtual int ID { get; set; }
        public virtual int ContactID { get; set; }
        public virtual string Email { get; set; }
        public virtual int EmailTypeID { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual ClientContact ContactReference { get; set; }


        #region IItem Members


        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual ItemType TypeOfItem { get; set; }

        public virtual object ItemReference { get; set; }

        public virtual string URL { get; set; }

        #endregion
    }
}
