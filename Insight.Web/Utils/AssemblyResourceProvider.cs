using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using Insight.Core.Domain;
using System.Web.Hosting;

namespace Insight.Web.Utils
{
    public class AssemblyResourceProvider : System.Web.Hosting.VirtualPathProvider
    {
        public AssemblyResourceProvider() { }
        private bool IsAppResourcePath(string virtualPath)
        {
            String checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            return checkPath.StartsWith(ResourceStrings.AppResourcePath,
                   StringComparison.InvariantCultureIgnoreCase);
        }
        public override bool FileExists(string virtualPath)
        {
            return (IsAppResourcePath(virtualPath) ||
                    base.FileExists(virtualPath));
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsAppResourcePath(virtualPath))
                return new AssemblyResourceVirtualFile(virtualPath);
            else
                return base.GetFile(virtualPath);
        }
        public override System.Web.Caching.CacheDependency
               GetCacheDependency(string virtualPath,
               System.Collections.IEnumerable virtualPathDependencies,
               DateTime utcStart)
        {
            if (IsAppResourcePath(virtualPath))
                return null;
            else
                return base.GetCacheDependency(virtualPath,
                       virtualPathDependencies, utcStart);
        }

    }
}
