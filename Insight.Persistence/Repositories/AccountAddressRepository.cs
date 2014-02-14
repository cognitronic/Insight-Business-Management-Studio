using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Insight.Core.Interfaces;
using Insight.Core.Interfaces.Data;
using Insight.Core.Domain;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;

namespace Insight.Persistence.Repositories
{
    public class AccountAddressRepository : BaseRepository<Insight.Core.Domain.AccountAddress, int>
    {
        public IList<AccountAddress> GetAddressesByAccountID(int accountID)
        {
            return Session.CreateCriteria<AccountAddress>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<AccountAddress>();
        }
    }
}
