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

namespace Insight.Persistence.Repositories
{
    public class TaskAttachmentRepository : ITaskAttachmentRepository
    {
        private ISession _session;

        public TaskAttachmentRepository()
        {
            _session = GetSession();
        }

        private static ISession GetSession()
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }

        public IList<TaskAttachment> GetByTaskID(int taskID)
        {
            return _session.CreateCriteria<TaskAttachment>()
                .Add(Expression.Eq("TaskID", taskID))
                .List<TaskAttachment>();
        }

        public TaskAttachment GetByID(int taskAttachmentID)
        {
            return _session.Get<TaskAttachment>(taskAttachmentID);
        }

        public int Save(TaskAttachment entity)
        {
            int newID = (int)_session.Save(entity);
            _session.Flush();
            return newID;
        }
    }
}
