using Events.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Dtos
{
    public class CustomerLongitudeLatitudeDto
    {
        public float CustomerLongitude { get; set; }
        public float CustomerLatitude { get; set; }

        public Events.Domain.Response.Response Response { get; set; }
    }

    public class CustomerEventLongitudeLatitudeDto
    {
        public float CustomerLongitude { get; set; }
        public float CustomerLatitude
        {
            get; set;
        }
        public float EventLongitude { get; set; }
        public float EventLatitude { get; set; }
    }

    public class EventLongitudeLatitudeDto
    {
        public float EventLongitude { get; set; }
        public float EventLatitude { get; set; }
        public Events.Domain.Response.Response Response { get; set; }

    }

    public class GetLocationDto
    {
        public float Distance { get; set; }
        public Events.Domain.Response.Response Response { get; set; }

    }
}
