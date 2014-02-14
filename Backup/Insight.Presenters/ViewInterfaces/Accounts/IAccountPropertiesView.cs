﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Domain;
using Insight.Core.Interfaces;
using Insight.Presenters;

namespace Insight.Presenters.ViewInterfaces.Accounts
{
    public interface IAccountPropertiesView : IView,  IAccount
    {
        void LoadAccount(Account account);
        void NavigateTo(string url);
        event EventHandler OnLoad;
    }
}
