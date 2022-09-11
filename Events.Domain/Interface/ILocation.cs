using Events.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Interface
{
    public interface ILocation
    {
        CustomerLongitudeLatitudeDto GetCustomerLatitudeLongitude(string customerCity);
        EventLongitudeLatitudeDto GetEventLatitudeLongitude(string eventCity);
        GetLocationDto GetDistance(string customerCity, string eventCity);
        GetLocationDto GetDistance(CustomerEventLongitudeLatitudeDto customer);
    }
}
