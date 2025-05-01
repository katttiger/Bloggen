using Bloggen.PostInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggen
{
    public class MenuController
    {
        private static List<Post> Posts = new List<Post>();
        //The information on main page 
        public static void PrintMenu()
        {
            Console.Clear();
            string menuMessage=string.Empty; 
            if (Posts.Count > 0)
            {
                 menuMessage =
                    "\nVälkommen till bloggen.\n" +
                     "\n1) Skriva ett inlägg" +
                     "\n2) Skriv ut alla inlägg" +
                     "\n3) Radera ett inlägg" +
                     "\n4) Sortera inlägg" +
                     "\n5) Linjär sökning" +
                     "\n6) Binär sökning" +
                     "\n7) Avsluta programmet";
            }
            else
            {
                menuMessage =
                   "\nVälkommen till bloggen.\n" +
                    "\n1) Skriva ett inlägg " +
                    "\n7) Avsluta programmet";
            }
                Console.WriteLine(menuMessage);
        }

        public static void HandleMenuOptions()
        {
            PostAPI postAPI = new PostAPI();
            MenuController menuController = new MenuController();
            Console.Write("Input: ");
            Int32.TryParse(Console.ReadLine(), out int svar);

                if (svar.Equals(1)) {
                    postAPI.AddPost();
                }
               else if(svar.Equals(2)) {
                    postAPI.GetPost();
                        }
                else if (svar.Equals(3)) {
                    postAPI.RemovePost();
                }
                else if (svar.Equals(4)) {
                    menuController.OrderPostList();
                }
                else if (svar.Equals(5)) {
                    menuController.SearchPostList();
                }
                else if (svar.Equals(6)) {
                Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\n\tVar god ange ett tal mellan 1-7.");
                }
            }
       
        public async Task ReturnToMenu()
        {
            Console.WriteLine("\tTryck ENTER för att återvända till menyn.");
            Console.WriteLine("\t Returning to menu soon.");
            await Task.Delay(1000);
            Console.Clear();
        }

      
