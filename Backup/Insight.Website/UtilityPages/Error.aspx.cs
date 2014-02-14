using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Web.Bases;
using Insight.Presenters;
using Insight.Presenters.UtilityPages;
using Insight.Presenters.ViewInterfaces.UtilityPages;

public partial class UtilityPages_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.SideBarContainer.Visible = false;
    }
}
