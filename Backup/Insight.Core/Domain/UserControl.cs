using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Interfaces;

namespace Insight.Core.Domain
{
    public class UserControl : IUserControl
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Title { get; set; }
        public virtual string Path { get; set; }
        public virtual string Name { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
    }
}
