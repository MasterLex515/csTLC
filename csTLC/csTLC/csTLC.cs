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

            bool loop = true; //variable for main-loop

            //do-while main loop
            do {
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

                Console.WriteLine("nochmal? (y/n): ");
                string nochmal = Console.ReadLine();
                if (nochmal=="n"||nochmal=="N")
                {
                    loop = false; //variable for main-loop = false to exit program
                }
            } while (loop==true);
        }
    }
    /*
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
    */
    
}