using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;
namespace Insight.Core.Domain
{
    [Serializable]
    public class Item : IItem
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
    }
}
