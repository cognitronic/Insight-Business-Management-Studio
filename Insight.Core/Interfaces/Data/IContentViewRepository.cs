using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IContentViewRepository : IRepository<ContentView, int>
    {
        IList<ContentView> GetByViewName(string viewName);
    }
}
