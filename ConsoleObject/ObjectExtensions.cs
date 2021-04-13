using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web.Helpers;


namespace ConsoleObject
{
    public static class ObjectExtensions
    {
        public static bool CanBeConverted<T>(this object value) where T : class
        {
            var jsonData = JsonConvert.SerializeObject(value);
            var generator = new JSchemaGenerator();
            var parsedSchema = generator.Generate(typeof(T));
            var jObject = JObject.Parse(jsonData);
            return jObject.IsValid(parsedSchema);
        }

        public static object JsonParseToObject(this object source)
        {
            var jsonString = JsonConvert.SerializeObject(source);
            return Json.Decode(jsonString);
        }

        private static Dictionary<string, object> Dyn2Dict(dynamic dynObj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
            {
                object obj = propertyDescriptor.GetValue(dynObj);
                dictionary.Add(propertyDescriptor.Name, obj);
            }

            return dictionary;
        }

        private static T DictionaryToObject<T>(IDictionary<string, object> dictionary) where T : class
        {
            return DictionaryToObject(dictionary) as T;
        }

        private static dynamic DictionaryToObject(IDictionary<string, object> dictionary)
        {
            var expandoObj = new ExpandoObject();
            var expandoObjCollection = (ICollection<KeyValuePair<string, object>>) expandoObj;
            foreach (var keyValuePair in dictionary)
            {
                expandoObjCollection.Add(keyValuePair);
            }

            dynamic eoDynamic = expandoObj;
            return eoDynamic;
        }

        public static Dictionary<string, object> ObjectToDictionary(this object obj)
        {
            // Get the type of 'obj'.
            Type myType = obj.GetType();
            // Initialize a dictionary.
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (var t in myType.GetProperties())
            {
                var value = t.GetValue(obj, null);
                if (value != null)
                {
                    result.Add(t.Name, value);
                }
            }

            return result;
        }

        public static T ConvertToType<T>(this object value) where T : class
        {
            var jsonData = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static T ConvertDynamicType<T>(dynamic value) where T : class
        {
            var jsonData = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }


        public static void CopyNotNulls<T>(T source, T dest)
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsClass)
                .ToArray();
            foreach (var property in properties)
            {
                var val = property.GetValue(source);
                if (val == null)
                {
                    continue;
                }

                property.SetValue(dest, val);
            }
        }
    }
}