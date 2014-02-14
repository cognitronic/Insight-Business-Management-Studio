using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Core.Security
{
    public enum AccessLevels
    {
        FULLACCESS = 60,
        INSERTEDIT = 50,
        EDIT = 40,
        READONLY = 30,
        NOACCESS = 0
    }
}
