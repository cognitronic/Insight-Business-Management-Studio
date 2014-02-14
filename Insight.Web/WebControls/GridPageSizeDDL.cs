using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdeaSeed.Web.UI;
using Insight.Persistence.Repositories;
using Insight.Core.Domain;
using Telerik.Web.UI;

namespace Insight.Web.WebControls
{
    public class GridPageSizeDDL : IdeaSeed.Web.UI.DropDownList
    {
        public GridPageSizeDDL()
        {
            this.Items.Add(new RadComboBoxItem("5", "5"));
            this.Items.Add(new RadComboBoxItem("10", "10"));
            this.Items.Add(new RadComboBoxItem("25", "25"));
            this.Items.Add(new RadComboBoxItem("50", "50"));
            this.Skin = "Windows7";
        }
    }
}
