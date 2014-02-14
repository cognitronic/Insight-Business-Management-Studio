using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class ServiceLevelAgreementServices
    {
        public IOrderedEnumerable<ServiceLevelAgreement> GetServiceLevelAgreements()
        {
            return new ServiceLevelAgreementRepository().GetAll().OrderBy(s => s.Name);
        }
    }
}
