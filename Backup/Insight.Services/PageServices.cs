using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain;
using Insight.Core.Interfaces;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class PageServices
    {
        public IOrderedEnumerable<Page> GetRootNodes()
        {
            return new PageRepository().GetRootNodes().OrderBy(o => o.SortOrder);
        }

        public IOrderedEnumerable<Page> GetSubNav(int parentID)
        {
            return new PageRepository().GetChildPagesByParentID(parentID, (int)PageNavigationType.SUB).OrderBy(o => o.SortOrder);
        }

        public Page GetPageByURL(string url)
        {
            return new PageRepository().GetByURL(url);
        }
    }
}
