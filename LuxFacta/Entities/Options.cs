using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxFacta.Entities
{
    public class Options
    {
        public int option_id { get; set; }
        public string option_description { get; set; }
    }

    public class Request_Option
    {
        public int option_id { get; set; }
    }
}
