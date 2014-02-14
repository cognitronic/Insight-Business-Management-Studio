﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;
using Insight.Core.Security;

namespace Insight.Core.Domain
{
    public class ModuleRole : IModuleRole
    {
        #region Properties
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual AccessLevels AccessLevel { get; set; }
        public virtual int ModuleID { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        #endregion

        #region Constructors
        public ModuleRole()
        {
            this.TypeOfItem = ItemType.MODULEROLE;
        }
        #endregion

    }
}
