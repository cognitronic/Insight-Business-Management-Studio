using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces
{
    public interface IPage : IAuditable
    {
        int ID { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        string URL { get; set; }
        bool IsActive { get; set; }
        int? ParentID { get; set; }
        string IconPath { get; set; }
        int SortOrder { get; set; }
        int ModuleID { get; set; }
        int PageTypeID { get; set; }
    }
}
