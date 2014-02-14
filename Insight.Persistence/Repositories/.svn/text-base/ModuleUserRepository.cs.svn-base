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
    public class ModuleUserRepository : BaseRepository<Insight.Core.Domain.ModuleUser, int>, IModuleUserRepository
    {
        #region IModuleUserRepository Members

        public IList<ModuleUser> GetByModuleID(int moduleID)
        {
            return Session.CreateCriteria<ModuleUser>()
                .Add(Expression.Eq("ModuleID", moduleID))
                .List<ModuleUser>();
        }

        public IList<IModuleUser> GetByUserID(int userID)
        {
            return Session.CreateCriteria<IModuleUser>()
                .Add(Expression.Eq("UserID", userID))
                .List<IModuleUser>();
        }

        #endregion
    }
}
