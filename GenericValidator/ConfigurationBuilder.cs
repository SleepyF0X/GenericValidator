﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GenericValidator
{
    public class ConfigurationBuilder<T>
    {
        private const string ExpressionCannotBeNullMessage = "The expression cannot be null.";
        private const string InvalidExpressionMessage = "Invalid expression.";
        private readonly OptionBuilder _optionBuilder = new OptionBuilder();
        private static ConfigurationBuilder<T> _instance;
        private readonly Dictionary<string, dynamic> _configuration = new Dictionary<string, dynamic>();
        public delegate dynamic OptionConfigurator(OptionBuilder prop);

        private delegate dynamic CustomOption(params dynamic[] param);

        private ConfigurationBuilder() { }

        public static ConfigurationBuilder<T> GetBuilder()
        {
            return _instance ?? (_instance = new ConfigurationBuilder<T>());
        }
        public Dictionary<string, dynamic> GetConfiguration()
        {
            return _configuration;
        }
        public ConfigurationBuilder<T> ForProperty(Expression<Func<T, object>> property, OptionConfigurator optionConfig)
        {
            var propertyName = GetMemberName(property.Body);
            var option = optionConfig.Invoke(_optionBuilder);
            ConfigurationAdd(propertyName, option);
            return _instance;
        }
        public ConfigurationBuilder<T> ForPropertyCustom(Expression<Func<T, object>> property, Func<dynamic, dynamic> option)
        {
            var propertyName = GetMemberName(property.Body);
            ConfigurationAdd(propertyName, option);
            return _instance;
        }
        public ConfigurationBuilder<T> ForPropertyCustoms(Expression<Func<T, object>> property, Func<dynamic, dynamic> option)
        {
            var propertyName = GetMemberName(property.Body);
            ConfigurationAdd(propertyName, option);
            return _instance;
        }

        private static string GetMemberName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(ExpressionCannotBeNullMessage);
            }

            if (expression is MemberExpression memberExpression)
            {
                // Reference type property or field
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression methodCallExpression)
            {
                // Reference type method
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression unaryExpression)
            {
                // Property, field of method returning value type
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException(InvalidExpressionMessage);
        }

        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression methodExpression)
            {
                return methodExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }

        private void ConfigurationAdd(string key, dynamic option)
        {
            if (_configuration.ContainsKey(key))
            {
                _configuration.Remove(key);
            }
            _configuration.Add(key, option);
        }
    }
}
