using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;
using System.Drawing;

namespace Insight.Core.Domain
{
    [Serializable]
    public class ClientContact : IClientContact
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual int AccountID { get; set; }
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
        private IList<IContactEmail> _emails = new List<IContactEmail>();
        public virtual IList<IContactEmail> ContactEmail { get { return _emails; } set { _emails = value; } }
        private IList<IContactAddress> _address = new List<IContactAddress>();
        public virtual IList<IContactAddress> ContactAddress { get { return _address; } set { _address = value; } }
        public virtual object ItemReference { get; set; }
        public virtual string AvatarPath { get; set; }
        public virtual Account ContactAccount { get; set; }
        public virtual string PrimaryEmail { get; set; }
        public virtual string URL { get; set; }

        public ClientContact()
        {
            this.TypeOfItem = ItemType.CONTACT;
            //Assign Name
            this.Name = this.FirstName + " " + this.LastName;
        }
    }
}
