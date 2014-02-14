using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain.Interfaces.Data;
using Insight.Core.Domain;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;

namespace Insight.Persistence.Repositories
{
    public class UserRepository : BaseRepository<Insight.Core.Domain.User, int>, IUserRepository
    {

        public User GetByEmail(string email)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("Email", email))
                .UniqueResult<User>();
        }

        public IList<User> GetByMarkedForDeletion(bool delete)
        { 
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("MarkedForDeletion", delete))
                .List<User>();
        }

        public IList<User> GetByStatus(bool isActive)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("IsActive", isActive))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<User>();
        }

        public IList<User> GetByDepartmentID(int departmentID)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("DepartmentID", departmentID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<User>();
        }

        public User GetByUserName(string username)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("UserName", username))
                .UniqueResult<User>();
        }

        public User GetByUserNamePassword(string username, string password)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("UserName", username))
                .Add(Expression.Eq("Password", password))
                .UniqueResult<User>();
        }
    }
}
