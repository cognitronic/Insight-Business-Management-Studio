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
    public class VendorsDDL : IdeaSeed.Web.UI.DropDownList
    {
        public VendorsDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Status --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            foreach (var v in new VendorRepository().GetAll().OrderBy(v => v.VendorName))
            {
                this.Items.Add(new RadComboBoxItem(v.VendorName, v.ID.ToString()));
            }
        }
    }
}
