        /// <summary>
        /// Устанавливаем новое занчение поля
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        public static void SetPropertyValue(object obj, string propertyName, object propertyValue)
        {
            if (obj == null || string.IsNullOrWhiteSpace(propertyName)) return;
            
            Type objectType = obj.GetType();

            PropertyInfo propertyDetail = objectType.GetProperty(propertyName);


            if (propertyDetail != null && propertyDetail.CanWrite)
            {
                Type propertyType = propertyDetail.PropertyType;

                Type dataType = propertyType;

                // Check for nullable types
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Check for null or empty string value.
                    if (propertyValue == null || string.IsNullOrWhiteSpace(propertyValue.ToString()))
                    {
                        propertyDetail.SetValue(obj, null);
                        return;
                    }
                    else
                    {
                        dataType = propertyType.GetGenericArguments()[0];
                    }
                }


                propertyValue = AppChangeType(propertyValue, propertyType);

                propertyDetail.SetValue(obj, propertyValue);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversion"></param>
        /// <returns></returns>
        public static object AppChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString() == "null")
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
