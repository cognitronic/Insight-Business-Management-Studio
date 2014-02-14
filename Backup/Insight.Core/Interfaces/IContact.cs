using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IContact : IItem, IAuditable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Title { get; set; }
        string WorkPhone { get; set; }
        string CellPhone { get; set; }
        string HomePhone { get; set; }
        string Location { get; set; }
        bool IsActive { get; set; }
        bool IsKeyContact { get; set; }
        string AvatarPath { get; set; }
        string PrimaryEmail { get; set; }
    }
}
