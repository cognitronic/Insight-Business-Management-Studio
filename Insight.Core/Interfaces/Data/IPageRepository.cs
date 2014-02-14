using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IPageRepository : IRepository<Insight.Core.Domain.Page, int>
    {
        Insight.Core.Domain.Page GetByURL(string url);
        IList<Insight.Core.Domain.Page> GetChildPagesByParentID(int parentID);
    }
}
