//1. Avoid using Contains. It degrades performance heavily. See this post

//2. ToList() is a command to execute your query. Till you call ToList() method, linq query is not started as linq has a feature called deferred execution. So if you call ToList(), you start some real operations with Databaseof files.

//3. reducing columns of table reduces bandwidth required(delete unnecessary columns from your query)
//4. turn off change-tracking and identity-management (for example, ObjectTrackingEnabled in LINQ-to-SQL)

using (YourDataContext dataContext = new YourDataContext())    
{
    dataContext.ObjectTrackingEnabled = false;    
    //Your code
}
//5. Use one of the tuning options of EF such as .AsNoTracking(). The extensive description can be seen here.
//6. use a pre-compiled query. It sometimes reduces pre-processing overheads
