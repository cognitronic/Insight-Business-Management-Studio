using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace Insight.Web.WebControls
{
    public class ServiceLevelAgreementsDDL : IdeaSeed.Web.UI.DropDownList
    {
        public ServiceLevelAgreementsDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Agreement --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            foreach (var i in new ServiceLevelAgreementServices().GetServiceLevelAgreements())
            {
                this.Items.Add(new RadComboBoxItem(i.Name, i.ID.ToString()));
            }
        }
    }
}
