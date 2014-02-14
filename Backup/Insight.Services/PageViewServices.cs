using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain;
using Insight.Core.Interfaces.Services;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class PageViewServices : IPageViewServices
    {
        public IOrderedEnumerable<PageApplicationView> GetPageApplicationViewsByPageID(int pageID)
        {
            return new PageApplicationViewRepository().GetByPageID(pageID).OrderBy(o => o.SortOrder);
        }

        public PageApplicationView GetPageApplicationViewsByPageIDApplicationViewID(int pageID, int appViewID)
        {
            return new PageApplicationViewRepository().GetByPageIDApplicationViewID(pageID, appViewID);
        }
    }
}
