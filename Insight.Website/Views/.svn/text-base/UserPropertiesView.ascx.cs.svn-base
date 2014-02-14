using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using IdeaSeed.Web.UI;
using Insight.Web.Bases;
using Insight.Core.Domain;
using Insight.Web.Controls;
using IdeaSeed.Core.Utils;

namespace Insight.Website.Views
{
    [ViewStateModeById]
    [PresenterType(typeof(UserPropertiesPresenter))]
    public partial class UserPropertiesView : BaseWebUserControl, IUserPropertiesView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (this.UnloadView != null)
            {
                this.UnloadView(this, EventArgs.Empty);
            }
        }

        #region IBasePropertiesView<Contact> Members

        public void LoadItem(User u)
        {
            tbAvatarPath.Text = u.Avatar;
            tbCellPhone.Text = IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(u.CellPhone);
            tbFirstName.Text = u.FirstName;
            tbHomePhone.Text = IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(u.HomePhone);
            tbLastName.Text = u.LastName;
            tbUsername.Text = u.UserName;
            tbIMHandle.Text = u.IMHandle;
            tbWorkPhone.Text = IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(u.WorkPhone);
            cbIsActive.Checked = u.IsActive;
            ddlDepartment.SelectedValue = u.DepartmentID.ToString();
            lblDateCreated.Text = u.DateCreated.ToString();
            lblID.Text = u.ID.ToString();
            lblLastUpdated.Text = u.LastUpdated.ToString();
            tbEmail.Text = u.Email;
        }

        public void NavigateTo(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }
        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;

        public string ViewTitle
        {
            get
            {
                return lblViewTitle.Text;
            }
            set
            {
                lblViewTitle.Text = value;
            }
        }
        #endregion

        #region IContact Members

        public string Email
        {
            get
            {
                return tbEmail.Text;
            }
            set
            {
                tbEmail.Text = value;
            }
        }

        public ItemType UserType
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlDepartment.SelectedValue, out i))
                    return i;
                return i;
            }
            set
            {
                int i = (int)value;
                if (i == 0)
                    ddlDepartment.SelectedValue = "";
                else
                    ddlDepartment.SelectedValue = i.ToString();
            }
        }

        public string FirstName
        {
            get
            {
                return tbFirstName.Text;
            }
            set
            {
                tbFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return tbLastName.Text;
            }
            set
            {
                tbLastName.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return tbUsername.Text;
            }
            set
            {
                tbUsername.Text = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return Utilities.FormatPhoneNumberForDisplay(tbWorkPhone.Text);
            }
            set
            {
                tbWorkPhone.Text = value;
            }
        }

        public string CellPhone
        {
            get
            {
                return Utilities.FormatPhoneNumberForDisplay(tbCellPhone.Text);
            }
            set
            {
                tbCellPhone.Text = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return Utilities.FormatPhoneNumberForDisplay(tbHomePhone.Text);
            }
            set
            {
                tbHomePhone.Text = value;
            }
        }

        public string IMHandle
        {
            get
            {
                return tbIMHandle.Text;
            }
            set
            {
                tbIMHandle.Text = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return cbIsActive.Checked;
            }
            set
            {
                cbIsActive.Checked = value;
            }
        }

        public string Avatar
        {
            get
            {
                return tbAvatarPath.Text;
            }
            set
            {
                tbAvatarPath.Text = value;
            }
        }

        #endregion

        #region IItem Members

        public new int ID
        {
            get
            {
                int i = 0;
                if (int.TryParse(lblID.Text, out i))
                    return i;
                return i;
            }
            set
            {
                int i = value;
                lblID.Text = i.ToString();
            }
        }

        public string URL
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return tbFirstName.Text + " " + tbLastName.Text;
            }
            set
            {
            }
        }

        public string Description
        {
            get;
            set;
        }

        public ItemType TypeOfItem
        {
            get { return ItemType.USER; }
        }

        #endregion

        #region IAuditable Members

        public int EnteredBy
        {
            get;
            set;
        }

        public int ChangedBy
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get
            {
                return DateTime.Parse(lblDateCreated.Text);
            }
            set
            {
                lblDateCreated.Text = value.ToString();
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return DateTime.Parse(lblLastUpdated.Text);
            }
            set
            {
                lblLastUpdated.Text = value.ToString();
            }
        }

        public bool MarkedForDeletion
        {
            get;
            set;
        }

        public object ItemReference
        {
            get;
            set;
        }

        public DateTime LastLoginDate
        {
            get;
            set;
        }
        public string Password { get; set; }
        public DateTime PasswordLastChangedDate { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }

        #endregion
    }
}