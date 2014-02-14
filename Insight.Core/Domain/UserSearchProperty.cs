using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Core.Domain
{
    public class UserSearchProperty : IItemSearchProperty
    {
        public virtual string SearchColumn { get; set; }
        public virtual string CriteriaSearchControlType { get; set; }
        private IDictionary<string, Operators> _validOperators = new Dictionary<string, Operators>();
        public virtual IDictionary<string, Operators> ValidOperators { get { return _validOperators; } set { _validOperators = value; } }
        private IList<string> _searchCriteria = new List<string>();
        public virtual IList<string> SearchCriteria { get { return _searchCriteria; } set { _searchCriteria = value; } }

        public UserSearchProperty(string column, IDictionary<string, Operators> ops, IList<string> criteria, string criteriaControlType)
        {
            this.SearchColumn = column;
            this.ValidOperators = ops;
            this.SearchCriteria = criteria;
            this.CriteriaSearchControlType = criteriaControlType;
        }
    }
}
