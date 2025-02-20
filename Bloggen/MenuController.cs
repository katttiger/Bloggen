using System;
using System.Collections.Generic;
using System.Linq;
using Bloggen.PostInfo;
using System.Text;
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
            string menuMessage =
                "\nVälkommen till bloggen.\n" +
                 "\n1) Skriva ett inlägg" +
                 "\n2) Skriv ut alla inlägg" +
                 "\n3) Radera ett inlägg" +
                 "\n4) Sortera inlägg" +
                 "\n5) Linjär sökning" +
                 "\n6) Binär sökning" +
                 "\n7) Avsluta programmet";
            Console.WriteLine(menuMessage);
        }

        public static void HandleMenuOptions()
        {
            PostAPI postAPI = new PostAPI();
            MenuController menuController = new MenuController();
            Console.Write("Input: ");
            Int32.TryParse(Console.ReadLine(), out int svar);

            switch (svar)
            {
                case 1:
                    postAPI.AddPost();
                    break;

                case 2:
                    postAPI.GetPost();
                    break;

                case 3:
                    postAPI.RemovePost();
                    break;

                case 4:
                    menuController.OrderPostList();
                    break;

                case 5:
                    menuController.SearchPostList();
                    //Search - convert to match with a generic list.
                    break;

                case 7:
                    bool menu = false;
                    break;
                default:
                    Console.WriteLine("\n\tVar god ange ett tal mellan 1-7.");
                    break;
            }
        }
        public async Task ReturnToMenu()
        {
            Console.WriteLine("\tTryck ENTER för att återvända till menyn.");
            Console.WriteLine("\t Returning to menu soon.");
            await Task.Delay(1000);
            Console.Clear();
        }

        public void OrderPostList()
        {
            Console.Clear();
            if (Posts.Count() > 0)
            {
                Console.Write("\tSkriv in ditt svar: "); Console.WriteLine("\n\tHur vill du sortera?" +
                           "\n\t1) Titel" +
                           "\n\t2) Innehåll" +
                           "\n\t3) Datum");
                Console.Write("\tInput: ");

                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer.Equals(1))
                    Posts.OrderBy(o => o.PostTitle);
                else if (answer.Equals(2))
                    Posts.OrderBy(o => o.PostContent);
                else if (answer.Equals(3))
                    Posts.OrderBy(o => o.DatePosted);
                else
                    Console.WriteLine("Please enter a number between 1-3");
            }
            else
            {
                Console.WriteLine("\tDet finns inga inlägg. \n\tVar god skriv till några.");
            }
            ReturnToMenu();
        }

        public void SearchPostList()
        {
            /*Console.Clear();
                    if (Posts.Count() > 0)
                    {

                        Console.WriteLine("\n\tVad vill du söka efter?" +
                                          "\n\t1) Sökord" +
                                          "\n\t2) Datum");
                        Console.Write("\tSkriv in ditt svar: ");

                        Int32.TryParse(Console.ReadLine(), out int answer);
                        if (answer == 1)
                        {

                            Console.Write("\n\tAnge titel: ");
                            string contentKey = Console.ReadLine();

                            if (Posts.Exists(x => x.PostTitle == contentKey))
                            {
                                //foreach (var item in Posts)
                                //{
                                //Console.Write($"{item.PostTitle}, {item.PostContent}, {item.DatePosted}");
                                //}
                            }
                            else if (Posts.Exists(x => x.PostContent == contentKey))
                            {
                                foreach (var item in Posts)
                                {
                                    Console.Write($"{item.PostTitle}, {item.PostContent}, {item.DatePosted}");
                                }
                            }
                            else
                            {
                                Console.Write("No matches were found");
                            }
                            ReturnToMenu();
                            break;

                        }
                        else if (answer == 2)
                        {
                            Console.Write("\n\tAnge datum (ÅÅÅÅ-MM-DD): ");
                            DateTime datekey = Convert.ToDateTime(Console.ReadLine()).Date;
                            if (Posts.Exists(x => x.DatePosted == datekey))
                            {
                                foreach (var item in Posts)
                                {
                                    Console.Write($"{item.PostTitle}, {item.PostContent}, {item.DatePosted}");
                                }

                            }
                            else
                            {
                                Console.Write("No matches were found");

                            }
                            ReturnToMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\tAnge ett tal mellan 1-3.");
                        }
                        break;

                    }

                    else
                    {
                        Console.WriteLine("\n\tDet finns inga inlägg." +
                            "\n\tVar god skriv till några.");
                        ReturnToMenu();
                    }

                    break;

                    /*case 6:
                        bool answerC = true;
                        Console.Clear();
                        //Kolla så att det finns inlägg
                        if (Posts.Count() > 0)
                        {
                            while (answerC)
                            {
                                //Presentera alternativ.
                                Console.WriteLine("\n\tVad vill du söka efter?" +
                                    "\n\t1) Titel" +
                                    "\n\t2) Sökord" +
                                    "\n\t3) Datum");
                                Console.Write("\tSkriv in ditt svar: ");
                                bool T = Int32.TryParse(Console.ReadLine(), out int answerD);
                                if (T)
                                {
                                    switch (answerD)
                                    {
                                        case 1:
                                            if (sortTitle == true)
                                            {
                                                Console.Write("\n\tAnge titel: ");
                                                string key = Console.ReadLine();
                                                int last = (Posts.Count() - 1);
                                                int first = 0;
                                                int mid = first + last / 2;
                                                string message = "";
                                                int i = 0;
                                                for (i = 0; i < Posts.Count(); i++)
                                                {
                                                    message = BinarySearch(key, Posts[i][0], last, first);
                                                    if (message != "Sökordet finns inte")
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (message == "Sökordet finns inte")
                                                {
                                                    Console.WriteLine("\n\tMotsvarande titel saknas");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tTiteln " + message + "" + (i + 1));
                                                }
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n\tVar god sortera enligt titel.");
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            break;

                                        case 2:
                                            if (sortInput == true)
                                            {
                                                Console.Write("\n\tAnge sökord: ");
                                                string key = Console.ReadLine();
                                                int last = (Posts.Count() - 1);
                                                int first = 0;
                                                int mid = first + last / 2;
                                                string message = "";
                                                int i = 0;
                                                for (i = 0; i < Posts.Count(); i++)
                                                {
                                                    message = BinarySearch(key, Posts[i][1], last, first);
                                                    if (message != "Sökordet finns inte")
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (message == "Sökordet finns inte")
                                                {
                                                    Console.WriteLine("\n\tMotsvarande sökord saknas");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tTiteln " + message + "" + (i + 1));
                                                }
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n\tVar god sortera per innehåll.");
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            break;

                                        case 3:
                                            if (sortDate == true)
                                            {
                                                Console.Write("\n\tAnge datum (ÅÅÅÅ-MM-DD): ");
                                                string key = Console.ReadLine();
                                                int last = (Posts.Count() - 1);
                                                int first = 0;
                                                int mid = first + last / 2;
                                                string message = "";
                                                int i = 0;
                                                for (i = 0; i < Posts.Count(); i++)
                                                {
                                                    message = BinarySearch(key, Posts[i][2], last, first);
                                                    if (message != "Sökordet finns inte")
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (message == "Sökordet finns inte")
                                                {
                                                    Console.WriteLine("\n\tMotsvarande datum finns inte");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tDatumet " + message + "" + (i + 1));
                                                }
                                                ReturnToMenu();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n\tVar god sortera listan per datum.");
                                                ReturnToMenu();
                                            }
                                            answerC = false;
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n\tVar god ange en siffra mellan 1-3");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga inlägg." +
                                "\n\tVar god skriv till några.");
                            ReturnToMenu();
                        }*/
        }

    }
}
