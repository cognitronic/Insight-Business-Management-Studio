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
    public class AccountRepository : BaseRepository<Insight.Core.Domain.Account, int>, IAccountRepository
    {

        public IList<Account> GetByEmailDomain(string emailDomain)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("EmailDomain", emailDomain))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public Account GetByName(string name)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("Name", name))
                .UniqueResult<Account>();
        }

        public IList<Account> GetSubAccountsByAccountID(int accountID)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("ParentAccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public IList<Account> GetByAccountManagerID(int accountManagerID)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("AccountManagerID", accountManagerID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public IList<Account> GetByIndustryTypeID(int industryTypeID)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("IndustryTypeID", industryTypeID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public Account GetParentAccountByEmailDomain(string emailDomain)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("EmailDomain", emailDomain))
                .Add(Expression.IsNull("ParentAccountID"))
                .UniqueResult<Account>();
        }

        public IList<Account> GetByStatus(bool isActive)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("IsActive", isActive))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public IList<Account> GetByMarkedForDeletion(bool delete)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("MarkedForDeletion", delete))
                .List<Account>();
        }
    }
}
