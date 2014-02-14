using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters
{
    public class InsightListViewEventArgs : EventArgs
    {
        public string SelectedViewID { get; set; }
    }
}
