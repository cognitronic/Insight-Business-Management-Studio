using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Core.Interfaces;
namespace Insight.Presenters.ViewInterfaces.Accounts
{
    public interface IContactEmailListView : IBaseListView<IContactEmail>
    {
        string AccountName { get; set; }
    }
}
