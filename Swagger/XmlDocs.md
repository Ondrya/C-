[More info on dotnetnakama...](https://www.dotnetnakama.com/blog/enriched-web-api-documentation-using-swagger-openapi-in-asp-dotnet-core/)

For multi proj solution

```csharp
builder.Services.AddSwaggerGen(c =>
{
    ....
    ...
    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    foreach (string fileName in xmlFiles)
    {
        string xmlFilePath = Path.Combine(AppContext.BaseDirectory, fileName);
        if (File.Exists(xmlFilePath))
            c.IncludeXmlComments(xmlFilePath, includeControllerXmlComments: true);
    }
});
```
