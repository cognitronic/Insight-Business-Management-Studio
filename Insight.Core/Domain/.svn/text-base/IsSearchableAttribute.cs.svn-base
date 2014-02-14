using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Domain
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsSearchableAttribute : Attribute
    {
        private bool _searchable;

        public IsSearchableAttribute(bool searchable)
        {
            _searchable = searchable;
        }

        public bool IsSearchable
        {
            get { return _searchable; }
            set { _searchable = value; }
        }
    }
}
