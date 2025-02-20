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
        public Controller() { }

        public void Run()
        {
            MenuController.PrintMenu();
            MenuController.HandleMenuOptions();
        }
    }
}
