using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IOptions"/>.
    /// </summary>
    public static class OptionsExtensions
    {
        #region Methods

        /// <summary>
        /// Attempts to get the value associated with the specified key and returns the given default if a matching value isn't found.
        /// </summary>
        /// <typeparam name="T">Option type being requested.</typeparam>
        /// <param name="options">Option source.</param>
        /// <param name="key">Option key.</param>
        /// <param name="defaultValue">Default value to return if the option isn't found.</param>
        /// <remarks><see cref="IOptions"/> only supports string dictionary keys at present.</remarks>
        public static T GetValueOrDefault<T>(
            this IOptions<Dictionary<string, T>> options,
            string key,
            T defaultValue = default(T))
        {
            T value = default(T);
            bool gotValue = options != null && options.Value.TryGetValue(key, out value);
            return gotValue ? value : defaultValue;
        }

        /// <summary>
        /// Attempts to get the value associated with the specified key and returns a new instance if a matching value isn't found.
        /// </summary>
        /// <typeparam name="T">Option type being requested.</typeparam>
        /// <param name="options">Option source.</param>
        /// <param name="key">Option key.</param>
        /// <remarks><see cref="IOptions"/> only supports string dictionary keys at present.</remarks>
        public static T GetValueOrNew<T>(this IOptions<Dictionary<string, T>> options, string key) where T : new()
        {
            T value = default(T);
            bool gotValue = options != null && options.Value.TryGetValue(key, out value);
            return gotValue ? value : new T();
        }

        #endregion Methods
    }
}
