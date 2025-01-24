using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggen.PostInfo
{
    public interface IPostFunctions
    {
        string BinarySearch(string key, string element, int last, int first);

        string LinearSearch(string key, int length, string element);
    }
}
