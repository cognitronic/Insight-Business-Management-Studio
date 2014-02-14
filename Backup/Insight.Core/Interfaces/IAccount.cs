using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IAccount : IItem, IAuditable
    {
        string Phone { get; set; }
        string Fax { get; set; }
        string Website { get; set; }
        bool IsActive { get; set; }
        string EmailDomain { get; set; }
        int IndustryTypeID { get; set; }
        int? ParentAccountID { get; set; }
        int AccountManagerID { get; set; }
        int? ServiceLevelAgreementID { get; set; }
    }
}
