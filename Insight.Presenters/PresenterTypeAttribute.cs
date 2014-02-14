using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters
{
    public class PresenterTypeAttribute : Attribute
    {
        private Type _presenterType;

        public PresenterTypeAttribute(Type presenterType)
        {
            _presenterType = presenterType;
        }

        public Type PresenterType
        {
            get { return _presenterType; }
            set { _presenterType = value; }
        }
    }
}
