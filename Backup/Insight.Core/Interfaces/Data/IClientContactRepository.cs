using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IClientContactRepository : IRepository<ClientContact, int>
    {
        IList<ClientContact> GetByEmail(string email);
        IList<ClientContact> GetByAccountID(int contactTypeID);
        IList<ClientContact> GetByMarkedForDeletion(bool isMarkedForDeletion);
        IList<ClientContact> GetByIsActive(bool isActive);
    }
}
