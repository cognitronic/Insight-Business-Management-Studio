using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IContactEmail : IAuditable, IItem
    {
        int ID { get; set; }
        int ContactID { get; set; }
        string Email { get; set; }
        int EmailTypeID { get; set; }
        ClientContact ContactReference { get; set; }
    }
}
