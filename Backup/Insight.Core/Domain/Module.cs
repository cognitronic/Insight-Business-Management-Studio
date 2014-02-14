using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;


namespace Insight.Core.Domain
{
    public class Module : IModule
    {
        #region Properties
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        private IList<IModuleRole> _moduleRoles = new List<IModuleRole>();
        public virtual IList<IModuleRole> ModuleRoles { get { return _moduleRoles; } set { _moduleRoles = value; } }
        private IList<IModuleUser> _moduleUsers = new List<IModuleUser>();
        public virtual IList<IModuleUser> ModuleUsers { get { return _moduleUsers; } set { _moduleUsers = value; } }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        #endregion

        #region Constructors
        public Module()
        {
            this.TypeOfItem = ItemType.MODULE;
        }
        #endregion

    }
}
