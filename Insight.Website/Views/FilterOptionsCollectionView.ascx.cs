using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Core.Domain;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Core.Domain.Interfaces;

namespace Insight.Website.Views
{
    [ViewStateModeById]
    public partial class FilterOptionsCollectionView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            LoadColumns();
            ddlColumns.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ColumnsSelectedIndexChanged);
            
            base.OnInit(e);
        }

        protected void ColumnsSelectedIndexChanged(object o, EventArgs e)
        {
            LoadCriteria();
        }

        public void LoadColumns()
        {
            ddlColumns.DataSource = User.GetItemSearchProperties();
            ddlColumns.DataTextField = "SearchColumn";
            ddlColumns.DataValueField = "CriteriaSearchControlType";
            ddlColumns.DataBind();
            LoadCriteria();
        }

        private void LoadCriteria()
        {
            var controlType = User.GetItemSearchProperties()[ddlColumns.SelectedIndex].CriteriaSearchControlType;

            var ops = User.GetItemSearchProperties()[ddlColumns.SelectedIndex].ValidOperators;
            ddlOperators.DataSource = ops;
            ddlOperators.DataTextField = "key";
            ddlOperators.DataValueField = "value";
            ddlOperators.DataBind();

            switch (controlType)
            {
                case ResourceStrings.ViewFilter_ControlTypes_DDL:
                    criteriaDDL.Visible = true;
                    criteriaText.Visible = false;

                    var crit = User.GetItemSearchProperties()[ddlColumns.SelectedIndex].SearchCriteria;
                    ddlCriteria.DataSource = crit;
                    ddlCriteria.DataBind();
                    break;
                case ResourceStrings.ViewFilter_ControlTypes_Text:
                    criteriaDDL.Visible = false;
                    criteriaText.Visible = true;
                    break;
            }
        }

        public event EventHandler OnColumnChanged;
        public ISearchCriterion FilterOptionsValues { get; set; }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var args = new InsightLinkButtonArgs();
            args.ObjectName = ((LinkButton)o).ID;
            MessageBus<InsightLinkButtonArgs>.SendMessage(o, args);
        }

        public string SearchColumn
        {
            get
            {
                return ddlColumns.SelectedValue;
            }
            set
            {
                ddlColumns.SelectedValue = value;
            }
        }

        public string ConditionOperator
        {
            get
            {
                return ddlOperators.SelectedValue;
            }
            set
            {
                ddlOperators.SelectedValue = value;
            }
        }

        public string SearchCriteria
        {
            get
            {
                if (criteriaDDL.Visible)
                {
                    return ddlCriteria.SelectedValue;
                }
                return tbCriteria.Text;
            }
            set
            {
                if (criteriaDDL.Visible)
                {
                    ddlCriteria.SelectedValue = value;
                }
                else
                {
                    tbCriteria.Text = value;
                }
            }
        }
    }
}