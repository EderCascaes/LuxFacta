using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxFacta.Entities
{
    public class Survey
    {
        public int poll_Id { get; set; }
        public string poll_description { get; set; }
        public IEnumerable<Options> options { get; set; }
    }

    public class SurveyResponse
    {
        public int poll_Id { get; set; }
        public string poll_description { get; set; }
        public List<string> options { get; set; }        
    }      
         
}
