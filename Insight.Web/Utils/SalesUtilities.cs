using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;
using System.Collections.Specialized;
using IdeaSeed.Core.Web;

namespace Insight.Web.Utils
{
    public class SalesUtilities : WebUtils
    {
        public static Insight.Core.Domain.Order CurrentOrder
        {
            get { return HttpContextHelper.Get<Insight.Core.Domain.Order>("SQ_CURRENT_ORDER"); }
            set { HttpContextHelper.Set("SQ_CURRENT_ORDER", value); }
        }
    }
}
