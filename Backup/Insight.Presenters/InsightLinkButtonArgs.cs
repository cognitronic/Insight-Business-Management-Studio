using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters
{
    [Serializable]
    public class InsightLinkButtonArgs : EventArgs
    {
        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
    }
}
