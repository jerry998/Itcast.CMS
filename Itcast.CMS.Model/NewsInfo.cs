using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itcast.CMS.Model
{
    public class NewsInfo
    {
        public Int32 Id { get; set; }
        public string Title { get; set; }
        public string Msg { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
        public DateTime SubDateTime { get; set; }
    }
}
