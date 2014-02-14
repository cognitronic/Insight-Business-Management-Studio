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
    // NOTE: If you change the interface name "IOrdersService" here, you must also update the reference to "IOrdersService" in Web.config.
    [ServiceContract]
    public interface IOrdersService
    {
        [OperationContract]
        Insight.Services.ResultData GetAllOrders(int startRowIndex, int maxRows, string sortExpression, string filterExpression);
    }
}
