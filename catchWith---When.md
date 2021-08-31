```csharp

public static async Task<string> MakeRequest()
{
  var client = new System.Net.Http.HttpClient();
  var streamTask = client.GetStringAsync("https://auth0.com/this-page-doesnt-exist");

  try
  {
    var responseText = await streamTask;
    return responseText;
  }
  catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.MovedPermanently)
  {
    return "The page moved.";
  }
  catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.NotFound)
  {
    return "The page was not found";
  }
  catch (HttpRequestException e)
  {
    return e.Message;
  }
}

```
