using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Utility.BigNumber
{
    public class Integer
    {
        string store = "0";

        #region output
        /// <summary>
        /// gets or sets the value of the number
        /// </summary>
        public string Value
        {
            get
            {
                return this.ToString( );
            }
            set
            {
                store = value;
            }
        }
        /// <summary>
        /// returns the current value of the number
        /// </summary>
        /// <returns></returns>
        public override string ToString( )
        {
            return store;
        }
        #endregion

        #region trimming
        /// <summary>
        /// the number of chars to return, starting from the least significant value. -1 to disable
        /// </summary>
        public int Trimlimit
        {
            get
            {
                return keepChars;
            }
            set
            {
                keepChars = value;
                store = trim( store );
            }
        }

        int keepChars = -1;

        private string trim( string val )
        {
            if( keepChars != -1 )
            {
                if( val.Length > keepChars )
                {
                    val = val.Substring( val.Length - keepChars );
                }
            }
            return val;
        }
        #endregion

        #region addition
        /// <summary>
        /// adds the specified number to the value held by this number
        /// </summary>
        /// <param name="value"></param>
        public void add( Integer value )
        {
            value.Value = trim( value.Value );
            store = trim( store );
            if( store.Length > value.ToString( ).Length )
            {
                store = trim( add( value.ToString( ).PadLeft( store.Length, '0' ), 0, store ) );
            }
            else if( store.Length == value.ToString( ).Length )
            {
                store = trim( add( value.ToString( ), 0, store ) );
            }
            else if( store.Length < value.ToString( ).Length )
            {
                store = store.PadLeft( value.ToString( ).Length, '0' );
                store = trim( add( value.ToString( ), 0, store ) );
            }
            else
            {
                throw new InvalidOperationException( );
            }


        }

        private string add( string value, int carry, string oldvalue )
        {
            if( value.Length == 0 )
                return carry == 0 ? "" : carry.ToString( );

            int originalVal = int.Parse( oldvalue.Substring( oldvalue.Length - 1, 1 ) );
            int addingVal = int.Parse( value.Substring( value.Length - 1, 1 ) );

            int newVal = originalVal + addingVal + carry;
            string newString = newVal.ToString( );
            if( newString.Length > 1 )
            {
                carry = int.Parse( newString.Substring( 0, newString.Length - 1 ) );
                newString = newString.Substring( newString.Length - 1 );
            }
            else
            {
                carry = 0;
            }

            return add( value.Substring( 0, value.Length - 1 ), carry, oldvalue.Substring( 0, oldvalue.Length - 1 ) ) + newString;


        }
        #endregion

        #region multiplication
        /// <summary>
        /// multiplies the specified value with the value held by this number.
        /// </summary>
        /// <param name="value"></param>
        public void multiply( short value )
        {
            Integer orig = new Integer( );
            orig.Value = store;

            while( value > 1 )
            {
                this.add( orig );
                value--;
            }

        }
        /// <summary>
        /// multiplies the specified number with the value held by this number.
        /// </summary>
        /// <param name="value"></param>
        public void multiply( Integer value )
        {
            store = multiplyValue( value, store );
        }

        private string multiplyValue( Integer value, string original )
        {
            ArrayList answers = new ArrayList( );
            for( int i = 0; i < value.Value.Length; i++ )
            {
                Integer currAns = new Integer( );
                // prepend zeroes
                currAns.Value = "";
                currAns.Value.PadRight( i, '0' );
                for( int x = 0; x < i; x++ )
                {
                    currAns.Value += "0";
                }

                int carry = 0;
                for( int j = original.Length; j != 0; j-- )
                {
                    int result = ( int.Parse( value.Value.Substring( value.Value.Length - ( i + 1 ), 1 ) ) * int.Parse( original.Substring( j - 1, 1 ) ) ) + carry;

                    string resultstr = result.ToString( );

                    if( resultstr.Length > 1 )
                    {
                        carry = int.Parse( resultstr.Substring( 0, resultstr.Length - 1 ) );
                        resultstr = resultstr.Substring( resultstr.Length - 1 );
                    }
                    else
                    {
                        carry = 0;
                    }
                    currAns.Value = resultstr + currAns.Value;
                }
                currAns.Value = carry + currAns.Value;
                answers.Add( currAns );

            }

            Integer export = new Integer( );
            export.Value = "0";
            foreach( Integer item in answers )
            {
                export.add( item );
            }
            return trim( export.Value );
        }

        /// <summary>
        /// raises the stored value within this number to the exponent provided.
        /// </summary>
        /// <param name="exponent"></param>
        public void pow( int exponent )
        {
            Integer orig = new Integer( );
            orig.Value = trim( store );

            while( exponent > 1 )
            {
                this.multiply( orig );
                exponent--;
                store = trim( store );
            }

            store = store.TrimStart( '0' );

        }

        /// <summary>
        /// calculates the factorial of the value stored in this number.
        /// </summary>
        public void factorial( )
        {
            store = factorial( this );
        }

        private string factorial( Integer value )
        {
            if( value.Value.TrimStart( '0' ) == "" )
                return "1";

            Integer one = new Integer( );
            one.Value = "1";
            Integer valminusone = new Integer( );
            valminusone.Value = subtractValue( value, one );
            return trim( multiplyValue( value, factorial( valminusone ) ).TrimStart( '0' ) );
        }
        #endregion

        #region subtraction
        private string subtractValue( Integer value, Integer subractor )
        {
            if( value.Value.Length > subractor.Value.Length )
            {
                subractor.Value = subractor.Value.PadLeft( value.Value.Length, '0' );
                return doSubtract( value.Value, subractor.Value ).TrimStart( '0' );
            }
            else if( value.Value.Length == subractor.Value.Length )
            {
                return doSubtract( value.Value, subractor.Value ).TrimStart( '0' );
            }
            else if( value.Value.Length < subractor.Value.Length )
            {
                value.Value = value.Value.PadLeft( subractor.Value.Length, '0' );
                return doSubtract( value.Value, subractor.Value ).TrimStart( '0' );
            }
            else
                throw new InvalidOperationException( );
        }

        /// <summary>
        /// subtracts the value of the specified number from the current number.
        /// </summary>
        /// <param name="value"></param>
        public void subtract( Integer value )
        {
            Integer foo = new Integer( );
            foo.Value = store;
            store = subtractValue( foo, value );
        }

        private string doSubtract( string value, string subtractor )
        {
            string result = "";

            for( int i = value.Length - 1; i >= 0; i-- )
            {
                int v = int.Parse( value.Substring( i, 1 ) );
                int s = int.Parse( subtractor.Substring( i, 1 ) );
                int r = 0;
                if( s > v )
                    r = subtractionNeedMore( ref value, i, s );
                else
                {
                    r = v - s;
                }
                string res = r.ToString( );

                result = res + result;

            }

            return trim( result );

        }

        private int subtractionNeedMore( ref string number, int i, int subtractor )
        {
            int biggernum = 0;
            if( int.Parse( number.Substring( i - 1, 1 ) ) == 0 )
                biggernum = subtractionNeedMore( ref number, i - 1, 1 );
            else
            {
                biggernum = int.Parse( number.Substring( i - 1, 1 ) );
                biggernum--;
            }
            int newval = int.Parse( number.Substring( i, 1 ) ) + 10 - subtractor;

            number = number.Substring( 0, i - 1 ) + biggernum.ToString( ) + number.Substring( i );
            return newval;

        }
        #endregion

        /// <summary>
        /// divides this number by provided divisor number, result stored by this number.
        /// </summary>
        /// <param name="divisor"></param>
        /// <returns>remainder</returns>
        public Integer slowDivide( Integer divisor )
        {
            Integer counter = new Integer( );
            Integer incrementor = new Integer( );
            incrementor.Value = "1";
            counter.Value = "0";
            while( isBiggerThan( divisor ) )
            {
                counter.add( incrementor );
                this.subtract( divisor );
            }
            Integer remainder = new Integer( );
            remainder.Value = store;
            store = counter.Value;
            return remainder;
        }

        /// <summary>
        /// true if I am bigger than it.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool isBiggerThan( Integer value )
        {
            return isBiggerThan( store, value.Value );
        }

        private bool isBiggerThan( string me, string thee )
        {
            me = me.TrimStart( '0' );
            thee = thee.TrimStart( '0' );

            if( me.Length > thee.Length )
                return true;
            else if( me.Length < thee.Length )
                return false;
            else
                return cutupBiggerThan( me, thee );
        }

        private bool cutupBiggerThan( string me, string thee )
        {
            if( me.Length == 0 )
                return true;

            if( int.Parse( me.Substring( 0, 1 ) ) > int.Parse( thee.Substring( 0, 1 ) ) )
                return true;
            else if( int.Parse( me.Substring( 0, 1 ) ) < int.Parse( thee.Substring( 0, 1 ) ) )
                return false;
            else
                return cutupBiggerThan( me.Substring( 1 ), thee.Substring( 1 ) );
        }

        /// <summary>
        /// divides
        /// </summary>
        /// <param name="divisor"></param>
        /// <returns>remainder</returns>
        public Integer divide( Integer divisor )
        {
            if( !isBiggerThan( divisor ) )
                throw new ArgumentOutOfRangeException( );

            Integer dividend = new Integer( );
            dividend.Value = store.Substring( 0, divisor.Value.Length - 1 );
            string answer = "";

            for( int pos = divisor.Value.Length - 1; pos < store.Length; pos++ )
            {
                dividend.Value += store.Substring( pos, 1 );

                int count = 0;
                while( isBiggerThan( dividend.Value, divisor.Value ) )
                {
                    dividend.subtract( divisor );
                    count++;
                }

                answer += count.ToString( );
            }

            store = answer;
            return dividend;
        }
    }
}
