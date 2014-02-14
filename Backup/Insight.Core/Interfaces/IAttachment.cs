using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IAttachment : IItem, IAuditable
    {
        string Title { get; set; }
        byte[] AttachmentData { get; set; }
        string FileName { get; set; }
        string FullPath { get; set; }
        int ItemTypeID { get; set; }
        int ItemID { get; set; }
        bool StoreInDB { get; set; }
    }
}
