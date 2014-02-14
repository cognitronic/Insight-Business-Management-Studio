using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain.Interfaces
{
    public interface IBaseNote : IAuditable
    {
        int ID { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        int AccountID { get; set; }
    }
}
