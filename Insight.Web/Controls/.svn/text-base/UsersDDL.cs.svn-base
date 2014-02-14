using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Telerik.Web.UI;
using Insight.Services;

namespace Insight.Web.Controls
{
    public class UsersDDL : IdeaSeed.Web.UI.DropDownList
    {
        public UsersDDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public bool? ShowByStatus { get; set; }

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadUsers();
        }

        #endregion

        #region Methods
        public void LoadUsers()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select User --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            if (ShowByStatus != null)
            {
                foreach (var u in new UserServices().GetByStatus((bool)ShowByStatus))
                {
                    this.Items.Add(new RadComboBoxItem(u.FirstName + " " + u.LastName, u.ID.ToString()));
                }
            }
            else
            {
                foreach (var u in new UserServices().GetAll())
                {
                    this.Items.Add(new RadComboBoxItem(u.FirstName + " " + u.LastName, u.ID.ToString()));
                }
            }
        }

        #endregion
    }
}
