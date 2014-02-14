using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Interfaces
{
    public interface IQuicklink
    {
        string Text { get; set; }
        string URL { get; set; }
        string IconPath { get; set; }
        string Title { get; set; }
    }
}
