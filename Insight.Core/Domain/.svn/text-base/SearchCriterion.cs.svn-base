using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Core.Domain
{
    public class SearchCriterion : ISearchCriterion
    {
        public virtual string SearchColumn { get; set; }
        public virtual Operators Operator { get; set; }
        public virtual dynamic SearchCriteria { get; set; }
        
        public SearchCriterion(string column, Operators op, dynamic criteria)
        {
            this.SearchColumn = column;
            this.Operator = op;
            this.SearchCriteria = criteria;
        }
    }
}
