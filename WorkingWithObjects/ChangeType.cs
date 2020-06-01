/// <summary>
/// Приведение к типу с проверкой на nullable
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="value"></param>
/// <returns></returns>
public static T ChangeType<T>(object value) 
{
   var t = typeof(T);

   if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) 
   {
       if (value == null) 
       { 
           return default(T); 
       }

       t = Nullable.GetUnderlyingType(t);
   }

   return (T)Convert.ChangeType(value, t);
}
