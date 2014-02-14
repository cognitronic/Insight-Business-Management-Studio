using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Core.Domain
{
    public class BaseListFilter : IListFilter
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int PageID { get; set; }
        public virtual int UserID { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual string SearchPropertyControls { get; set; }
        public virtual string SearchCriterion { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
    }
}
