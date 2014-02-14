using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces
{
    public interface IPageUser
    {
        int ID { get; set; }
        int PageID { get; set; }
        int UserID { get; set; }
        int AccessLevel { get; set; }
    }
}
