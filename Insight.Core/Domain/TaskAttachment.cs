using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class TaskAttachment : IAttachment
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual int TaskID { get; set; }
        public virtual string Title { get; set; }
        public virtual string DateAttached { get; set; }
        public virtual int ChangedByID { get; set; }
        public virtual int EnteredByID { get; set; }
        public virtual byte[] Attachment { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FullPath { get; set; }
        public virtual string Type { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
    }
}
