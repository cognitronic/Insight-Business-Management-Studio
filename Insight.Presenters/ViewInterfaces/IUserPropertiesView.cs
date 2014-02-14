using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IUserPropertiesView : IBasePropertiesView<User>, IUser
    {
    }
}
