using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxFacta.Entities
{
    public class View_Survey
    {
        public int views { get; set; }
        public IEnumerable<Vote> votes { get; set; }
    }
}
