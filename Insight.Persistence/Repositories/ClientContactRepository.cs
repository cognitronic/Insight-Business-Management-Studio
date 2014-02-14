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
    public class ClientContactRepository : BaseRepository<Insight.Core.Domain.ClientContact, int>, IClientContactRepository
    {
        public IList<ClientContact> GetByEmail(string email)
        {
            return Session.CreateCriteria<ClientContact>()
                .Add(Expression.Eq("Email", email))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<ClientContact>();
        }

        public IList<ClientContact> GetByAccountID(int accountID)
        {
            return Session.CreateCriteria<ClientContact>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<ClientContact>();
        }

        public IList<ClientContact> GetByMarkedForDeletion(bool isMarkedForDeletion)
        {
            return Session.CreateCriteria<ClientContact>()
                .Add(Expression.Eq("MarkedForDeletion", isMarkedForDeletion))
                .List<ClientContact>();
        }

        public IList<ClientContact> GetByIsActive(bool isActive)
        {
            return Session.CreateCriteria<ClientContact>()
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .Add(Expression.Eq("IsActive", isActive))
                .List<ClientContact>();
        }
    }
}
