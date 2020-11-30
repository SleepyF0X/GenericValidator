using System;
using System.Collections.Generic;

namespace GenericValidator
{
    public class Validator
    {
        private static Validator _instance;
        private static Profile _profile;
        private readonly Dictionary<string, Exception> _exceptions = new Dictionary<string, Exception>();
        private Validator(Profile profile)
        {
            _profile = profile;
        }

        public static Validator GetValidator(Profile profile)
        {
            //return _instance ?? (_instance = new Validator());
            return new Validator(profile);
        }

        public Dictionary<string, Exception> Validate(params dynamic[] models)
        {
            try
            {
                foreach (var model in models)
                {
                    if (!_profile._configs.ContainsKey(model.GetType())) continue;
                    Dictionary<string, dynamic> config = _profile._configs[model.GetType()];
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
                return _exceptions;
            }
            finally
            {
                //string exceptions = "\n";
                //foreach (var exceptionInfo in _exceptions)
                //{
                //    exceptions += exceptionInfo.Key + "\n"+"     Exception: " + exceptionInfo.Value.ToString() + "\n + \n";
                //}
                //throw new Exception(exceptions);
            }
        }
        public Dictionary<string, Exception> Validate(List<dynamic> models)
        {
            try
            {
                foreach (var model in models)
                {
                    if (!_profile._configs.ContainsKey(model.GetType())) continue;
                    Dictionary<string, dynamic> config = _profile._configs[model.GetType()];
                    System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        if (config.ContainsKey(property.Name))
                        {
                            if (config[property.Name](property.GetValue(model)).GetType().IsSubclassOf(typeof(Exception)))
                            {
                                _exceptions.Add("Model number: " + models.IndexOf(model) + "\n  Property name: " + property.Name, config[property.Name](property.GetValue(model)));
                            }
                        }
                    }
                }
                return _exceptions;
            }
            finally
            {
                //string exceptions = "\n";
                //foreach (var exceptionInfo in _exceptions)
                //{
                //    exceptions += exceptionInfo.Key + "\n"+"     Exception: " + exceptionInfo.Value.ToString() + "\n + \n";
                //}
                //throw new Exception(exceptions);
            }
        }
        public Dictionary<string, Exception> Validate<T>(List<T> models)
        {
            try
            {
                foreach (dynamic model in models)
                {
                    if (!_profile._configs.ContainsKey(model.GetType())) continue;
                    Dictionary<string, dynamic> config = _profile._configs[model.GetType()];
                    System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        if (config.ContainsKey(property.Name))
                        {
                            if (config[property.Name](property.GetValue(model)).GetType().IsSubclassOf(typeof(Exception)))
                            {
                                _exceptions.Add(
                                    "Model number: " + models.IndexOf(model) + "\n  Property name: " + property.Name, 
                                    config[property.Name](property.GetValue(model))
                                );
                            }
                        }
                    }
                }
                return _exceptions;
            }
            finally
            {
                //string exceptions = "\n";
                //foreach (var exceptionInfo in _exceptions)
                //{
                //    exceptions += exceptionInfo.Key + "\n"+"     Exception: " + exceptionInfo.Value.ToString() + "\n + \n";
                //}
                //throw new Exception(exceptions);
            }
        }
    }
}
