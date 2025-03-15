using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloggen.PostInfo
{
    public class Post : IPost
    {
        public int Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime DatePosted { get; set; }

        public Post(string postTile, string postContent)
        {
            PostTitle = postTile;
            PostContent = postContent;
            DatePosted = DateTime.Now;
            DatePosted.ToShortDateString();
        }
    }
}
