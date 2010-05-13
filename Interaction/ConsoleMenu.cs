using System;
using System.Collections;
using System.Collections.Generic;

namespace Utility.Interaction
{
    /// <summary>
    /// Uses a console-based menu system to allow the user to choose from a set of options
    /// </summary>
    public class ConsoleMenu
    {
        ArrayList menuItems;

        string selectedKey;
        int lengthOfLongestKey;
        int lengthOfLongestValue;

        string title;

        public ConsoleMenu( string MenuTitle )
        {
            title = MenuTitle;
            menuItems = new ArrayList( );
        }

        public void sortItems( )
        {
            menuItems.Sort( );
        }

        /// <summary>
        /// Adds an item to the menu
        /// </summary>
        /// <param name="shortName">A short name for the item. This is returned when the user makes a choice.</param>
        /// <param name="description">A description of the item</param>
        public void addItem( string shortName, string description, Delegate optionHandler )
        {
            if( description == null )
            {
                description = string.Empty;
            }
            menuItems.Add( new ConsoleMenuItem( shortName, description, optionHandler ) );
            if( menuItems.Count == 1 )
            {
                selectedKey = shortName;
            }
            lengthOfLongestKey = Math.Max( lengthOfLongestKey, shortName.Length );
            lengthOfLongestValue = Math.Max( lengthOfLongestValue, description.Length );

            int lengthofLongestLine = " [ ".Length + lengthOfLongestKey + " ] ".Length + lengthOfLongestValue;
            if( lengthofLongestLine > 80 )
                Console.WindowWidth = lengthofLongestLine + 1;
        }

        /// <summary>
        /// Run the menu.
        /// </summary>
        /// <returns>The short name of the chosen item.</returns>
        public void runMenu( )
        {
            Console.ResetColor( );
            Console.Title = title;

            bool chosen = false;

            string choice = "";

            this.showMenu( );

            while( !chosen )
            {
                ConsoleKeyInfo cki = Console.ReadKey( true );

                switch( cki.Key )
                {
                    case ConsoleKey.DownArrow:
                        this.moveSelectionDown( );
                        break;
                    case ConsoleKey.Enter:
                        choice = selectedKey;
                        chosen = true;
                        break;
                    case ConsoleKey.UpArrow:
                        this.moveSelectionUp( );
                        break;
                    default:
                        Console.Beep( );
                        break;
                }
            }
            foreach( ConsoleMenuItem item in menuItems )
            {
                if( item.Key == choice )
                    item.Handler.DynamicInvoke( );
            }
        }

        private void showMenu( )
        {
            // work out how much space we have.
            int rowsAvailable = Console.WindowHeight - 4;

            Console.Clear( );
            Console.WriteLine( "Please choose an option:" );
            Console.WriteLine( );
            if( menuItems.Count <= rowsAvailable )
            {
                foreach( ConsoleMenuItem item in menuItems )
                {
                    string shortName = item.Key.PadLeft( lengthOfLongestKey );
                    Console.Write( " " );
                    if( item.Key == selectedKey )
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write( "[ " + shortName + " ]" );
                    if( item.Key == selectedKey )
                    {
                        Console.ForegroundColor = Console.BackgroundColor;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine( " " + item.Value );
                    rowsAvailable--;
                }
                for( ; rowsAvailable > 0; rowsAvailable-- )
                {
                    Console.WriteLine( );
                }

                Console.WriteLine( );
                Console.Write( "[ Up / Down ] Select an item                     [ Enter ] Choose selected item" );
            }
            else
            {
                Console.WriteLine( "The console window is too small to display this menu." );
                Console.ReadKey( );
                showMenu( );
            }
        }

        void moveSelectionDown( )
        {
            for( int i = 0; i < menuItems.Count; i++ )
            {
                if( ( (ConsoleMenuItem)menuItems[ i ] ).Key == selectedKey )
                {
                    Console.ResetColor( );
                    Console.SetCursorPosition( 1, i + 2 );
                    Console.Write( "[ " + ( (ConsoleMenuItem)menuItems[ i ] ).Key.PadRight( lengthOfLongestKey ) + " ]" );// + ( (KeyValuePair<string, string>)menuItems[ i ] ).Value );


                    Console.SetCursorPosition( 1, i + 3 );
                    if( i == menuItems.Count - 1 )
                    {
                        Console.SetCursorPosition( 1, 2 );
                    }

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    selectedKey = ( (ConsoleMenuItem)menuItems[ ( i + 1 ) % menuItems.Count ] ).Key;

                    Console.Write( "[ " + selectedKey.PadRight( lengthOfLongestKey ) + " ]" );

                    Console.ResetColor( );
                    break;
                }
            }
        }
        void moveSelectionUp( )
        {
            for( int i = 0; i < menuItems.Count; i++ )
            {
                if( ( (ConsoleMenuItem)menuItems[ i ] ).Key == selectedKey )
                {
                    Console.ResetColor( );
                    Console.SetCursorPosition( 1, i + 2 );
                    Console.Write( "[ " + ( (ConsoleMenuItem)menuItems[ i ] ).Key.PadRight( lengthOfLongestKey ) + " ]" );// + ( (KeyValuePair<string, string>)menuItems[ i ] ).Value );


                    Console.SetCursorPosition( 1, i + 1 );
                    if( i == 0 )
                    {
                        Console.SetCursorPosition( 1, menuItems.Count + 1 );
                    }

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    selectedKey = ( (ConsoleMenuItem)menuItems[ ( ( i + menuItems.Count ) - 1 ) % menuItems.Count ] ).Key;

                    Console.Write( "[ " + selectedKey.PadRight( lengthOfLongestKey ) + " ]" );

                    Console.ResetColor( );
                    break;
                }
            }
        }
    }
 
    
}