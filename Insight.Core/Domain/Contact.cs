using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    [Serializable]
    public class Contact : IContact
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual int ContactTypeID { get; set; }
        public virtual int ItemID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Title { get; set; }
        public virtual string WorkPhone { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string Location { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsKeyContact { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        public virtual IList<ContactEmail> ContactEmail { get; set; }
        public virtual IList<ContactAddress> ContactAddress { get; set; }
        public virtual object ItemReference { get; set; }

        public Contact()
        {
            this.TypeOfItem = ItemType.CONTACT;
            //Assign Name
            this.Name = this.FirstName + " " + this.LastName;
        }
    }
}
