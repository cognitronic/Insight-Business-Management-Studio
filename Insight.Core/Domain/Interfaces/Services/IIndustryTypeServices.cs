using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces.Services
{
    public interface IIndustryTypeServices<T> where T : IBaseIndustryType
    {
        T GetByID(int id);
        IOrderedEnumerable<T> GetPagedList(int startRow, int pageSize, out int count);
        IOrderedEnumerable<T> GetAll();
        T Save(T item);
        void Delete(T item);
    }
}
