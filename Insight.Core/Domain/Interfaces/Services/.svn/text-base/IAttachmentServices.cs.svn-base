using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces.Services
{
    public interface IAttachmentServices<T> where T : IBaseAttachment
    {
        T GetByID(int id);
        IOrderedEnumerable<T> GetPagedList(int startRow, int pageSize, out int count);
        IOrderedEnumerable<T> GetAll();
        T Save(T item);
        void Delete(T item);
    }
}
