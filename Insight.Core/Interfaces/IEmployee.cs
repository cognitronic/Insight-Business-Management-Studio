using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IEmployee : IItem, IHasItemType
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        int EmployeeTypeID { get; set; }
        string HomePhone { get; set; }
        string WorkPhone { get; set; }
        string CellPhone { get; set; }
        string Email { get; set; }
        string SSN { get; set; }
        string BirthDate { get; set; }
        string IsActive { get; set; }
        string EmergencyContactName { get; set; }
        string EmergencyContactPhone { get; set; }
        string EmergencyContactRelation { get; set; }
        string IMUsername { get; set; }
        string SMS { get; set; }
        string StartDate { get; set; }
        string TerminationDate { get; set; }
        int PayTypeID { get; set; }
        decimal HourlyBillRate { get; set; }
        int DepartmentID { get; set; }
        int LocationID { get; set; }
        User UserAccount { get; set; }
    }
}
