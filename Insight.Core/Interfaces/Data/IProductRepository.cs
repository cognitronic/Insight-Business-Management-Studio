using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IList<Product> GetByProductName(string productName);
        IList<Product> GetByDescription(string description);
        IList<Product> GetByModel(string model);
        IList<Product> GetByProductTypeID(int productTypeID);
    }
}
