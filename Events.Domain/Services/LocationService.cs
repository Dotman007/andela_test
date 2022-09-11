using Events.Domain.Dtos;
using Events.Domain.Interface;
using GeoCoordinatePortable;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Events.Domain.Services
{
    public class LocationService : ILocation
    {

        public CustomerLongitudeLatitudeDto GetCustomerLatitudeLongitude(string customerCity)
        {
            string customerUrl = $"http://api.openweathermap.org/geo/1.0/";
            string eventUrl = $"http://api.openweathermap.org/geo/1.0/";

            var request = new RestClient(customerUrl);
            var restRequest  =  new RestRequest($"direct?q={customerCity}&limit=1&appid=55e965b9060bafa38adc78365eee83b8");
            RestResponse customerResponse = request.Execute(restRequest,Method.Get);
            var desCustomerResponse = JsonConvert.DeserializeObject<List<LocationDetails>>(customerResponse.Content);
            return new CustomerLongitudeLatitudeDto
            {
                CustomerLatitude = desCustomerResponse.Select(e => e.lat).FirstOrDefault(),
                CustomerLongitude = desCustomerResponse.Select(e => e.lon).FirstOrDefault(),
            };
        }

        public float GetDistance(CustomerEventLongitudeLatitudeDto customer)
        {
            var sCoord = new GeoCoordinate(customer.CustomerLatitude, customer.CustomerLongitude);
            var eCoord = new GeoCoordinate(customer.EventLatitude, customer.EventLongitude);
            return (float)sCoord.GetDistanceTo(eCoord);
        }

        public float GetDistance(string customerCity, string eventCity)
        {
            var getEventLatLog = GetEventLatitudeLongitude(eventCity);
            var getCustomerLatLong = GetCustomerLatitudeLongitude(customerCity);
            var getDistance = GetDistance(new CustomerEventLongitudeLatitudeDto
            {
                CustomerLatitude =  getCustomerLatLong.CustomerLatitude,
                CustomerLongitude = getCustomerLatLong.CustomerLongitude,
                EventLatitude =  getEventLatLog.EventLatitude,
                EventLongitude =  getEventLatLog.EventLongitude
            });
            return getDistance;
        }
        public EventLongitudeLatitudeDto GetEventLatitudeLongitude(string eventCity)
        {
            string eventUrl = $"http://api.openweathermap.org/geo/1.0/";
            var eventrequest = new RestClient(eventUrl);
            var eventrestRequest = new RestRequest($"direct?q={eventCity}&limit=1&appid=55e965b9060bafa38adc78365eee83b8");
            RestResponse eventResponse = eventrequest.Execute(eventrestRequest, Method.Get);
            var desEventResponse = JsonConvert.DeserializeObject<List<LocationDetails>>(eventResponse.Content);


            return new EventLongitudeLatitudeDto
            {
                EventLatitude = desEventResponse.Select(e => e.lat).FirstOrDefault(),
                EventLongitude = desEventResponse.Select(e => e.lon).FirstOrDefault(),

            };
        }

    }
}
