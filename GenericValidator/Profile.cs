using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GenericValidator
{
    public class Profile
    {
        public Dictionary<dynamic, Dictionary<string,dynamic>> configs = new Dictionary<dynamic, Dictionary<string, dynamic>>();
        protected ConfigurationBuilder<T> CreateConfig<T>()
        {
            try
            {
                return ConfigurationBuilder<T>.GetBuilder();
            }
            finally
            {
                configs.Add(typeof(T), ConfigurationBuilder<T>.GetBuilder().GetConfiguration());
            }
        }
    }
}
