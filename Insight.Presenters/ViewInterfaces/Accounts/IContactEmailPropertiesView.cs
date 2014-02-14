using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Interfaces;

namespace Insight.Presenters.ViewInterfaces.Accounts
{
    public interface IContactEmailPropertiesView : IBasePropertiesView<IContactEmail>, IContactEmail
    {
    }
}
