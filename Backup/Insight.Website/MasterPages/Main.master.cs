using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using IdeaSeed.Web.UI;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;
using System.Configuration;
using System.Text;
using Insight.Web.Bases;
using Insight.Presenters.ViewInterfaces;
using Insight.Presenters;


public partial class MasterPages_Main : BaseMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public Control MainContent
    {
        get
        {
            return cpMainContent;
        }
        set
        {
            cpMainContent = (ContentPlaceHolder)value;
        }
    }

    public HtmlGenericControl SideBarContainer
    {
        get
        {
            return divSideBar;
        }
        set
        {
            divSideBar = (HtmlGenericControl)value;
        }
    }

    public HtmlGenericControl ToolBarContainer
    {
        get
        {
            return divMainToolBar;
        }
        set
        {
            divMainToolBar = (HtmlGenericControl)value;
        }
    }

    public ContentPlaceHolder SideBar
    {
        get
        {
            return cpSideBar;
        }
    }

 
}
