using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Web.Bases;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;
using IdeaSeed.Web.UI;

namespace Insight.Website.Views
{
    [PresenterType(typeof(AdminDashboardPresenter))]
    public partial class AdminDashboardView : BaseWebUserControl, IAdminDashboardView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (!IsPostBack)
            {
                if (this.LoadView != null)
                {
                    this.LoadView(this, EventArgs.Empty);
                }
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

        #region IView Members

        string IView.Message
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IView.ViewTitle
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

        public event EventHandler InitView;

        public event EventHandler LoadView;

        public event EventHandler UnloadView;

        #endregion
    }
}