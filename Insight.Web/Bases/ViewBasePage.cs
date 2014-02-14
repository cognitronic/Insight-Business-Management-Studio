using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;

namespace Insight.Web.Bases
{
    public abstract class ViewBasePage<TPresenter> : InsightBasePage where TPresenter : IPresenter, new()
    {
        private TPresenter _presenter;

        protected ViewBasePage()
        { 
            Presenter = new TPresenter();
        }

        public TPresenter Presenter
        {
            get
            {
                return _presenter;
            }
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
    }
}
