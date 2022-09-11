using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Domain.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Services
{
    public class EventService:IEventService
    {

        public List<Event> GetAllEvents()
        {
            return EventsData.eventList;
        }

        public List<Event> GetEventByCustomerCity(string customerCity)
        {
            return EventsData.eventList.Where(x => x.City == customerCity).ToList();
        }

       
    }
}
