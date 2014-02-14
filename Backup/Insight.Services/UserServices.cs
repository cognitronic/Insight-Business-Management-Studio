using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Interfaces;
using Insight.Core.Domain;
using Insight.Core.Utils;
using Insight.Core.Security;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class UserServices
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

    }
}