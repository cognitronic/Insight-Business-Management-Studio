using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class Employee : IEmployee
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual int EmployeeTypeID { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string WorkPhone { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string Email { get; set; }
        public virtual string SSN { get; set; }
        public virtual string BirthDate { get; set; }
        public virtual string IsActive { get; set; }
        public virtual string EmergencyContactName { get; set; }
        public virtual string EmergencyContactPhone { get; set; }
        public virtual string EmergencyContactRelation { get; set; }
        public virtual string IMUsername { get; set; }
        public virtual string SMS { get; set; }
        public virtual string StartDate { get; set; }
        public virtual string TerminationDate { get; set; }
        public virtual int PayTypeID { get; set; }
        public virtual decimal HourlyBillRate { get; set; }
        public virtual int DepartmentID { get; set; }
        public virtual int LocationID { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual User UserAccount { get; set; }
    }
}
