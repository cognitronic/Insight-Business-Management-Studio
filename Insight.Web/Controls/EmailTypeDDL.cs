using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace Insight.Web.Controls
{
    public class EmailTypeDDL : IdeaSeed.Web.UI.DropDownList
    {
        public EmailTypeDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Type --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            this.Items.Add(new RadComboBoxItem("Primary", ((int)EmailType.PRIMARY).ToString()));
            this.Items.Add(new RadComboBoxItem("Alternate", ((int)EmailType.ALTERNATE).ToString()));
        }
    }
}
