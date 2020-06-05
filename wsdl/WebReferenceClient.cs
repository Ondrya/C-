using System;
using System.Net;
using System.ServiceModel;

namespace Console
{
    class Program
    {
        private static readonly BasicHttpBinding Binding = new BasicHttpBinding
        {
            Name = "basicHttpBinding",
            MaxBufferSize = 2147483647,
            MaxReceivedMessageSize = 2147483647,

            SendTimeout = new TimeSpan(0, 0, 30),
            OpenTimeout = new TimeSpan(0, 0, 30),
            ReceiveTimeout = new TimeSpan(0, 0, 30)
        };


        static void Main(string[] args)
        {
            var endPoint = new EndpointAddress("****?wsdl");

			using ( var client = new [replace for WebReferenceNameSpace].NameOfClient() 
				{ 
					Credentials = new NetworkCredential("login", "password") 
				} ) 
				{
					/// working ... invokeing methods ...
				}
        }
    }
}
