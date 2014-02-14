using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IContactRepository : IRepository<Contact, int>
    {
        IList<Contact> GetByEmail(string email);
        IList<Contact> GetByContactTypeID(int contactTypeID);
        IList<Contact> GetByContactTypeIDItemID(int contactTypeID, int ItemID);
        IList<Contact> GetByMarkedForDeletion(bool isMarkedForDeletion);
        IList<Contact> GetByIsActive(bool isActive);
    }
}
