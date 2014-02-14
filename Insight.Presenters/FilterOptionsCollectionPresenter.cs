using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;
using Insight.Services.Utils;

namespace Insight.Presenters
{
    public class FilterOptionsCollectionPresenter : Presenter
    {
        IFilterOptionsCollectionView _view;

        public FilterOptionsCollectionPresenter(IFilterOptionsCollectionView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IFilterOptionsCollectionView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.InitView += new EventHandler(_view_InitView);
            _view.OnColumnChanged += new EventHandler(_view_OnColumnChanged);
        }

        void _view_OnColumnChanged(object sender, EventArgs e)
        {
            _view.LoadCriteria();
        }

        void _view_InitView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
