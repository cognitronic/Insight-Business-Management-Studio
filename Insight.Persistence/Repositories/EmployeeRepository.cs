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
    public class EmployeeRepository : IEmployeeRepository
    {
        private ISession _session;

        public EmployeeRepository()
        {
            _session = GetSession();
        }

        private static ISession GetSession()
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }

        public IList<Employee> GetByEmail(string email)
        {
            return _session.CreateCriteria<Employee>()
                .Add(Expression.Eq("Email", email))
                .List<Employee>();
        }

        public Employee GetByID(int employeeID)
        {
            return _session.Get<Employee>(employeeID);
        }

        public int Save(Employee entity)
        {
            int newID = (int)_session.Save(entity);
            _session.Flush();
            return newID;
        }
    }
}
