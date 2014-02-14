using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Presenters;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IBaseListView<T> : IView
    {
        IList<T> ResultSet { get; set; }
        void LoadResultSet(InsightGridArg args);
        int PageSize { get; set; }
        int CurrentPageIndex { get; set; }
        void NavigateTo(string url);
        int VirtualItemCount { get; set; }
        void RebindGrid();
        event EventHandler<InsightLinkButtonArgs> OnItemSelected;
        event EventHandler<InsightGridArg> OnGetItems;
        event EventHandler<InsightGridItemEventArgs> OnItemsDataBound;
        GridListType ListType { get; set; }
    }
}
