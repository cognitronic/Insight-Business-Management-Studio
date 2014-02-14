using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Core.Interfaces;

namespace Insight.Presenters
{
    /// <summary>
    /// Base functionality all Presenters should support
    /// </summary>
    public abstract class Presenter
    {
        #region Declarations
        protected readonly IView _presenterview;
        #endregion

        #region Constructor
        protected Presenter(IView view, ISessionProvider session)
        {
            _presenterview = view;

            if (session != null)
            {
                SessionManager.Current = session;
            }
        }

        protected Presenter(IView view, ISessionProvider session, ISecurityContext securityContext)
        {
            _presenterview = view;

            if (session != null)
            {
                SessionManager.Current = session;
            }

            if (securityContext != null)
            {
                SecurityContextManager.Current = securityContext;
            }
        }
        #endregion

        /// <summary>
        /// Converts an object from IView to the type of view the Presenter expects
        /// </summary>
        /// <typeparam name="T">Type of view to return (i.e. ILoginView)</typeparam>
        protected T GetView<T>() where T : class, IView
        {
            return _presenterview as T;
        }
        /// <summary>
        /// Returns an object responsible for providing user session state
        /// </summary>
        protected ISessionProvider Session
        {
            get { return SessionManager.Current; }
        }

        protected ISecurityContext SecurityContext
        {
            get { return SecurityContextManager.Current; }
        }

        protected bool IsInsert<T>()
        {
            if (SessionManager.Current[ResourceStrings.Session_CurrentItem] != null &&
                    (((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).ItemReference.GetType() == typeof(T) ||
                    ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).ItemReference.GetType().BaseType == typeof(T)))
            {
                return false;
            }
            return true;
        }

        protected T GetCurrentItemReference<T>()
        {
            return (T)((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).ItemReference;
        }

        protected string ReplaceURLSegment(string url, int segment, string replacementText)
        {
            string retVal = "";
            string[] segments = url.Split('/');
            if (segments.Length >= (segment - 1))
            {
                segments[segment - 1] = replacementText;
            }
            for (int i = 3; i < segments.Length; i++)
            {
                retVal += segments[i] + "/";
            }
            return SecurityContextManager.Current.BaseURL + "/" + retVal.Remove(retVal.Length - 1);
        }
    }

    public delegate void EmptyEventHandlerDelegate();
}
