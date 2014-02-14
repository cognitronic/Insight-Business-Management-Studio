using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IFiltersPropertiesView : IBasePropertiesView<IListFilter>, IListFilter
    {
        event EventHandler OnViewPreRender;
        dynamic ConditionsContainer { get; set; }
    }
}
