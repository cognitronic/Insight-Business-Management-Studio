using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Interfaces
{
    public interface IAccountAddress : IAuditable, IItem
    {
        int AccountID { get; set; }
        string Title { get; set; }
        string AddressType { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}
