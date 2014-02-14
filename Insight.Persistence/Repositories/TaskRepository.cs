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
    public class TaskRepository : ITaskRepository
    {
        private ISession _session;


        private static ISession GetSession()
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }
        public TaskRepository()
        {
            _session = GetSession();
        }

        #region ICanSave<Task> Members

        public int Save(Task entity)
        {
            int newID = (int)_session.Save(entity);
            _session.Flush();
            return newID;
        }

        public Task GetTaskByID(int taskID)
        {

            return _session.Get<Task>(taskID);
        }

        public IList<Task> GetAll()
        {
            return _session.CreateQuery("select t from Task t")
                .List<Task>();
        }

        #endregion
    }
}
