using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Domain.MockData;
using Events.Domain.Response;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Services
{
    public class CustomerService: ICustomerService
    {
        //public LvlData CurrentLevelData { get; set; }
        public IMemoryCache _memoryCache { get; set; }
        
        ILocation _locs = new LocationService();
        public List<Customer> AllCustomer()
        {
            return CustomerData.customerList;
        }
        
        public List<EmailCampaign> GetClosestEventLocation(string eventCity, string customerCity)
        {

            try
            {
                List<EmailCampaign> emailCampaigns = new List<EmailCampaign>();
                List<Event> eventCampaigns = new List<Event>();
                var getCustomer = CustomerData.customerList.Where(e => e.City == customerCity);
                foreach (var item in getCustomer)
                {
                    var getLocation = _locs.GetDistance(item.City, eventCity);
                    emailCampaigns.Add(new EmailCampaign
                    {
                        CustomerName = item.Name,
                        Distance = getLocation.Distance,
                        Email = item.Email,
                    });
                }
                var getEvents = EventsData.eventList;
                foreach (var item in getEvents)
                {
                    var getLocation = _locs.GetDistance(customerCity, item.City);
                    eventCampaigns.Add(new Event
                    {
                        City = item.City,
                        Distance = getLocation.Distance,
                        Name = item.Name,
                        Price = item.Price
                    });
                }
                emailCampaigns[0].Events = eventCampaigns.OrderBy(eventCampaigns => eventCampaigns.Distance).Take(5).ToList();
                emailCampaigns[0].Response = new Response.Response
                {
                    Code = ResponseMapping.Success00Code,
                    Message = ResponseMapping.Success00Message
                };
                return emailCampaigns;
            }
            catch (Exception ex)
            {
                return new List<EmailCampaign>
                {
                    new EmailCampaign
                    {
                        Response =  new Response.Response
                        {
                                Code =  ResponseMapping.Error99Code,
                                Message =  ResponseMapping.Error99Message
                        }
                    }
                };
            }

           



            //return CustomerData.customerList.Where(e => e.City == cityName).Join(EventsData.eventList, city => city.City, eventCity => eventCity.City, (city, eventCity) => new EmailCampaign
            //{
            //    Email = city.Email,
            //    CustomerName = city.Name,
            //    Distance = _locs.GetDistance(new Dtos.CustomerEventLongitudeLatitudeDto
            //    {
            //        CustomerLatitude = _locs.GetCustomerLatitudeLongitude(city.City).CustomerLatitude,
            //        CustomerLongitude = _locs.GetCustomerLatitudeLongitude(city.City).CustomerLongitude,
            //        EventLatitude = _locs.GetEventLatitudeLongitude(eventCity.City).EventLatitude,
            //        EventLongitude = _locs.GetEventLatitudeLongitude(eventCity.City).EventLongitude
            //    }),
            //    Events = EventsData.eventList.Where(s => s.City == city.City).OrderBy(o => o.Distance).Take(5).ToList(),
            //}).DistinctBy(e => e.CustomerName).ToList();
        }



        public List<EmailCampaign> GetCustomerByEventLocation()
        {
            return CustomerData.customerList.Join(EventsData.eventList,city=>city.City,eventCity=>eventCity.City,(city,eventCity)=>new EmailCampaign
            {
                Email = city.Email,
                CustomerName = city.Name,
                Distance = _locs.GetDistance(new Dtos.CustomerEventLongitudeLatitudeDto
                {
                    CustomerLatitude = _locs.GetCustomerLatitudeLongitude(city.City).CustomerLatitude,
                    CustomerLongitude = _locs.GetCustomerLatitudeLongitude(city.City).CustomerLongitude,
                    EventLatitude = _locs.GetEventLatitudeLongitude(eventCity.City).EventLatitude,
                    EventLongitude = _locs.GetEventLatitudeLongitude(eventCity.City).EventLongitude
                }).Distance,
                Events = EventsData.eventList.Where(s=>s.City == city.City).ToList(),
            }).DistinctBy(e => e.CustomerName).ToList();
        }

        public List<EmailCampaign> GetEventByName(string name)
        {

            return CustomerData.customerList.Where(e=>e.Name ==  name).Join(EventsData.eventList, city => city.City, eventCity => eventCity.City, (city, eventCity) => new EmailCampaign
            {
                Email = city.Email,
                CustomerName = city.Name,
                Events = EventsData.eventList.Where(s => s.City == city.City).ToList(),
            }).DistinctBy(e => e.CustomerName).ToList();
        }

    }
}
