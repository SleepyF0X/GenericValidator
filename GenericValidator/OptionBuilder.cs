using System;
using System.Collections.Generic;
using System.Text;

namespace GenericValidator
{
    public class OptionBuilder
    {
        private Func<dynamic, dynamic> _function;
        public Func<dynamic, dynamic> String(int minLength, int maxLength)
        {
            _function = str =>
            {
                if (string.IsNullOrEmpty(str)) return new ArgumentNullException(nameof(str));
                if(str.Length < minLength || str.Length > maxLength) return new ArgumentException(nameof(str));
                return true;
            };
            return _function;
        }
        public Func<dynamic, dynamic> Number(int minValue, int maxValue)
        {
            _function = number =>
            {
                if (number < minValue || number > maxValue) return new ArgumentException(nameof(number));
                return true;
            };
            return _function;
        }
    }
}
