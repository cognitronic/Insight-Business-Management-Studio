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
    public class ContactRepository : BaseRepository<Insight.Core.Domain.Contact, int>,IContactRepository
    {
        public IList<Contact> GetByEmail(string email)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("Email", email))
                .List<Contact>();
        }

        public IList<Contact> GetByContactTypeID(int contactTypeID)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("ContactTypeID", contactTypeID))
                .List<Contact>();
        }

        public IList<Contact> GetByContactTypeIDItemID(int contactTypeId, int itemID)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("ContactTypeID", contactTypeId))
                .Add(Expression.Eq("ItemID", itemID))
                .List<Contact>();
        }

        public IList<Contact> GetByMarkedForDeletion(bool isMarkedForDeletion)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("MarkedForDeletion", isMarkedForDeletion))
                .List<Contact>();
        }

        public IList<Contact> GetByIsActive(bool isActive)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("IsActive", isActive))
                .List<Contact>();
        }
    }
}
