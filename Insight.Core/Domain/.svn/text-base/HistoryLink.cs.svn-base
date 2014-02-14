using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Core.Domain
{
    public class HistoryLink : IQuicklink
    {
        public virtual string Text { get; set; }
        public virtual string URL { get; set; }
        public virtual string IconPath { get; set; }
        public virtual string Title { get; set; }

        public HistoryLink()
        { 
        
        }

        public HistoryLink(string text, string url, string iconPath, string title)
        {
            this.Text = text;
            this.URL = url;
            this.IconPath = iconPath;
            this.Title = title;
        }
    }
}
