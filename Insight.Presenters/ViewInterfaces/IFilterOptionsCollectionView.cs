using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IFilterOptionsCollectionView : IView
    {
        event EventHandler OnColumnChanged;
        ISearchCriterion FilterOptionsValues { get; set; }
        void LoadConditions();
        void LoadCriteria();
    }
}
