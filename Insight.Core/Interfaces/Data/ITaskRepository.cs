using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface ITaskRepository : ICanSave<Task>
    {
        IList<Task> GetAll();
        //IList<Task> GetTasksByAccountID(int accountID);
        //IList<Task> GetPagesByApplicationIDRouteURL(int applicationID, string routeURL);
        //IList<Task> GetActivePages();
        //IList<Task> GetRootLevelPagesByApplicationID(int applicationID);
        //IList<Task> GetActivePagesByApplicationID(int applicationID);   
    }
}
