using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IListToolBarView : IView
    {
        bool DisplayToolBar { get; set; }
        string ExportFormat { get; }
        GridListType CurrentListType { get; set; }
        string SelectedPageSize { get; set; }
        string SelectedListViewID { get; set; }
        event EventHandler OnEmailItem;
        event EventHandler OnPrintItem;
        event EventHandler OnExport;
        event EventHandler OnCreateNewItem;
        event EventHandler<InsightGridArg> OnListTypeChanged;
        event EventHandler<InsightGridArg> OnPageSizeChanged;
        event EventHandler<InsightListViewEventArgs> OnListViewChanged;
        event EventHandler OnToolBarLoad;
        void NavigateTo(string url);
    }
}
