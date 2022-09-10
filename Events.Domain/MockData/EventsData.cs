using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.MockData
{
    public static class EventsData
    {
        public static List<Event> eventList  = null;
        static EventsData()
        {
            eventList = new List<Event>
            {
                new Event
                {
                    Name = "Phantom of Opera",
                    City ="New York",
                    Price =  200
                },
                new Event
                {
                    Name = "Metallica",
                    City ="Los Angeles",
                    Price =  100
                },
                new Event
                {
                    Name = "Metallica",
                    City ="New York",
                    Price =  300
                },
                new Event
                {
                    Name = "Metallica",
                    City ="Boston",
                    Price =  150
                },
                new Event
                {
                    Name = "LadyGaGa",
                    City ="New York",
                    Price =  400
                },
                new Event
                {
                    Name = "LadyGaGa",
                    City ="Boston",
                    Price =  250
                },
                new Event
                {
                    Name = "LadyGaGa",
                    City ="Chicago",
                    Price =  180
                },
                new Event
                {
                    Name = "LadyGaGa",
                    City ="San Francisco",
                    Price =  230
                },
                new Event
                {
                    Name = "LadyGaGa",
                    City ="Washington",
                    Price =  280
                }


            };
        }
        
    }
}
