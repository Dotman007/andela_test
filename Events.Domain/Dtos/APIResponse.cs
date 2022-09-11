using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Dtos
{


    public class APIResponse
    {
        public List<LocationDetails> LocationDetails { get; set; }
    }

    public class LocationDetails
    {
        public string name { get; set; }
        
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }

    

}
