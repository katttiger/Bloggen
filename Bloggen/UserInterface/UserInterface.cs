﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggen.UserInterface
{
    public class UserInterface : IUserInterface
    {
        public void ReadUserInput(string input)
        {
            Console.ReadLine();
        }

        public void PrintOnScreen()
        {
            Console.WriteLine();
        }
    }
}
