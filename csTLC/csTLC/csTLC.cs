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
                Console.WriteLine("Options:");
                Console.WriteLine("1: UserInfo");
                Console.WriteLine("2: GameInfo");
                Console.WriteLine("3: login");
                Console.WriteLine("4: checkUser");
                Console.WriteLine("");
                Console.WriteLine("you must login first!");
                Console.WriteLine("");
                Console.Write("Auswahl: ");
                string auswahl = Console.ReadLine();

                switch(auswahl)
                {
                    case "1":
                        GetKaroUserInfo.GetUser();
                        break;
                    case "2":
                        GetKaroGameInfo.GetGame();
                        break;
                    case "3":
                        KaroLogin.login();
                        break;
                    case "4":
                        KaroCheckUser.checkUser();
                        break;

                    default:
                        Console.WriteLine(">> Eingabe ung�ltig! <<");
                        break;
                }

                Console.WriteLine("----------------");
                Console.WriteLine("nochmal? (y/n): ");
                string nochmal = Console.ReadLine();
                if (nochmal=="n"||nochmal=="N")
                {
                    loop = false; //variable for main-loop = false to exit program
                }
            } while (loop==true);
        }
    }

    
}