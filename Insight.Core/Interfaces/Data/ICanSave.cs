using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface ICanSave<T>
    {
        int Save(T entity);
    }
}
