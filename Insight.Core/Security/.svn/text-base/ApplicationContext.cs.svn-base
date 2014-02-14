using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Security;
using Insight.Core.Domain;

namespace Insight.Core.Security
{
    public class ApplicationContext
    {
        #region Master Page Logic
        public event EventHandler UpdateMasterPageControls;

        protected virtual void OnUpdateMasterPageControls(EventArgs e)
        {
            var handler = this.UpdateMasterPageControls;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void FireUpdateMasterPageControls()
        {
            this.OnUpdateMasterPageControls(EventArgs.Empty);
        }

        private static bool _displayLoggedOnUser = true;
        public static bool DisplayLoggedOnUser
        {
            get 
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplayLoggedOnUser] != null)
                {
                    _displayLoggedOnUser = (bool)SessionManager.Current[ResourceStrings.Session_DisplayLoggedOnUser];
                }
                return _displayLoggedOnUser; 
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplayLoggedOnUser] = value; }
        }

        private static bool _displaySearch = true;
        public static bool DisplaySearch
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplaySearch] != null)
                {
                    _displaySearch = (bool)SessionManager.Current[ResourceStrings.Session_DisplaySearch];
                }
                return _displaySearch;
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplaySearch] = value; }
        }

        private static bool _displayLogo = true;
        public static bool DisplayLogo
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplayLogo] != null)
                {
                    _displayLogo = (bool)SessionManager.Current[ResourceStrings.Session_DisplayLogo];
                }
                return _displayLogo;
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplayLogo] = value; }
        }

        private static bool _displaySettingsLinks = true;
        public static bool DisplaySettingsLinks
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplaySettingsLinks] != null)
                {
                    _displaySettingsLinks = (bool)SessionManager.Current[ResourceStrings.Session_DisplaySettingsLinks];
                }
                return _displaySettingsLinks;
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplaySettingsLinks] = value; }
        }

        private static bool _displayPrimaryNav = true;
        public static bool DisplayPrimaryNav
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplayPrimaryNav] != null)
                {
                    _displayPrimaryNav = (bool)SessionManager.Current[ResourceStrings.Session_DisplayPrimaryNav];
                }
                return _displayPrimaryNav;
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplayPrimaryNav] = value; }
        }

        private static bool _displaySubNav = true;
        public static bool DisplaySubNav
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplaySubNav] != null)
                {
                    _displaySubNav = (bool)SessionManager.Current[ResourceStrings.Session_DisplaySubNav];
                }
                return _displaySubNav;
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplaySubNav] = value; }
        }

        private static bool _displayMainToolBar = true;
        public static bool DisplayMainToolBar
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_DisplayMainToolBar] != null)
                {
                    _displayMainToolBar = (bool)SessionManager.Current[ResourceStrings.Session_DisplayMainToolBar];
                }
                return _displayMainToolBar;
            }
            set { SessionManager.Current[ResourceStrings.Session_DisplayMainToolBar] = value; }
        }

        public static string PrimaryNavText
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_PrimaryNavText] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_PrimaryNavText].ToString();
                }
                return "";
            }
            set 
            { 
                SessionManager.Current[ResourceStrings.Session_PrimaryNavText] = value; 
            }
        }

        public static object MainContentContainer
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_MainContentContainer] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_MainContentContainer];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_MainContentContainer] = value;
            }
        }

        public static object SideBarContainer
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_SideBarContainer] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_SideBarContainer];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_SideBarContainer] = value;
            }
        }

        public static object ToolBarContainer
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_ToolBarContainer] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_ToolBarContainer];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_ToolBarContainer] = value;
            }
        }

        public static string SubNavText
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_SubNavText] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_SubNavText].ToString();
                }
                return "";
            }
            set { SessionManager.Current[ResourceStrings.Session_SubNavText] = value; }
        }

        public static void ShowMasterPageHeaderControls(bool show)
        {
            if (show)
            {
                DisplayLoggedOnUser = true;
                DisplayLogo = true;
                DisplaySearch = true;
                DisplaySettingsLinks = true;
                DisplayPrimaryNav = true;
                DisplaySubNav = true;
                DisplayMainToolBar = true;
            }
            else
            {
                DisplayLoggedOnUser = false;
                DisplayLogo = false;
                DisplaySearch = false;
                DisplaySettingsLinks = false;
                DisplayPrimaryNav = false;
                DisplaySubNav = false;
                DisplayMainToolBar = false;
            }
        }



        #endregion
    }
}
