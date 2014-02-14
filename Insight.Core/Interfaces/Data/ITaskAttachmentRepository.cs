using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface ITaskAttachmentRepository : ICanSave<TaskAttachment>
    {
        IList<TaskAttachment> GetByTaskID(int taskID);
        TaskAttachment GetByID(int taskAttachmentID);
    }
}
