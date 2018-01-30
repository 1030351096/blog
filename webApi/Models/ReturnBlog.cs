using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webCore;

namespace webApi.Models
{
    public class ReturnBlog
    {
         public int blog_id { get; set; }
         public string title { get; set; }
         public DateTime? time { get; set; }
         public string content { get; set; }
         public int? user_id { get; set; }
         public int? type_id { get; set; }
         public int? classify_id { get; set; }
            
    }
}