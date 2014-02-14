using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Domain;
using Insight.Presenters;

namespace Insight.Presenters.ViewInterfaces.Accounts
{
    public interface IAddressListView : IBaseListView<AccountAddress>
    {
    }
}
