using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IAuditable
    {
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        bool MarkedForDeletion { get; set; }
    }
}
