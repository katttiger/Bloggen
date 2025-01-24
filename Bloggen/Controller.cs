using System;
using System.Collections.Generic;
using System.Linq;
using Bloggen.PostInfo;
using System.Text;
using System.Threading.Tasks;
using Bloggen;

namespace Bloggen
{

    public class Controller
    {
        private bool menu = true;
        public Controller()
        {
            while (menu)
            {
                MenuController.PrintMenu();
            }
        }

        public void Run()
        {
            List<Post> Posts = new List<Post>();

            Post post1 = new Post("A", "a");
            Post post2 = new Post("B", "b");
            Post post3 = new Post("C", "c");

            Posts.Add(post1);
            Posts.Add(post2);
            Posts.Add(post3);

            //Menu.PrintMenu();
            //Menu.HandleMenuOptions();
        }
    }
}
