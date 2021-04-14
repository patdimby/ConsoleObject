using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleObject
{
    public static class ObjectExtensions
    {     

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
                    if(vTypeName == primType)
                    {
                        t.SetValue(dest, value);
                    }                    
                }
            }
        }

        private static bool IsNumeric(this object obj)
        {
            string s = obj.ToString();
            if (!Regex.IsMatch(s, @"^\d+$")) return false;
            var r = double.Parse(s);
            return !(Math.Abs(r) < 0.0001);
        }

        private static bool IsValidString(this object obj)
        {
            string s = obj.ToString();
            return s.Length > 0;
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
                if (value != null)
                {
                    if (value.IsNumeric() || value.IsValidString())
                    { result.Add(t.Name, value); }
                }
            }

            return result;
        }
    }
}