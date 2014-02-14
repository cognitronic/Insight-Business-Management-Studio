using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class IndustryTypeServices
    {
        public IOrderedEnumerable<IndustryType> GetIndustryTypes()
        {
            return new IndustryTypeRepository().GetAll().OrderBy(i => i.Name);
        }
    }
}
