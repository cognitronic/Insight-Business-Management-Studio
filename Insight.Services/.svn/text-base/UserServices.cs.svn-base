using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;
using Insight.Services.Utils;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Core.Security;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class UserServices: IUserServices<User>
    {
        public static void SaveUserPreferences(User u)
        {
            string s = JSONSerializationHelper.Serialize<UserPreferences>(u.UserPreferences);
            u.UserPreferencesSerialized = "asdf";
            u.UserPreferencesSerialized = s;
            new UserRepository().SaveOrUpdate(u);
        }

        public static void LoadUserPreferences(User u)
        {
            //var pref = new UserPreferences();
            var pref = JSONSerializationHelper.Deserialize<UserPreferences>(u.UserPreferencesSerialized);
            u.UserPreferences = new UserPreferences();
            if (pref != null)
            {
                foreach (var link in pref.HistoryLinks)
                {
                    u.UserPreferences.HistoryLinks.Add(link);
                }
                u.UserPreferences.GridPageSize = pref.GridPageSize;
            }
            }

        public IOrderedEnumerable<User> GetByStatus(bool isActive)
        {
            return new UserRepository().GetByStatus(isActive).OrderBy(o => o.LastName);
        }

        public IOrderedEnumerable<User> GetAll()
        {
            return new UserRepository().GetAll().OrderBy(o => o.LastName);
        }

        public User GetByID(int id)
        {
            return new UserRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<User> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new UserRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Name);
        }

        //public IOrderedEnumerable<User> GetFilteredPagedList(int startRow, int pageSize)
        //{
        //    return new UserRepository().GetByFilters(startRow, pageSize).OrderBy(o => o.Name);
        //}

        public User Save(User user)
        {
            return new UserRepository().SaveOrUpdate(user);
        }

        public void Delete(User user)
        {
            user.MarkedForDeletion = true;
            Save(user);
        }

        public User GetByUserName(string username)
        {
            return new UserRepository().GetByUserName(username);
        }
    }
}