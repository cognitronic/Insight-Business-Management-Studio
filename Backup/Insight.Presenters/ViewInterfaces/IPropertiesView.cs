using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;

namespace Insight.Presenters.ViewInterfaces
{
    public interface IPropertiesView
    {
        //delegate void ToolBarButtonClickedHandler(object o, InsightToolBarButtonClickedArg e);
        event EventHandler OnSaveItem;
        event EventHandler OnDeleteItem;
        event EventHandler OnCreateNewItem;
        event EventHandler OnSaveAndReturn;
        event EventHandler OnCloneItem;
        event EventHandler OnCancel;
        event EventHandler OnUndo;
        event EventHandler OnEmailItem;
        event EventHandler OnPrintItem;
        event EventHandler OnExport;
    }
}
