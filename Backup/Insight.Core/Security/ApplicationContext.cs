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
                if (SessionManager.Current["DisplayLoggedOnUser"] != null)
                { 
                    _displayLoggedOnUser = (bool)SessionManager.Current["DisplayLoggedOnUser"];
                }
                return _displayLoggedOnUser; 
            }
            set { SessionManager.Current["DisplayLoggedOnUser"] = value; }
        }

        private static bool _displaySearch = true;
        public static bool DisplaySearch
        {
            get
            {
                if (SessionManager.Current["DisplaySearch"] != null)
                {
                    _displaySearch = (bool)SessionManager.Current["DisplaySearch"];
                }
                return _displaySearch;
            }
            set { SessionManager.Current["DisplaySearch"] = value; }
        }

        private static bool _displayLogo = true;
        public static bool DisplayLogo
        {
            get
            {
                if (SessionManager.Current["DisplayLogo"] != null)
                {
                    _displayLogo = (bool)SessionManager.Current["DisplayLogo"];
                }
                return _displayLogo;
            }
            set { SessionManager.Current["DisplayLogo"] = value; }
        }

        private static bool _displaySettingsLinks = true;
        public static bool DisplaySettingsLinks
        {
            get
            {
                if (SessionManager.Current["DisplaySettingsLinks"] != null)
                {
                    _displaySettingsLinks = (bool)SessionManager.Current["DisplaySettingsLinks"];
                }
                return _displaySettingsLinks;
            }
            set { SessionManager.Current["DisplaySettingsLinks"] = value; }
        }

        private static bool _displayPrimaryNav = true;
        public static bool DisplayPrimaryNav
        {
            get
            {
                if (SessionManager.Current["DisplayPrimaryNav"] != null)
                {
                    _displayPrimaryNav = (bool)SessionManager.Current["DisplayPrimaryNav"];
                }
                return _displayPrimaryNav;
            }
            set { SessionManager.Current["DisplayPrimaryNav"] = value; }
        }

        private static bool _displaySubNav = true;
        public static bool DisplaySubNav
        {
            get
            {
                if (SessionManager.Current["DisplaySubNav"] != null)
                {
                    _displaySubNav = (bool)SessionManager.Current["DisplaySubNav"];
                }
                return _displaySubNav;
            }
            set { SessionManager.Current["DisplaySubNav"] = value; }
        }

        private static bool _displayMainToolBar = true;
        public static bool DisplayMainToolBar
        {
            get
            {
                if (SessionManager.Current["DisplayMainToolBar"] != null)
                {
                    _displayMainToolBar = (bool)SessionManager.Current["DisplayMainToolBar"];
                }
                return _displayMainToolBar;
            }
            set { SessionManager.Current["DisplayMainToolBar"] = value; }
        }

        public static string PrimaryNavText
        {
            get
            {
                if (SessionManager.Current["PrimaryNavText"] != null)
                {
                    return SessionManager.Current["PrimaryNavText"].ToString();
                }
                return "";
            }
            set { SessionManager.Current["PrimaryNavText"] = value; }
        }

        public static string SubNavText
        {
            get
            {
                if (SessionManager.Current["SubNavText"] != null)
                {
                    return SessionManager.Current["SubNavText"].ToString();
                }
                return "";
            }
            set { SessionManager.Current["SubNavText"] = value; }
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
