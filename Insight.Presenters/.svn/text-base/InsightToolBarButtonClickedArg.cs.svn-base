using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters
{
    public class InsightToolBarButtonClickedArg : EventArgs
    {
        private string _commandName;

        public InsightToolBarButtonClickedArg(string commandName)
        {
            _commandName = commandName;
        }

        public string CommandName { get { return _commandName; } }

        private bool _isEdit = false;
        public bool IsEdit
        {
            get
            {
                return _isEdit;
            }
            set
            {
                _isEdit = value;
            }
        }
    }
}
