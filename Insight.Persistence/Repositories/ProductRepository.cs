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
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;

namespace Insight.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Insight.Core.Domain.Product, int>, IProductRepository
    {
        public IList<Product> GetByProductName(string productName)
        {
            return Session.CreateCriteria<Product>()
                .Add(Expression.Like("PartNumber", productName, MatchMode.Anywhere))
                .List<Product>();
        }

        public IList<Product> GetByDescription(string description)
        {
            return Session.CreateCriteria<Product>()
                .Add(Expression.Like("Description", description, MatchMode.Anywhere))
                .List<Product>();
        }

        public IList<Product> GetByModel(string model)
        {
            return Session.CreateCriteria<Product>()
                .Add(Expression.Like("Model", model, MatchMode.Anywhere))
                .List<Product>();
        }

        public IList<Product> GetByProductTypeID(int productTypeID)
        {
            return Session.CreateCriteria<Product>()
                .Add(Expression.Eq("ProductTypeID", productTypeID))
                .List<Product>();
        }
    }
}
