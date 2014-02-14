using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain
{
    public class UserPreferences
    {
        private IList<HistoryLink> _historyLinks = new List<HistoryLink>();
        public virtual IList<HistoryLink> HistoryLinks 
        {
            get
            {
                return _historyLinks;
            }
            set
            {
                _historyLinks = value;
            }
        }

        public virtual int GridPageSize { get; set; }

        #region Constructors
        public UserPreferences()
        {
            
        }
        #endregion
    }
}
