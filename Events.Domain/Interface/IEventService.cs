using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Interface
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        List<Event> GetEventByCustomerCity(string customerCity);

        List<Event> GetEventByDistance(string customerCity, string eventCity);

        int GetDistance();
    }
}
