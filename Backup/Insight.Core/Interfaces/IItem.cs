using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IItem
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ItemType TypeOfItem { get; }
        object ItemReference { get; set; }
        string URL { get; set; }
    }
}
