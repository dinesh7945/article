using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class ArticleEntity
    {

        public string title { get; set; }
        public string subTitle { get; set; }
        public string tags { get; set; }
        public string articleDesc { get; set; }
        public int tid { get; set; }
    }
}
