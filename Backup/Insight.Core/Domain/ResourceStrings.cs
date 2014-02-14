using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Insight.Core.Domain
{
    public class ResourceStrings
    {
        #region Session
        public static string Session_CurrentItem = "CurrentItem";
        public static string Session_CurrentBaseURL = "Current_BaseURL";
        public static string Session_CurrentPreviousURL = "Current_PreviousURL";
        public static string Session_CurrentPage = "Current_Page";
        public static string Session_CurrentUser = "Current_User";
        public static string Session_CurrentAccessLevel = "Current_AccessLevel";
        public static string Session_IsAuthenticated = "Is_Authenticated";
        public static string Session_ApplicationContext = "ApplicationContext";

        #endregion

        #region Page Paths
        public static string Page_Default = "~/Home";
        public static string Page_Login = "~/Login";
        #endregion

        #region Accounts
        public static string Contact_AvatarPath = ConfigurationManager.AppSettings["CONTACT_PROFILEIMAGEPATH"];
        #endregion

        #region Icons
        public static string Icon_HistoryLink = "/Images/page_white_star.png";
        #endregion

        #region Global
        public static string NoImageFound = ConfigurationManager.AppSettings["NOPHOTOIMAGE"];
        public static string AppResourcePath = ConfigurationManager.AppSettings["APP_RESOURCE_PATH"];
        #endregion
    }
}
