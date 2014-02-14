using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Insight.Core.Interfaces
{
    public interface IContract : IAuditable, IItem
    {
        int AccountID { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int ServiceLevelAgreementID { get; set; }
        string ContractNumber { get; set; }
        int ContractTypeID { get; set; }
        int ContractHours { get; set; }
        int ContractHoursUOMID { get; set; }
    }
}
