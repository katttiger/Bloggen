using System;
using System.Collections.Generic;
using System.Linq;
using Bloggen.PostInfo;


namespace Bloggen
{
    public class PostAPI
    {
        List<IPost> Posts = new List<IPost>();

        public void AddPost()
        {
            Console.Clear();
            Console.Write("Ange titel: ");
            string title = Console.ReadLine();

            Console.Write("Ange innehåll: ");
            string content = Console.ReadLine();
           
            Post NewPost = new Post(title, content);
            
            Posts.Add(NewPost);
        }

        public void GetPost()
        {
            Console.Clear();
            if (Posts.Count > 0)
            {
                foreach (var post in Posts)
                {
                    Console.WriteLine(
                        $"\n Title: {post.PostTitle}, posted {post.DatePosted.ToString().ToUpper()}" +
                        $"\n {post.PostContent}" +
                        "\n\t---End of Post----");
                }
            }
            else
            {
                Console.WriteLine("\n\tDet finns inga inlägg. Var god skriv till några.");
            }
        }
     
        public void GetPosts()
        {

        }
        public void RemovePost()
        {
            Console.Clear();
            if (Posts.Count() > 0)
            {
                Console.Write("\n\tDu vill radera ett inlägg.");
                foreach (var post in Posts)
                {
                    Console.WriteLine($"\n{Posts.IndexOf(post)}: {post.PostTitle}");
                }

                Console.Write("\n\tAnge inläggets platsnummer: ");
                int postChosenForDeletion = Convert.ToInt32(Console.ReadLine());
                var itemSelected = Posts.ElementAt(postChosenForDeletion);
                Console.WriteLine(
                    $"Item chosen: {itemSelected.PostTitle} {itemSelected.DatePosted} \n {itemSelected.PostContent}");
                Console.Write("\tÖnskar du ta bort detta inlägg? J/N: ");
                
                string answerToDeletion = Console.ReadLine();
                if (answerToDeletion == "J" || answerToDeletion == "j")
                {
                    Posts.RemoveAt(postChosenForDeletion);
                    Console.WriteLine("Inlägget har raderats");
                }
                else if (answerToDeletion == "N" || answerToDeletion == "n")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\tVar god ange antingen J/N: ");
                }
                Menu.ReturnToMenu();
            }
            else
            {

                Console.WriteLine("\n\tdet finns inga inlägg. \n\tvar god skriv till några.");

            }
            Menu.ReturnToMenu();
            Console.Clear();
        }
    }
}
