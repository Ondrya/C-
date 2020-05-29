using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _namespace
{
    class App
    {
        /// <summary>
        /// Получаем сериализованную строку с прежними значениями объекта.
        /// </summary>
        /// <param name="newObject"></param>
        /// <param name="oldObject"></param>
        /// <param name="ignoreProperties"></param>
        /// <returns></returns>
        public static string GetChanges(object newObject, object oldObject, List<string> ignoreProperties = null)
        {
            var oType = oldObject.GetType();
            var kvp = new Dictionary<string, string>();

            foreach (var oProperty in oType.GetProperties())
            {
                if (ignoreProperties != null && ignoreProperties.Contains(oProperty.Name)) continue;
                var oOldValue = oProperty.GetValue(oldObject, null);
                var oNewValue = oProperty.GetValue(newObject, null);
                // this will handle the scenario where either value is null
                if (!object.Equals(oOldValue, oNewValue))
                    kvp.Add(oProperty.Name, oOldValue == null ? "null" : oOldValue.ToString());

            }

            return JsonConvert.SerializeObject(kvp);
        }
    }
}
