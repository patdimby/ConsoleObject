using System.Collections.Generic;

namespace ConsoleObject
{
    public static class ObjectExtensions
    {
        private static bool IsDefault<T>(this T val)
        {
            return EqualityComparer<T>.Default.Equals(val, default(T));
        }

        public static void BuiltInCast(object dest, object src)
        {
            var dict = src.ObjectToDictionary();
            if (dict.Count < 1)
            {
                return;
            }

            var myType = dest.GetType();
            foreach (var t in myType.GetProperties())
            {
                // Name of property.
                var key = t.Name;
                // Type of property.
                var primType = t.PropertyType.Name;
                // Check if key exist in dictionary.
                if (dict.ContainsKey(key))
                {
                    // The value in dictionary.
                    var value = dict[key];
                    var vTypeName = value.GetType().Name;
                    if (vTypeName == primType)
                    {
                        t.SetValue(dest, value);
                    }
                }
            }
        }

        private static Dictionary<string, object> ObjectToDictionary(this object obj)
        {
            // Get the type of 'obj'.
            var myType = obj.GetType();
            // Initialize a dictionary.
            var result = new Dictionary<string, object>();
            foreach (var t in myType.GetProperties())
            {
                var value = t.GetValue(obj, null);
                if (!value.IsDefault())
                {
                    result.Add(t.Name, value);
                }
            }

            return result;
        }
    }
}