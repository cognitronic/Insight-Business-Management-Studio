using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Hosting;
using System.Web;

namespace Insight.Web.Utils
{
    public class AssemblyResourceVirtualFile : VirtualFile
    {
        string path;

        public AssemblyResourceVirtualFile(string virtualPath)
            : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }
        public override System.IO.Stream Open()
        {
            string[] parts = path.Split('/');
            string assemblyName = parts[2];
            string resourceName = parts[3];
            assemblyName = Path.Combine(HttpRuntime.BinDirectory,
                                        assemblyName);
            System.Reflection.Assembly assembly =
               System.Reflection.Assembly.LoadFile(assemblyName);
            if (assembly != null)
            {
                return assembly.GetManifestResourceStream(resourceName);
            }
            return null;
        }

    }
}
