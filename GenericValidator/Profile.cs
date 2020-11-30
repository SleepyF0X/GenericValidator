using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GenericValidator
{
    public class Profile
    {
        internal readonly Dictionary<dynamic, Dictionary<string,dynamic>> _configs = new Dictionary<dynamic, Dictionary<string, dynamic>>();
        protected ConfigurationBuilder<T> CreateConfig<T>()
        {
            try
            {
                return ConfigurationBuilder<T>.GetBuilder();
            }
            finally
            {
                if (_configs.ContainsKey(typeof(T)))
                {
                    _configs.Remove(typeof(T));
                }
                _configs.Add(typeof(T), ConfigurationBuilder<T>.GetBuilder().GetConfiguration());
            }
        }
    }
}
