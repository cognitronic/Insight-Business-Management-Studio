using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IUserControl
    {
        string Title { get; set; }
        string Path { get; set; }
    }
}
