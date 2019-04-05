//+pkg=Newtonsoft.Json.12.0.2-beta1
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace Karopapier
{
    
    public class karoTest
    {
        public static void karoTestprint()
        {
            Console.WriteLine("print test");
        }
        public static void karoGetRequestTest()
        {
            Uri uri = new Uri("http:"+"/"+"/www.karopapier.de/api/users/2791");
           // string rurl = "http://www.karopapier.de";
            Console.WriteLine(uri);
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(uri); 
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse(); 
            // Display the status.  
            Console.WriteLine (((HttpWebResponse)response).StatusDescription); 
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream(); 
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream); 
            // Read the content.  
            string responseFromServer = reader.ReadToEnd(); 
            // Display the content.  
            Console.WriteLine(responseFromServer); 
            // Clean up the streams and the response.  
            reader.Close(); 
            response.Close();
        }
    }
    
    public class karoRequest
    {
        
        public static string karoUrl(string param1switch, string param2url)
        {
            const string prefix="http:/";
            const char slash='/';
            const string host="www.karopapier.de/";
            const string api="api/";
            const string users="users/";
            string karoApiUrl="";
            
            switch (param1switch)
            {
                case "userInfo":
                karoApiUrl=prefix+slash+host+api+users+param2url;
                Console.WriteLine(karoApiUrl);
                break;
            }
            
            return karoApiUrl;
        }
        
        public static string karoGetRequest (string getUrl)
        {
            Uri uri = new Uri(getUrl);
            Console.WriteLine(uri);
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(uri); 
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse(); 
            // Display the status.  
            Console.WriteLine (((HttpWebResponse)response).StatusDescription); 
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream(); 
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream); 
            // Read the content.  
            string responseFromServer = reader.ReadToEnd(); 
            // Display the content.  
            Console.WriteLine(responseFromServer); 
            // Clean up the streams and the response.  
            reader.Close(); 
            response.Close();
            return responseFromServer;
        }
    }
}

/*
            Uri uri = new Uri("http:"+"/"+"/www.karopapier.de");
           // string rurl = "http://www.karopapier.de";
            Console.WriteLine(uri);
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(uri); 
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse(); 
            // Display the status.  
            Console.WriteLine (((HttpWebResponse)response).StatusDescription); 
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream(); 
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream); 
            // Read the content.  
            string responseFromServer = reader.ReadToEnd(); 
            // Display the content.  
            Console.WriteLine(responseFromServer); 
            // Clean up the streams and the response.  
            reader.Close(); 
            response.Close(); 
*/