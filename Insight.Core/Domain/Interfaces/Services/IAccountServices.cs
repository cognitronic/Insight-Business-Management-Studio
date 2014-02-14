using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces.Services
{
    public interface IAccountServices<T> where T : IBaseAccount
    {
        T GetByID(int id);
        IOrderedEnumerable<T> GetPagedList(int startRow, int pageSize, out int count);
        IOrderedEnumerable<T> GetAll();
        T Save(T item);
        void Delete(T item);
        T GetByAccountName(string name);
    }
}
