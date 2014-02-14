using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Domain.Interfaces.Services
{
    public interface IEquipmentServices<T> where T : IBaseEquipment
    {
        T GetByID(int id);
        IOrderedEnumerable<T> GetPagedList(int startRow, int pageSize, out int count);
        IOrderedEnumerable<T> GetAll();
        T Save(T item);
        void Delete(T item);
        IOrderedEnumerable<T> GetByAccountID(int accountID);
    }
}
