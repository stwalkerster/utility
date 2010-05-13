using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Interaction
{
    public class ConsoleMenuItem : IComparable
    {
        string shortName;
        string description;
        Delegate optionHandler;

        public ConsoleMenuItem(string shortName, string description, Delegate optionHandler )
        {
            this.shortName = shortName;
            this.description = description;
            this.optionHandler = optionHandler;
        }

        public string Key
        {
            get
            {
                return shortName;
            }
            set
            {
                shortName = value;
            }
        }

        public string Value
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public Delegate Handler
        {
            get
            {
                return optionHandler;
            }
        }

        #region IComparable Members

        public int CompareTo( object obj )
        {
            if( obj.GetType( ) != typeof( ConsoleMenuItem ) )
            {
                throw new ArgumentException( );
            }

            return this.Key.CompareTo( ((ConsoleMenuItem)obj).Key );

        }

        #endregion
    }
}
