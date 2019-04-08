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
            Console.Write("login: ");
            string userlogin = Console.ReadLine();
            Console.Write("pw: ");
            string userpw = Console.ReadLine();

            UserLogin loginData = new UserLogin
            {
                login = userlogin,
                password = userpw

            };


            const string prefix = "https:/";
            const char slash = '/';
            const string host = "www.karopapier.de/";
            const string api = "api/";
            const string login = "login";

            // Create a request using a URL that can receive a post.   
            //use HttpWebRequest to get it work!
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(prefix + slash + host + api + login);
            //setup CookieContainer
            request.CookieContainer = new CookieContainer();
            // Set the Method property of the request to POST.  
            request.Method = "POST";
            // Create POST data and convert it to a byte array.  
            var postData = JsonConvert.SerializeObject(loginData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            //use HttpWebResponse to get it work!
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Display the Cookie
            Cookie KaroKeks = response.Cookies[0];
            Console.WriteLine(response.Cookies.Count);
            Console.WriteLine(KaroKeks.Name);
            Console.WriteLine(KaroKeks.Comment);
            Console.WriteLine(KaroKeks.CommentUri);
            Console.WriteLine(KaroKeks.Discard);
            Console.WriteLine(KaroKeks.Domain);
            Console.WriteLine(KaroKeks.Expired);
            Console.WriteLine(KaroKeks.Expires);
            Console.WriteLine(KaroKeks.HttpOnly);
            Console.WriteLine(KaroKeks.Path);
            Console.WriteLine(KaroKeks.Port);
            Console.WriteLine(KaroKeks.Secure);
            Console.WriteLine(KaroKeks.TimeStamp);
            Console.WriteLine(KaroKeks.Value);
            Console.WriteLine(KaroKeks.Version);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();
        }
        
    }

    public class UserLogin
    {
        public string login { get; set; }
        public string password { get; set; }
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