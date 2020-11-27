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

    public class Options
    {
        public int option_id { get; set; }
        public string option_description { get; set; }
    }

    public class View_Survey
    {
        public int views { get; set; }
        public IEnumerable<Vote> votes { get; set; }
    } 

    public class Vote
    {
        public int option_id { get; set; }
        public int qty { get; set; }        
    }

    public class Request_Option_id
    {
        public int option_id { get; set; }      
    }


}
