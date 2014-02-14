using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IContactAddress : IAuditable, IHasAddress
    {
        int ID { get; set; }
        int ContactID { get; set; }
        string Title { get; set; }
        ClientContact ContactReference { get; set; }
        int AddressTypeID { get; set; }
    }
}
