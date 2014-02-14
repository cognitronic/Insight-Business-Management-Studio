using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Core.Interfaces;

namespace Insight.Core.Interfaces.Services
{
    public interface IPageViewServices
    {
        IOrderedEnumerable<PageApplicationView> GetPageApplicationViewsByPageID(int pageID);
    }
}
