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
        MenuController menuController { get; set; }
        public Controller()
        {
            menuController = new MenuController();
        }
        public void Run()
        {
            menuController.PrintMenu();
            MenuController.HandleMenuOptions();
        }
    }
}
