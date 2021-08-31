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

## Another way add logic when catch exception

If we use the when-statement, put inside a delegate which returns a bool and set a debug point inside that delegate, then we can look into the try-block. When the program reaches the delegate, then we can simply use the debugger and look into the callstack, and see where exactly the exception came from.

So, what is the when-statement and why does this work? The when-statement allows the catch-block to be executed conditionally. If the condition evaluates to true, the exception is caught and the catch-block is executed. If the condition evaluates to false, then the exception is NOT caught and continues to be handed up the callstack.

Because of the when-statement, two different scenarios can happen: Either the exception is being caught, or it is being thrown at the original position. Because the when-statement can cause these two different behaviors, the callstack has to be kept intact during the evaluation of the when-statement, just in case the exception is not being caught. And this is why our trick works: Because we put a delegate as the condition in the when-statement, we can halt the evaluation of the when-statement and then look into the still intact callstack. Thus, if the debugger reaches our delegate, the state of the try-block is conserved.

```csharp
try
{
    UnsafeMethod();
}
catch (Exception e) when (new Func(() => true)())
{
    Console.WriteLine(e);
    throw;
}
```


Where Func may be
```csharp
/// <summary>
/// Allow to see stack trace without catch error if need
/// </summary>
/// <param name="e">exception</param>
/// <param name="shouldCatch">catch exception</param>
public bool LogException(Exception e, bool shouldCatch = false)
{
    Console.WriteLine(e);
    return shouldCatch;
}
```


Using
```csharp
try
{
    UnsafeMethod();
}
catch (Exception e) when (LogException(e)) { }
```

With this, the exception is always logged. If you hand the method true via the method parameter, the exception will be suppressed. And whenever you want to debug the exception, you can put a debug point in the body of LogException() and look easily into the callstack.

And that's it. It's really a quite neat and easy to use trick, and my goto way of debugging exceptions.


Thanks to [rismosch.com](https://www.rismosch.com/article?id=a-neat-trick-to-debug-exceptions-in-c-sharp)
