using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Insight.Persistence.Repositories;
using Insight.Core.Domain;

namespace Insight.Services
{
    // NOTE: If you change the class name "OrdersService" here, you must also update the reference to "OrdersService" in Web.config.
    public class OrdersService : IOrdersService
    {
        public ResultData GetAllOrders(int startRow, int maxRow, string sortExpression , string filterExpression)
        {
            var result = new ResultData();
            //long cnt = 0;
            //result.Data = (List<Order>)new OrderRepository().GetPagedList(startRow, maxRow, out cnt);
            //result.Count = cnt;
            return result;
        }
    }

    public class ResultData
    {
        public long Count { get; set; }
        //public List<Order> Data { get; set; }
    }
}
