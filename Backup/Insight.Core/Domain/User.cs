using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    [Serializable]
    public class User : IUser
    {
        #region Properties
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string UserName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordAnswer { get; set; }
        public virtual string PasswordQuestion { get; set; }
        public virtual DateTime PasswordLastChangedDate { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        public virtual string Name { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int DepartmentID { get; set; }
        public virtual string WorkPhone { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string IMHandle { get; set; }
        private IList<IModuleUser> _userModules = new List<IModuleUser>();
        public virtual IList<IModuleUser> UserModules { get { return _userModules; } set { _userModules = value; } }
        public virtual string UserPreferencesSerialized { get; set; }
        public virtual UserPreferences UserPreferences { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            this.TypeOfItem = ItemType.USER;
        }

        #endregion


    }
}
