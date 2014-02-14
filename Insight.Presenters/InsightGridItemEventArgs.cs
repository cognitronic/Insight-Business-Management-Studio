using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters
{
    [Serializable]
    public class InsightGridItemEventArgs : EventArgs
    {
        public object Item { get; set; }
    }
}
