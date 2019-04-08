//+pkg=Newtonsoft.Json.12.0.2-beta1
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Karopapier
{

    public class KaroTest
    {
        public static void KaroTestprint()
        {
            Console.WriteLine("print test");
        }
        public static void KaroGetRequestTest()
        {
            Uri uri = new Uri("http:" + "/" + "/www.karopapier.de/api/users/2791");
            // string rurl = "http://www.karopapier.de";
            Console.WriteLine(uri);
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(uri);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
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

    public class KaroRequest
    {

        public static string KaroUrl(string param1switch, string param2url)
        {
            const string prefix = "https:/";
            const char slash = '/';
            const string host = "www.karopapier.de/";
            const string api = "api/";
            const string users = "users/";
            const string games = "games/";
            const string queryPlayers1 = "?players=1";
            string karoApiUrl = "";

            switch (param1switch)
            {
                case "userInfo":
                    karoApiUrl = prefix + slash + host + api + users + param2url;
                    Console.WriteLine(karoApiUrl);
                    break;
                case "gameInfo":
                    karoApiUrl = prefix + slash + host + api + games + param2url + queryPlayers1;
                    Console.WriteLine(karoApiUrl);
                    break;
            }

            return karoApiUrl;
        }

        public static string KaroGetRequest(string getUrl)
        {
            try
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
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string rueckgabe = "kein user gefunden!";
            return rueckgabe;
        }
        
        public static void KaroPostRequest()
        {
            // create a request using a url that can receive a post.
            WebRequest request = WebRequest.Create("https://www.karopapier.de/login");
            // set the method property of the request to POST.
            request.Method = "POST";
        }
        
    }

    public class GetKaroUserInfo
    {
        public static void GetUser()
        {
            Console.WriteLine("userID: ");
            string id = Console.ReadLine();
            string param1 = "userInfo";
            string url = KaroRequest.KaroUrl(param1, id);
            Console.WriteLine(url);
            string userJson = KaroRequest.KaroGetRequest(url);
            Console.WriteLine(userJson);

            //pruefung, ob user gefunden wurde, da sonst kein Json-String zur konvertierung vorhanden
            if (userJson != "kein user gefunden!")
            {
                User u = JsonConvert.DeserializeObject<User>(userJson);
                Console.WriteLine(u.Id);
                Console.WriteLine(u.Login);
                Console.WriteLine(u.Color);
                Console.WriteLine(u.LastVisit);
                Console.WriteLine(u.Signup);
                Console.WriteLine(u.Dran);
                Console.WriteLine(u.ActiveGames);
                Console.WriteLine(u.AcceptsDayGames);
                Console.WriteLine(u.AcceptsNightGames);
                Console.WriteLine(u.MaxGames);
                Console.WriteLine(u.Sound);
                Console.WriteLine(u.Soundfile);
                Console.WriteLine(u.Size);
                Console.WriteLine(u.Border);
                Console.WriteLine(u.Desperate);
                Console.WriteLine(u.BirthdayToday);
                Console.WriteLine(u.KarodayToday);
                Console.WriteLine(u.Theme);
                Console.WriteLine(u.Bot);
                Console.WriteLine(u.Gamesort);
            }
        }

        //class User used for deserialize Json-String
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Color { get; set; }
            public int LastVisit { get; set; }
            public int Signup { get; set; }
            public int Dran { get; set; }
            public int ActiveGames { get; set; }
            public bool AcceptsDayGames { get; set; }
            public bool AcceptsNightGames { get; set; }
            public int MaxGames { get; set; }
            public int Sound { get; set; }
            public string Soundfile { get; set; }
            public int Size { get; set; }
            public int Border { get; set; }
            public bool Desperate { get; set; }
            public bool BirthdayToday { get; set; }
            public bool KarodayToday { get; set; }
            public string Theme { get; set; }
            public bool Bot { get; set; }
            public string Gamesort { get; set; }
        }

    }

    public class GetKaroGameInfo
    {
        public static void GetGame()
        {
            Console.WriteLine("GID: ");
            string gid=Console.ReadLine();
            string param1="gameInfo";
            string url=KaroRequest.KaroUrl(param1,gid);
            Console.WriteLine(url);
            string gameJson=KaroRequest.KaroGetRequest(url);
            Console.WriteLine(gameJson);
            Game g = JsonConvert.DeserializeObject<Game>(gameJson);
            Console.WriteLine(g.Id);
            Console.WriteLine(g.Name);
            Console.WriteLine(g.MapId);
            Console.WriteLine(g.Map.Name);
            Console.WriteLine(g.Map.Cps.Length);
            Console.WriteLine("Index 0: "+g.Map.Cps[0]+" | Index 1: "+g.Map.Cps[1]+" | Index 2: "+g.Map.Cps[2]);
            Console.WriteLine(g.Players.Length);
            Console.WriteLine(g.Players[0].Id);
            Console.WriteLine(g.Players[0].Name);
        }
        
        public class Game
        {
            public int Id {get; set; }
            public string Name {get; set; }
            public int MapId {get; set; }
            public GMapObj Map {get; set; }
            public GPlayersObj[] Players {get; set; }
            
        }
        public class GMapObj
        {
            public int Id {get; set; }
            public string Name {get; set; }
            public int[] Cps {get; set; }
        }
        public class GPlayersObj
        {
            public int Id {get; set; }
            public string Name {get; set; }
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