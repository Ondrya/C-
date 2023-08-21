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
