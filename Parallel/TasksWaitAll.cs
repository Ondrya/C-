List<string> strings = new List<string> { "s1", "s2", "s3" };
List<Task> Tasks = new List<Task>();
foreach (var s in strings)
{
       Tasks.Add(Task.Run(() => DoSomething(s)));
}
await Task.WhenAll(Tasks);
