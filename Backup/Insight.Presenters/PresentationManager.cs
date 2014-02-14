using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;

namespace Insight.Presenters
{
    /// <summary>
    /// Part part facade, part factory - this class is used to return 
    /// a presenter based on the type of view
    /// </summary>
    public static class PresentationManager
    {
        /// <summary>
        /// Creates and return a presenter based on the type of interface the calling view 
        /// implements. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="presenterType">Type of the presenter.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static T RegisterView<T>(Type presenterType, IView view) where T : Presenter
        {
            return RegisterView<T>(presenterType, view, null);
        }
        /// <summary>
        /// Creates and return a presenter based on the type of interface the calling view 
        /// implements.  
        /// </summary>
        /// <param name="presenterType">Type of the presenter.</param>
        /// <param name="view">Instance of the view</param>
        /// <param name="session">Object implementing ISessionProvider, or null if no state is required</param>
        public static T RegisterView<T>(Type presenterType, IView view, ISessionProvider session) where T : Presenter
        {
            return LoadPresenter(presenterType, view, session, null) as T;
        }
        /// <summary>
        /// Allows for registration where the presenter type isn't known at compile time.  This method pair also
        /// does not return a presenter to the caller
        /// </summary>
        /// <param name="presenterType">Type of presenter</param>
        /// <param name="view">Instance of the view</param>
        public static void RegisterView(Type presenterType, IView view)
        {
            RegisterView(presenterType, view, null);
        }
        /// <summary>
        /// Allows for registration where the presenter type isn't known at compile time.  This method pair also
        /// does not return a presenter to the caller
        /// </summary>
        /// <param name="presenterType">Type of presenter</param>
        /// <param name="view">Instance of the view</param>
        /// <param name="session">An object implementing ISessionStateProvicer</param>
        public static void RegisterView(Type presenterType, IView view, ISessionProvider session)
        {
            LoadPresenter(presenterType, view, session, null);
        }
        /// <summary>
        /// Allows for registration where the presenter type isn't known at compile time.  This method pair also
        /// does not return a presenter to the caller
        /// </summary>
        /// <param name="presenterType">Type of presenter</param>
        /// <param name="view">Instance of the view</param>
        /// <param name="session">An object implementing ISessionStateProvider</param>
        /// <param name="securityContext">An object implementing ISecurityContext</param>
        public static void RegisterView(Type presenterType, IView view, ISessionProvider session, ISecurityContext securityContext)
        {
            LoadPresenter(presenterType, view, session, securityContext);
        }
        /// <summary>
        /// Loads the presenter.
        /// </summary>
        /// <param name="presenterType">Type of the presenter.</param>
        /// <param name="view">The view.</param>
        /// <param name="session">The session.</param>
        /// <returns></returns>
        private static object LoadPresenter(Type presenterType, IView view, ISessionProvider session, ISecurityContext securityContext)
        {
            int arraySize = 1; // session == null ? 1 : 2;
            if (session != null)
            {
                arraySize++;
            }
            if (securityContext != null)
            {
                arraySize++;
            }

            object[] constructerParams = new object[arraySize];
            constructerParams[0] = view;

            switch (arraySize)
            { 
                case 3:
                    constructerParams[1] = session;
                    constructerParams[2] = securityContext;
                    break;
                case 2:
                    constructerParams[1] = session;
                    break;
            }
            // Add the session as a parameter if it's not null
            //if (arraySize.Equals(2))
            //{
            //    constructerParams[1] = session;
            //}

            return Activator.CreateInstance(presenterType, constructerParams); ;
        }
    }
}
