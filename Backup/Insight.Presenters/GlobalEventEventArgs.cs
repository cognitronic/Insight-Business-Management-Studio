using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Presenters
{
    public delegate void GlobalEventHandler(object sender, GlobalEventEventArgs e);

    public class GlobalEventEventArgs : EventArgs
    {
        private object data;

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public object Data
        {
            get { return data; }
            set { data = value; }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:GlobalEventEventArgs"/> class.
        /// </summary>
        public GlobalEventEventArgs()
        {
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:GlobalEventEventArgs"/> class.
        /// </summary>
        /// <param name="myData">My data.</param>
        public GlobalEventEventArgs(object myData)
            : this()
        {
            data = myData;
        }
    }
}
