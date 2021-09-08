Если нам надо получить читаемый текст без \u, то сериализовать можно так.
Но при этом надо помнить про спецсимволы, которые могут поломать валидный json документ

```csharp
JsonSerializerOptions jso = new JsonSerializerOptions();
jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

var a = new A { Name = "你好" };
var s = JsonSerializer.Serialize(a, jso);        
Console.WriteLine(s);
```
