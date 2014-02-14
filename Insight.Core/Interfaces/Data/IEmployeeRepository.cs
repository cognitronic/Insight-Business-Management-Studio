using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IEmployeeRepository : ICanSave<Employee>
    {
        IList<Employee> GetByEmail(string email);
        Employee GetByID(int employeeID);
    }
}
