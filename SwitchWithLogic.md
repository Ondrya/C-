Add logic to switch statmen

```csharp
using System;

namespace SwitchStatmenWithLogic
{
    class Program
    {
        static void Main(string[] args)
        {
			      int score = 11;
            string result = "";

            switch (score)
            {

                case int n when (n >= 0 && n < 5):
                    result = "Я меньше 5";
                    break;
                case int n when (n >= 0 && n < 10):
                    result = "Я меньше 10";
                    break;
                default:
                    result = "Больше 9 или меньше 0 - это не цифра";
                    break;
            }

            Console.Write("Результат: ");
            Console.WriteLine(result);
        }
    }
}
```
