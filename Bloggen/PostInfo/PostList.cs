using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggen.PostInfo
{
    internal class PostList
    {
        List<IPost> posts;
        public PostList()
        {
            posts = new List<IPost>();
        }

        public static string BinarySearch(string key, string element, int last, int first)
        {
            string message = "Sökordet finns inte";

            int mid = first + last / 2;
            if (key.CompareTo(element).Equals(-1))
            {
                last = last - mid;
            }
            else if (key.CompareTo(element).Equals(1))
            {
                first = first + mid;
            }
            else
            {
                message = $"finns på plats {key}";
            }
            return message;
        }

        public static string LinearSearch(string key, int length, string element)
        {
            string message = "Post matching title does not exist.";
            for (int i = 0; i < length; i++)
            {
                if (key.ToUpper() == element.ToUpper())
                {
                    message = $"Inlägget finns på plats {i++}";
                    break;
                }
                else
                {
                    message = string.Empty;
                    break;
                }
            }
            return message;

        }
    }
}
