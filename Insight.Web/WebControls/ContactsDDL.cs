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
    public class ContactsDDL : IdeaSeed.Web.UI.DropDownList
    {
        public ContactsDDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Properties
        public bool? ShowByStatus { get; set; }
        public string AccountID { get; set; }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadContacts();
        }

        #endregion

        #region Methods
        public void LoadContacts()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Contact --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            if (!string.IsNullOrEmpty(AccountID))
            {
                if (ShowByStatus != null)
                {
                    foreach (var c in new ContactRepository().GetByAccountIDStatus((bool)ShowByStatus, Convert.ToInt32(AccountID)).OrderBy(c => c.LastName))
                    {
                        this.Items.Add(new RadComboBoxItem(c.FirstName + " " + c.LastName, c.ID.ToString()));
                    }
                }
                else
                {
                    foreach (var c in new ContactRepository().GetByAccountID(Convert.ToInt32(AccountID)).OrderBy(c => c.LastName))
                    {
                        this.Items.Add(new RadComboBoxItem(c.FirstName + " " + c.LastName, c.ID.ToString()));
                    }
                }
            }
        }

        #endregion
    }
}