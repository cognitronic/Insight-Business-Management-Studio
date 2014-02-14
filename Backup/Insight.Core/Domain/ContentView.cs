using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class ContentView : IContentView
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ViewName { get; set; }
        public virtual int UserControlID { get; set; }
        public virtual int LoadOrder { get; set; }
        public virtual UserControl UserControl { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
    }
}
