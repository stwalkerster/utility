using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DataStructures
{
    public class LinkListRoot
    {
        public LinkListNode firstNode;

        private bool _rejectNonUnique = false;
        public bool rejectNonUnique
        {
            get
            {
                return _rejectNonUnique;
            }
            set
            {
                _rejectNonUnique = value;
            }
        }

        public void AddNode( string newData )
        {
            if ( firstNode == null )
            {
                firstNode = new LinkListNode( newData );
                return;
            }
            else if ( firstNode.data == newData && _rejectNonUnique == true )
            {
                return;
            }
            if ( AbeforeB( newData, firstNode.data ) )
            {
                LinkListNode nnode = new LinkListNode( newData );
                nnode.nextNode = firstNode;
                this.firstNode = nnode;
            }
            else
            {
                AddNode( newData, firstNode );
            }
        }
        private void AddNode( string newData, LinkListNode useNode )
        {
            if ( useNode.nextNode == null )
            {
                useNode.nextNode = new LinkListNode( newData );
            }
            else if ( useNode.nextNode.data == newData && _rejectNonUnique == true )
            {
                return;
            }
            else if ( AbeforeB( newData, useNode.nextNode.data ) )
            {
                LinkListNode nnode = new LinkListNode( newData );
                nnode.nextNode = useNode.nextNode;
                useNode.nextNode = nnode;
            }
            else
            {
                AddNode( newData, useNode.nextNode );
            }
        }

        private bool AbeforeB( string A, string B )
        {
            if ( A.Length == 0 )
                return true;
            else
                if ( B.Length == 0 )
                    return false;

            char[ ] Ac = A.ToCharArray( );
            char[ ] Bc = B.ToCharArray( );

            if ( Ac[ 0 ] < Bc[ 0 ] )
            {
                return true;
            }
            else if ( Ac[ 0 ] > Bc[ 0 ] )
            {
                return false;
            }
            else
            {
                return AbeforeB( A.Substring( 1 ), B.Substring( 1 ) );
            }

        }

        public void clearList()
        {
            firstNode=null;
        }

        public int countItems( )
        {
            if ( firstNode != null )
            {
                return 1 + countItems( firstNode.nextNode );
            }
            else
            {
                return 0;
            }
        }
        private int countItems( LinkListNode useNode )
        {
            if ( useNode != null )
            {
                return 1 + countItems( useNode.nextNode );
            }
            else
            {
                return 0;
            }
        }
        public string printList( )
        {
            return firstNode != null ? firstNode.data + "\n" + printList( firstNode.nextNode ) : "";
        }
        private string printList( LinkListNode useNode )
        {
            return useNode != null ? useNode.data + "\n" + printList( useNode.nextNode ) : "";
        }

  
    }

    public class LinkListNode
    {
        public LinkListNode nextNode;
        string dataVal;

        public LinkListNode( string data )
        {
            dataVal = data;

        }

        public string data
        {
            get
            {
                return dataVal;
            }
        }

        public void deleteChild( )
        {
            LinkListNode newChild = this.nextNode.nextNode;
            this.nextNode.nextNode = null;
            this.nextNode = newChild;
        }
    }
}
