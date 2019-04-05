//+pkg=Newtonsoft.Json.12.0.2-beta1
//+src=Karopapier.cs
//+src=
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Karopapier;
using Newtonsoft.Json;



namespace CSharp_Shell
{
    public static class Program 
    {
        public static void Main() 
        {
           //karotest.karotestprint();
           //karotest.karogetrequesttest();
           Console.WriteLine("userID: ");
           string id=Console.ReadLine();
           string param1="userInfo";
           string url=karoRequest.karoUrl(param1,id);
           Console.WriteLine(url);
           string userJson=karoRequest.karoGetRequest(url);
           Console.WriteLine(userJson);
           User u=JsonConvert.DeserializeObject<User>(userJson);
           Console.WriteLine(u.id);
           Console.WriteLine(u.login);
           Console.WriteLine(u.color);
           Console.WriteLine(u.lastVisit);
           Console.WriteLine(u.signup);
           Console.WriteLine(u.dran);
           Console.WriteLine(u.activeGames);
           Console.WriteLine(u.acceptsDayGames);
           Console.WriteLine(u.acceptsNightGames);
           Console.WriteLine(u.maxGames);
           Console.WriteLine(u.sound);
           Console.WriteLine(u.soundfile);
           Console.WriteLine(u.size);
           Console.WriteLine(u.border);
           Console.WriteLine(u.desperate);
           Console.WriteLine(u.birthdayToday);
           Console.WriteLine(u.karodayToday);
           Console.WriteLine(u.theme);
           Console.WriteLine(u.bot);
           Console.WriteLine(u.gamesort);
        }
    }
    
    public class User
    {
        public int id {get; set; }
        public string login {get; set; }
        public string color {get; set; }
        public int lastVisit {get; set; }
        public int signup {get; set; }
        public int dran {get; set; }
        public int activeGames {get; set; }
        public bool acceptsDayGames {get; set; }
        public bool acceptsNightGames {get; set; }
        public int maxGames {get; set; }
        public int sound {get; set; }
        public string soundfile {get; set; }
        public int size {get; set; }
        public int border {get; set; }
        public bool desperate {get; set; }
        public bool birthdayToday {get; set; }
        public bool karodayToday {get; set; }
        public string theme {get; set; }
        public bool bot {get; set; }
        public string gamesort {get; set; }
    }
    
}