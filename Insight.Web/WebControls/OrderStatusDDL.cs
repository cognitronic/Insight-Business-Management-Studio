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
    public class OrderStatusDDL : IdeaSeed.Web.UI.DropDownList
    {
        public OrderStatusDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Status --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            foreach (var os in new OrderStatusRepository().GetAll().OrderBy(o => o.Status))
            {
                this.Items.Add(new RadComboBoxItem(os.Status, os.ID.ToString()));
            }
        }
    }
}