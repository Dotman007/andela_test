using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{

    public class EventLocation
    {
        public float EventLong { get; set; }
        public float EventLat { get; set; }
    }


    public class CustomerLocation
    {
        public float CustomerLat { get; set; }
        public float CustomerLong { get; set; }
    }


    public class EmailCampaign
    {
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public float Distance { get; set; }
        public List<Event> Events { get; set; }

        public Events.Domain.Response.Response Response { get; set; }
    }
}
