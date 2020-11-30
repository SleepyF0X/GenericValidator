using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GenericValidator
{
    public class Validator
    {
        private static Validator _instance;
        private static Profile _profile;
        private Dictionary<string, Exception> _exceptions = new Dictionary<string, Exception>();
        public static dynamic Validate(dynamic model)
        {
            return true;
        }

        private Validator() { }

        public static Validator GetValidator(Profile profile)
        {
            _profile = profile;
            return _instance ?? (_instance = new Validator());
        }

        public dynamic Validate(params dynamic[] models)
        {
            try
            {
                foreach (dynamic model in models)
                {
                    if (_profile.configs.ContainsKey(model.GetType()))
                    {
                        Dictionary<string, dynamic> config = _profile.configs[model.GetType()];
                        System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();
                        foreach (var property in properties)
                        {
                            if (config.ContainsKey(property.Name))
                            {
                                if (config[property.Name](property.GetValue(model)).GetType().IsSubclassOf(typeof(Exception)))
                                {
                                    _exceptions.Add("Model number: " + Array.IndexOf(models, model) + "\n  Property name: " + property.Name, config[property.Name](property.GetValue(model)));
                                }
                            }
                        }
                    }
                }
                return true;
            }
            finally
            {
                string exceptions = "\n";
                foreach (var exceptionInfo in _exceptions)
                {
                    exceptions += exceptionInfo.Key + "\n"+"     Exception: " + exceptionInfo.Value.ToString() + "\n + \n";
                }
                throw new Exception(exceptions);
            }
        }
    }
}
