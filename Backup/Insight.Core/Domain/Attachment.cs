using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class Attachment : IAttachment
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual string Title { get; set; }
        public virtual byte[] AttachmentData { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FullPath { get; set; }
        public virtual int ItemTypeID { get; set; }
        public virtual int ItemID { get; set; }
        public virtual bool StoreInDB { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
    }
}
