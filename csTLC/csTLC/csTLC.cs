//+pkg=Newtonsoft.Json.12.0.2-beta1
//+src=Karopapier.cs
//+src=
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Karopapier;
using Newtonsoft.Json;
using System.Threading;


// namespace CSharp_Shell because I started with the Android App | maybe I'll change it later
namespace CSharp_Shell
{
    public static class Program 
    {
        private static bool loop = true; //variable for main-loop

        public static void Main()
        {
            //karotest.karotestprint();
            //karotest.karogetrequesttest();
            
            //while main loop
            while (loop == true)
            {
                csTlcHead();

                Console.WriteLine("Options:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: UserInfo");
                Console.WriteLine("2: GameInfo");
                Console.WriteLine("3: login");
                Console.WriteLine("4: checkUser");
                Console.WriteLine("5: logout");
                Console.WriteLine("");

                // output cookie for debug
                Console.WriteLine("KeksName: " + KaroKeks.Name);
                Console.WriteLine("KeksExpires: " + KaroKeks.Expires);
                Console.WriteLine("KeksExpired: " + KaroKeks.Expired);
                Console.WriteLine("KeksValue: " + KaroKeks.Value);
                Console.WriteLine("");

                if (KaroKeks.Name == null)
                {
                    Console.WriteLine("you must login first!");
                    Console.WriteLine("");
                }
                Console.Write("Auswahl: ");
                string auswahl = Console.ReadLine();

                switch(auswahl)
                {
                    case "0":
                        loop = false;
                        Exit();
                        break;
                    case "1":
                        GetKaroUserInfo.GetUser();
                        Nochmal();
                        break;
                    case "2":
                        GetKaroGameInfo.GetGame();
                        Nochmal();
                        break;
                    case "3":
                        if (KaroKeks.Expired == false)
                        {
                            Console.WriteLine("You are already logged in!");
                            break;
                        }
                        else
                        {
                            KaroLogin.login();
                        }
                        Nochmal();
                        break;
                    case "4":
                        KaroCheckUser.checkUser();
                        Nochmal();
                        break;
                    case "5":
                        KaroLogout.logout();
                        Nochmal();
                        break;

                    default:
                        Console.WriteLine(">> Eingabe ung�ltig! <<");
                        Nochmal();
                        break;
                }


                Console.Clear();
            }
        }

        public static void csTlcHead()
        {
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#          C# - TeamLiga-Console          #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.WriteLine("");
        }

        public static void Exit()
        {
            Console.WriteLine("");
            Console.WriteLine("Auto-Logout ...");
            KaroLogout.logout();
            Console.WriteLine("");
            Console.WriteLine("exit in 5 sec.");
            // Sleep for 3 seconds before exit
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("[DONE]");
        }

        public static void Nochmal()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("nochmal? (y/n): ");
            string nochmal = Console.ReadLine();
            if (nochmal == "n" || nochmal == "N")
            {
                loop = false; //variable for main-loop = false to exit program
                              // automatic logout
                Exit();
            }
            Console.Clear();
        }

    }

    
}