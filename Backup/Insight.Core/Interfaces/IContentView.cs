using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IContentView
    {
        string ViewName { get; set; }
        int UserControlID { get; set; }
        int LoadOrder { get; set; }
        UserControl UserControl { get; set; }
    }
}
