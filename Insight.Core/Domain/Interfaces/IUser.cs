using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces
{
    public interface IUser : IItem, IAuditable
    {
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        bool IsActive { get; set; }
        string Password { get; set; }
        string PasswordAnswer { get; set; }
        string PasswordQuestion { get; set; }
        DateTime PasswordLastChangedDate { get; set; }
        DateTime LastLoginDate { get; set; }
        int DepartmentID { get; set; }
        string WorkPhone { get; set; }
        string CellPhone { get; set; }
        string HomePhone { get; set; }
        string IMHandle { get; set; }
        string Avatar { get; set; }
    }
}
