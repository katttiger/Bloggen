﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggen.UserInterface
{
    public interface IUserInterface
    {
        void PrintOnScreen();
        void ReadUserInput(string input);
        
    }
}
