using Bloggen.PostInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggen
{
    internal class PostFunctions:IPostFunctions
    {
       
        public void OrderPostList()
        {
            Console.Clear();
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
            ReturnToMenu();
        }
        public void SearchPostList()
        {
            Console.Clear();
            Console.WriteLine("\n\tVad vill du söka efter?" +
                                     "\n\t1) Sökord" +
                                     "\n\t2) Datum");
            Console.Write("\tSkriv in ditt svar: ");
            Int32.TryParse(Console.ReadLine(), out int answer);
            Console.Write("Sökord:");
            var keyword = Console.ReadLine();


            if (answer.Equals(1))
            {
                Console.WriteLine(Posts.FindAll(i => i.PostContent.Contains(keyword) || i.PostTitle.Contains(keyword)).ToList());
            }
            else if (answer.Equals(2))
            {
                DateTime searchdate = Convert.ToDateTime(keyword);
                Console.WriteLine(Posts.FindAll(i => i.DatePosted.Equals(searchdate)).ToList());
            }
            else
            {
                Console.WriteLine("Var god ange ett giltigt värde.");

            }
            ReturnToMenu();
        }
    }
}
