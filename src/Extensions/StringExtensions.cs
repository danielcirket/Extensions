using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Extensions
{
    public static class StringExtensions
    {
        private static readonly Dictionary<Type, Delegate> _parseLookup = new Dictionary<Type, Delegate>();

        public static bool HasValue(this string source) => !string.IsNullOrEmpty(source);
        public static bool IsBlank(this string source) => string.IsNullOrEmpty(source);
        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrWhiteSpace(source);
        public static int ToInt(this string source, int defaultValue = 0)
        {
            int result;
            return (!source.IsNullOrWhiteSpace() && int.TryParse(source, out result))
                ? result
                : defaultValue;
        }
        public static decimal ToDecimal(this string source, decimal defaultValue = 0)
        {
            decimal result;
            return (!source.IsNullOrWhiteSpace() && decimal.TryParse(source, out result))
                ? result
                : defaultValue;
        }
        public static float ToFloat(this string source, float defaultValue = 0)
        {
            float result;
            return (!source.IsNullOrWhiteSpace() && float.TryParse(source, out result))
                ? result
                : defaultValue;
        }
        public static double ToDouble(this string source, double defaultValue = 0)
        {
            double result;
            return (!source.IsNullOrWhiteSpace() && double.TryParse(source, out result))
                ? result
                : defaultValue;
        }
        public static string RemoveWhiteSpace(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new string(source.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
        public static string UpperCaseWords(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var characters = source.ToCharArray();

            if (characters.Length >= 1 && char.IsLower(characters[0]))
                characters[0] = char.ToUpper(characters[0]);

            for (int i = 1; i < characters.Length; i++)
            {
                if (char.IsWhiteSpace(characters[i - 1]) && char.IsLower(characters[i]))
                    characters[i] = char.ToUpper(characters[i]);
            }

            return new string(characters);
        }
        public static string CameliseWords(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Replace('_', ' ').Replace('-', ' ').UpperCaseWords().Replace(" ", "");
        }
        public static T ToEnum<T>(this string source, bool ignoreCase = true) where T : struct
        {
            return (T)Enum.Parse(typeof(T), source, ignoreCase);
        }
        public static bool Contains(this string source, string find, StringComparison comparison)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            // Return true if find is empty as per the contains method documentation.
            // See: https://msdn.microsoft.com/en-us/library/dy85x1sa%28v=vs.110%29.aspx 
            if (find.IsNullOrWhiteSpace())
                return true;

            return source.IndexOf(find, comparison) >= 0;
        }
        public static string Truncate(this string source, int maxLength)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (maxLength < 0)
                throw new ArgumentOutOfRangeException("Maximum length must be greater than 0.", nameof(maxLength));

            if (string.IsNullOrEmpty(source))
                return source;

            return source.Length <= maxLength
                ? source
                : source.Substring(0, maxLength);
        }
        public static string TrimStart(this string source, string find)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            while (source.StartsWith(find))
            {
                var index = -1;

                while ((index = source.IndexOf(find)) == 0)
                    source = source.Substring(index + find.Length, source.Length - find.Length);
            }

            return source;
        }
        public static string TrimEnd(this string source, string find)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var index = -1;

            while (source.EndsWith(find))
            {
                index = source.LastIndexOf(find);

                source = source.Substring(0, index);
            }

            return source;
        }
        public static string Trim(this string source, string find)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source = source.TrimStart(find).TrimEnd(find);

            return source;
        }
        /// <summary>
        /// Uses the TryParse method which takes a string input if available to then parse the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T Parse<T>(this string source, T defaultValue = default(T))
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.IsBlank())
                return defaultValue;

            var type = typeof(T);

            Delegate result = null;

            if (!_parseLookup.TryGetValue(type, out result))
            {
                MethodInfo methodInfo = null;
                MethodCallExpression methodCall = null;

                var methodName = "TryParse";
                var typeInfo = type.GetTypeInfo();
                if (typeInfo.IsEnum)
                {
                    type = typeof(Enum);

                    // TODO(Dan): Additional Checks to make sure this is always the correct method.
                    methodInfo = type.GetMethods()
                                     .Where(mi =>
                                                mi.ContainsGenericParameters
                                            )
                                     .First().MakeGenericMethod(typeof(T));
                }
                else
                {

                    methodInfo = type.GetMethod(
                                        methodName,
                                        new[]
                                            {
                                            typeof(string),
                                            typeof(T).MakeByRefType()
                                            });
                }

                if (methodInfo == null)
                    throw new MissingMethodException($"{methodName} could not be found for type {type.FullName}");

                if (!methodInfo.IsStatic)
                    throw new ArgumentException("The provided method must be static.", nameof(methodInfo));

                var parameters = methodInfo.GetParameters()
                                     .Select(parameter => Expression.Parameter(parameter.ParameterType, parameter.Name))
                                     .ToList();

                methodCall = Expression.Call(null, methodInfo, parameters);

                result = Expression.Lambda(methodCall, parameters.ToArray()).Compile();

                _parseLookup[type] = result;
            }

            if (result != null)
            {
                var parameters = new object[] { source, default(T) };

                return (bool)result.DynamicInvoke(parameters)
                            ? (T)parameters[1]
                            : defaultValue;
            }

            return defaultValue;
        }
    }
}
