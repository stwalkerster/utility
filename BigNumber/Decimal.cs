using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.BigNumber
{
    public class Decimal
    {
                #region hideme
        string _store ="0";
        int _fractionalLimit = 100;
        int _numerator = 0;
        int _denominator = 0;
        public string fractionalPart
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        public int fractionalLimit
        {
            get
            {
                return _fractionalLimit;
            }
            set
            {
                _fractionalLimit = value;
            }
        }

        public Decimal( )
        {
            _store = "0";
        }
        public Decimal(string fractionalPart )
        {
            _store = fractionalPart;
        }
        #endregion
        public Decimal( int numerator, int denominator )
        {


            if ( numerator >= denominator )
                throw new ArgumentOutOfRangeException( "whole numbers represented by fraction" );

            _numerator = numerator;
            _denominator = denominator;

            

        }

        public void calculate( )
        {
            string ns = _numerator.ToString( );
            string ds = _denominator.ToString( );

            //   int pointLocation = ns.Length;

            ns = ns.PadRight( ns.Length + _fractionalLimit, '0' );

            Integer num = new Integer( );
            num.Value = ns;
            Integer denom = new Integer( );
            denom.Value = ds;

            num.divide( denom );

            _store = num.Value;

            if ( _numerator.ToString( ).Length == _denominator.ToString( ).Length )
                _store = _store.Substring( 1 );
            else
            {
                _store = _store.PadLeft( ( ( ( _denominator.ToString( ).Length - _numerator.ToString( ).Length ) - 1 ) + _store.Length ), '0' );
            }
        }

        public override string ToString( )
        {
            return "0." + _store;
        }


    }
}
