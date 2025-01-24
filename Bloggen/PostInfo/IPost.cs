using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloggen.PostInfo
{
    public interface IPost
    {
        int Id { get; set; }
        string PostTitle { get; set; }
        string PostContent { get; set; }
        DateTime DatePosted { get; set; }
    }
}
