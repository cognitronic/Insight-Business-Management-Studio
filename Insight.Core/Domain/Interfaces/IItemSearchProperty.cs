using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Domain.Interfaces
{
    public interface IItemSearchProperty
    {
        string SearchColumn { get; set; }
        string CriteriaSearchControlType { get; set; }
        IDictionary<string,Operators> ValidOperators { get; set; }
        IList<string> SearchCriteria { get; set; }
    }
}
