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
    public class WebUtils
    {
        public static string GetUserFullNameByUserID(int userid)
        {
            if (userid > 0)
            {
                var u = new UserRepository().GetByID(userid, false);
                if (u != null)
                {
                    return u.FirstName + " " + u.LastName;
                }
                return "";
            }
            return "";
        }
    }
}
