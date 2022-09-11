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
    }
}
