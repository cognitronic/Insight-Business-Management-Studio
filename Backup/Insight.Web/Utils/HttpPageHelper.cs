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
using Insight.Core.Interfaces;
using Insight.Core.Security;

namespace Insight.Web.Utils
{
    public class HttpPageHelper
    {
        public static Insight.Core.Domain.Page CurrentPage
        {
            get { return HttpContextHelper.Get<Insight.Core.Domain.Page>("SQ_CURRENT_PAGE"); }
            set { HttpContextHelper.Set("SQ_CURRENT_PAGE", value); }
        }

        

        public static bool ShowBannerImages
        {
            get { return HttpContextHelper.Get<bool>("SQ_SHOW_BANNER_IMAGES"); }
            set { HttpContextHelper.Set("SQ_SHOW_BANNER_IMAGES", value); }
        }

        public static bool ShowNewsLetter
        {
            get { return HttpContextHelper.Get<bool>("SQ_SHOW_NEWSLETTER"); }
            set { HttpContextHelper.Set("SQ_SHOW_NEWSLETTER", value); }
        }

        public static string PanelHeaderText
        {
            get { return HttpContextHelper.Get<string>("SQ_PANEL_HEADER_TEXT"); }
            set { HttpContextHelper.Set("SQ_PANEL_HEADER_TEXT", value); }
        }

        public static bool IsValidRequest
        {
            get { return HttpContextHelper.Get<bool>("SQ_IS_VALID_REQUEST"); }
            set { HttpContextHelper.Set("SQ_IS_VALID_REQUEST", value); }
        }

        public static IItem CurrentItem
        {
            get { return HttpContextHelper.Get<IItem>("SQ_CURRENTITEM"); }
            set { HttpContextHelper.Set("SQ_CURRENTITEM", value); }
        }
    }
}
