using System;
using System.Collections.Generic;
using System.Linq;
using Bloggen.PostInfo;

namespace Bloggen
{
    public class PostAPI
    {
        List<IPost> Posts = new List<IPost>();
        private readonly MenuController Menu = new MenuController();

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
        public void GetPosts()
        {
            Console.Clear();
            if (Posts.Count > 0)
            {
                foreach (var post in Posts)
                {
                    Console.WriteLine(
                        $"\n Title: {post.PostTitle}, posted {post.DatePosted.ToString().ToUpper()}" +
                        $"\n {post.PostContent.Substring(0, 200)}" +
                        "\n---End of Post----");
                }
            }
            else
            {
                Console.WriteLine("\n\tDet finns inga inlägg. Var god skriv till några.");
            }
        }     
        public void GetPost()
        {
            //Enter an index or keyword
            //Call a search function
            //Print post
        }

        //----------------------------------------------------------

        public void RemovePost()
        {
            Console.Clear();
            if (Posts.Count() > 0)
            {
                Console.Write("\n\tDu vill radera ett inlägg.");
                PrintListOfPostsTitleAndIndex(Posts);
                int postChosenForDeletion = ChosePostToDelete(Posts);
                ConfirmDeletionOfPost(postChosenForDeletion);
            }
            else
            {
                Console.WriteLine("\nDet finns inga inlägg. \n Var god skriv några.");
            }
            Menu.ReturnToMenu();
            Console.Clear();
        }
        public void PrintListOfPostsTitleAndIndex(List<IPost> Postlist)
        {
            foreach (var post in Posts)
            {
                Console.WriteLine($"\n{Posts.IndexOf(post)}: {post.PostTitle}");
            }

        }
        public int ChosePostToDelete(List<IPost> Posts)
        {
            Console.Write("\n\tAnge inläggets platsnummer: ");
            int postChosenForDeletion = Convert.ToInt32(Console.ReadLine());
            var itemSelected = Posts.ElementAt(postChosenForDeletion);
            Console.WriteLine($"Item chosen: {itemSelected.PostTitle} {itemSelected.DatePosted} \n {itemSelected.PostContent}");
            return postChosenForDeletion;
        }

        public void ConfirmDeletionOfPost(int postChosenForDeletion)
        {
            Console.Write("\tÖnskar du ta bort detta inlägg? J/N: ");

            string answerToDeletion = Console.ReadLine();
            if (answerToDeletion == "J" || answerToDeletion == "j")
            {
                Posts.RemoveAt(postChosenForDeletion);
                Console.WriteLine("Inlägget har raderats");
            }
            else if (answerToDeletion == "N" || answerToDeletion == "n")
            {
                Menu.ReturnToMenu();

            }
            else
            {
                Console.WriteLine("\tVar god ange antingen J/N: ");
            }
        }

    }
}
