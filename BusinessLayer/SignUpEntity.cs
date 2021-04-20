using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class SignUpEntity
    {
        public string email { get; set; }

        public string password { get; set; }
        public string username { get; set; }
        public int isactive { get; set; }
        public int isdeleted { get; set; }
    }
}
