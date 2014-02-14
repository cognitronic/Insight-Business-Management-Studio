using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Presenters
{
    [Serializable]
    public class PageViewArg : EventArgs
    {
        private IList<IApplicationView> _pageContentSections = new List<IApplicationView>();
        public IList<IApplicationView> PageContentSections
        {
            get
            {
                return _pageContentSections;
            }
            set
            {
                _pageContentSections = value;
            }
        }
    }
}
