//+pkg=Newtonsoft.Json.12.0.2-beta1
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security;
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
            string karoApiUrlBase = prefix + slash + host + api;
            string karoApiUrl = "";

            switch (param1switch)
            {
                case "userInfo":
                    karoApiUrl = karoApiUrlBase + users + param2url;
                    Console.WriteLine(karoApiUrl);
                    break;
                case "gameInfo":
                    karoApiUrl = karoApiUrlBase + games + param2url + queryPlayers1;
                    Console.WriteLine(karoApiUrl);
                    break;
                case "login":
                    karoApiUrl = karoApiUrlBase + param2url;
                    Console.WriteLine(karoApiUrl);
                    break;
                case "check":
                    karoApiUrl = karoApiUrlBase + users + param2url;
                    break;
            }

            return karoApiUrl;
        }

        public static string KaroGetRequest(string getUrl)
        { // TODO rebuild GetRequest to use HttpWebRequest for simplier use of sending cookie from KaroKeks Object
            try
            {
                Uri uri = new Uri(getUrl);
                Console.WriteLine(uri);
                // Create a request for the URL.   
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;

                // Create Cookie and Add Cookie if available
                Cookie cookie = new Cookie
                {
                    Comment = KaroKeks.Comment,
                    //cookie.CommentUri = KaroKeks.CommentUri;
                    Discard = KaroKeks.Discard,
                    Domain = KaroKeks.Domain,
                    Expired = KaroKeks.Expired,
                    //cookie.Expires = KaroKeks.Expires;
                    HttpOnly = KaroKeks.HttpOnly,
                    Name = KaroKeks.Name,
                    Path = KaroKeks.Path,
                    //cookie.Port = KaroKeks.Port.ToString();
                    Secure = KaroKeks.Secure,
                    //cookie.TimeStamp = KaroKeks.Timestamp;
                    Value = KaroKeks.Value
                    //cookie.Version = KaroKeks.Version.ToString();
                };
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookie);
                
                // Get the response.  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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

        public static string KaroPostRequest(string postUrl, string postString)
        {
            try
            {
                // Create a request using a URL that can receive a post.   
                //use HttpWebRequest to get it work!
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                //setup CookieContainer
                request.CookieContainer = new CookieContainer();
                // Set the Method property of the request to POST.  
                request.Method = "POST";
                // Create POST data and convert it to a byte array.  
                // "postData" Object must be converted to String to be able to pass it to KaroPostrequest! Objects cannot be passed to Methods I guess.
                //var postData = JsonConvert.SerializeObject(postObject);
                byte[] byteArray = Encoding.UTF8.GetBytes(postString);
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
                Cookie Keks = response.Cookies[0];
                Console.WriteLine(response.Cookies.Count);
                Console.WriteLine(Keks.Name);
                Console.WriteLine(Keks.Comment);
                Console.WriteLine(Keks.CommentUri);
                Console.WriteLine(Keks.Discard);
                Console.WriteLine(Keks.Domain);
                Console.WriteLine(Keks.Expired);
                Console.WriteLine(Keks.Expires);
                Console.WriteLine(Keks.HttpOnly);
                Console.WriteLine(Keks.Path);
                Console.WriteLine(Keks.Port);
                Console.WriteLine(Keks.Secure);
                Console.WriteLine(Keks.TimeStamp);
                Console.WriteLine(Keks.Value);
                Console.WriteLine(Keks.Version);


                //Store Cookie in KaroKeks Object
                KaroKeks.Name = Keks.Name;
                KaroKeks.Comment = Keks.Comment;
                //KaroKeks.CommentUri = Keks.CommentUri.ToString();
                KaroKeks.Discard = Keks.Discard;
                KaroKeks.Domain = Keks.Domain;
                KaroKeks.Expired = Keks.Expired;
                KaroKeks.Expires = Keks.Expires.ToString();
                KaroKeks.HttpOnly = Keks.HttpOnly;
                KaroKeks.Path = Keks.Path;
                KaroKeks.Secure = Keks.Secure;
                KaroKeks.Timestamp = Keks.TimeStamp.ToString();
                KaroKeks.Value = Keks.Value;
                KaroKeks.Version = Keks.Version.ToString();


                // add cookie to CookieCollection
                //CookieCollection cookieCollection = new CookieCollection();
                //cookieCollection.Add(KaroKeks);
                //KaroKeks karoKeks = new KaroKeks();
                //karoKeks.CookieCollection.Add(Keks);

                Console.WriteLine("");
                string KeksString = JsonConvert.SerializeObject(Keks);
                Console.WriteLine("KeksString: " + KeksString);
                Console.WriteLine("");


                // Clean up the streams.  
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
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
        // TODO class Game might be incomplete
        public class Game
        {
            public int Id {get; set; }
            public string Name {get; set; }
            public int MapId {get; set; }
            public GMapObj Map {get; set; }
            public GPlayersObj[] Players {get; set; }
            
        }
        // TODO class GMapObj might be incomplete
        public class GMapObj
        {
            public int Id {get; set; }
            public string Name {get; set; }
            public int[] Cps {get; set; }
        }
        // TODO class GPlayerObj might be incomplete evaluate if mergable with casual UserObject
        public class GPlayersObj
        {
            public int Id {get; set; }
            public string Name {get; set; }
        }
    
    }
    // TODO add password masking. password should not be readable when entered
    public class KaroLogin
    {
        public static void login()
        {
            // Testoutput for testing Cookie Object
            Console.WriteLine("");
            Console.WriteLine("Print Cookie Data from login-method out of KaroKeks Object before login post request:");
            Console.WriteLine(KaroKeks.Name);
            Console.WriteLine(KaroKeks.Domain);
            Console.WriteLine("");

            // create PostUrl
            string param1 = "login";
            string login = "login";
            string postUrl = KaroRequest.KaroUrl(param1, login);
            Console.WriteLine(postUrl);
            // get user login data
            Console.Write("login: ");
            string userlogin = Console.ReadLine();

            // get password with masking from console
            string msg = "pw: ";
            string pw = getPasswordFromConsole(msg);
            string userpw = pw.ToString();
            
            // output for debug
            //Console.WriteLine(userpw);

            //Console.Write("pw: ");
            //string userpw = Console.ReadLine();

            //generate login dataobject
            UserLogin loginData = new UserLogin
            {
                login = userlogin,
                password = userpw

            };

            // create CookieContainer to store cookies
            //CookieContainer cookieContainer = new CookieContainer();
            
            // convert loginData to string for passing to KaroPostRequest
            var postData = JsonConvert.SerializeObject(loginData);
            string loginResponse = KaroRequest.KaroPostRequest(postUrl, postData);
            Console.WriteLine(loginResponse);
            Console.WriteLine("");
            Console.WriteLine("Print Cookie Data from login-method out of KaroKeks Object after login post request:");
            Console.WriteLine(KaroKeks.Name);
            Console.WriteLine(KaroKeks.Domain);
            Console.WriteLine("");

            
            //Console.WriteLine(karoKeks.Name);

        }

        public class UserLogin
        {
            public string login { get; set; }
            public string password { get; set; }
        }

        public static string getPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    //pass.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        // remove last char when backspace is pressed
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            return pass;
        }

    }

    public static class KaroKeks
    {
        public static string Name { get; set; }
        public static string Comment { get; set; }
        public static string CommentUri { get; set; }
        public static bool Discard { get; set; }
        public static string Domain { get; set; }
        public static bool Expired { get; set; }
        public static string Expires { get; set; }
        public static bool HttpOnly { get; set; }
        public static string Path { get; set; }
        public static int Port { get; set; }
        public static bool Secure { get; set; }
        public static string Timestamp { get; set; }
        public static string Value { get; set; }
        public static string Version { get; set; }
    }

    public class KaroCheckUser
    {
        public static void checkUser()
        {
            string check = "check";
            string getUrl = KaroRequest.KaroUrl(check, check);
            KaroRequest.KaroGetRequest(getUrl);
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