using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Post // schema of database object
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }
    }
}