using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Domain
{
    public interface IWebUserControl
    {
        Insight.Core.Domain.Page CurrentPage { get; set; }
        int CurrentUserID { get; set; }
        void LoadData();
    }
}
