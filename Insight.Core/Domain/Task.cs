using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class Task : ITask
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual int StatusID { get; set; }
        public virtual int PriorityID { get; set; }
        public virtual int AssignedToID { get; set; }
        public virtual string StartDate { get; set; }
        public virtual string DueDate { get; set; }
        public virtual string DateCompleted { get; set; }
        public virtual int DepartmentID { get; set; }
        public virtual decimal EstimatedDuration { get; set; }
        public virtual decimal ActualDuration { get; set; }
        public virtual int EnteredByID { get; set; }
        public virtual int? ChangedByID { get; set; }
        public virtual int? ProjectID { get; set; }
        public virtual int AccountID { get; set; }
        public virtual string LastUpdated { get; set; }
        public virtual bool Acknowledged { get; set; }
        public virtual bool IsCustomerViewable { get; set; }
        public virtual string BillingNote { get; set; }
        public virtual bool IsPrivate{ get; set; }
        public virtual string DateCreated { get; set; }
        public virtual int? AccountContactID { get; set; }
        public virtual string DescriptionNoHTML { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
    }
}
