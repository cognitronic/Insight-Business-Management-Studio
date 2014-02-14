using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface ITask : IItem, IHasItemType
    {
        string Title { get; set; }
        int StatusID { get; set; }
        int PriorityID { get; set; }
        int AssignedToID { get; set; }
        string StartDate { get; set; }
        string DueDate { get; set; }
        string DateCompleted { get; set; }
        int DepartmentID { get; set; }
        decimal EstimatedDuration { get; set; }
        decimal ActualDuration { get; set; }
        int EnteredByID { get; set; }
        int? ChangedByID { get; set; }
        int? ProjectID { get; set; }
        int AccountID { get; set; }
        string LastUpdated { get; set; }
        bool Acknowledged { get; set; }
        bool IsCustomerViewable { get; set; }
        string BillingNote { get; set; }
        bool IsPrivate { get; set; }
        string DateCreated { get; set; }
        int? AccountContactID { get; set; }
        string DescriptionNoHTML { get; set; }
    }
}
