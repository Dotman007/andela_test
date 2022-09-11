using Events.Domain.Dtos;
using Events.Domain.Interface;
using Events.Domain.MockData;
using Events.Domain.Response;
using GeoCoordinatePortable;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memCache;
        public LocationService()
        {
            _memCache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 3,
                ExpirationScanFrequency = TimeSpan.FromMinutes(100),
            }); ;   
        }

        public CustomerLongitudeLatitudeDto GetCustomerLatitudeLongitude(string customerCity)
        {
            try
            {

                string customerUrl = $"http://api.openweathermap.org/geo/1.0/";
                string eventUrl = $"http://api.openweathermap.org/geo/1.0/";

                var request = new RestClient(customerUrl);
                var restRequest = new RestRequest($"direct?q={customerCity}&limit=1&appid=55e965b9060bafa38adc78365eee83b8");
                RestResponse customerResponse = request.Execute(restRequest, Method.Get);
                var desCustomerResponse = JsonConvert.DeserializeObject<List<LocationDetails>>(customerResponse.Content);
                return new CustomerLongitudeLatitudeDto
                {
                    CustomerLatitude = desCustomerResponse.Select(e => e.lat).FirstOrDefault(),
                    CustomerLongitude = desCustomerResponse.Select(e => e.lon).FirstOrDefault(),
                    Response =  new Response.Response
                    {
                        Code =  ResponseMapping.Success00Code,
                        Message =  ResponseMapping.Success00Message
                    }
                };

            }
            catch (Exception ex)
            {
                return new CustomerLongitudeLatitudeDto
                {
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Error99Code,
                        Message = ResponseMapping.Error99Message
                    }
                };
            }
        }

        public GetLocationDto GetDistance(CustomerEventLongitudeLatitudeDto customer)
        {

            try
            {
                



                var sCoord = new GeoCoordinate(customer.CustomerLatitude, customer.CustomerLongitude);
                var eCoord = new GeoCoordinate(customer.EventLatitude, customer.EventLongitude);
                var response =  new GetLocationDto
                {
                    Distance = (float)sCoord.GetDistanceTo(eCoord),
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Success00Code,
                        Message = ResponseMapping.Success00Message
                    }
                };
                return response;

            }
            catch (Exception ex)
            {
                return new GetLocationDto
                {
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Error99Code,
                        Message = ResponseMapping.Error99Message
                    }
                };
            }
            
        }

        public GetLocationDto GetDistance(string customerCity, string eventCity)
        {
            try
            {
                
                var options = new MemoryCacheEntryOptions().SetSize(1);
                //var options = new MemoryCacheEntryOptions().SetSize(2);
                var getCachedData = (string)_memCache.Get("LocationResponse");
                if (getCachedData != null)
                {
                    var deserialize = JsonConvert.DeserializeObject<CacheData>(getCachedData);
                    if (deserialize?.customerCity == customerCity && deserialize.eventCity == eventCity)
                    {
                        var cachedResponse = new GetLocationDto
                        {
                            Distance = deserialize.GetLocationDto.Distance,
                            Response = new Response.Response
                            {
                                Code = ResponseMapping.Success00Code,
                                Message = ResponseMapping.Success00Message
                            }
                        };
                        return cachedResponse;
                    }
                }
                if (customerCity == eventCity)
                {
                    var sameCity =  new GetLocationDto
                    {
                        Distance =  0,
                        Response =  new Response.Response
                        {
                            Code =  ResponseMapping.Success00Code,
                            Message =  ResponseMapping.Success00Message
                        }
                    };
                    var sameCityResponse = new CacheData
                    {
                        customerCity = customerCity,
                        eventCity = eventCity,
                        GetLocationDto = sameCity,
                    };
                    _memCache.Set("LocationResponse", JsonConvert.SerializeObject(sameCityResponse),options);
                    var getCached = (string)_memCache.Get("LocationResponse");
                    return sameCity;
                }
                var getEventLatLog = GetEventLatitudeLongitude(eventCity);
                var getCustomerLatLong = GetCustomerLatitudeLongitude(customerCity);
                var getDistance = GetDistance(new CustomerEventLongitudeLatitudeDto
                {
                    CustomerLatitude = getCustomerLatLong.CustomerLatitude,
                    CustomerLongitude = getCustomerLatLong.CustomerLongitude,
                    EventLatitude = getEventLatLog.EventLatitude,
                    EventLongitude = getEventLatLog.EventLongitude
                });
                var locate = new GetLocationDto
                {
                    Distance = getDistance.Distance,
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Success00Code,
                        Message = ResponseMapping.Success00Message
                    }
                };
                var response = new CacheData
                {
                    customerCity = customerCity,
                    eventCity = eventCity,
                    GetLocationDto = locate,
                };
                _memCache.Set("LocationResponse", JsonConvert.SerializeObject(response),options);
                return locate;

            }
            catch (Exception ex)
            {
                return new GetLocationDto
                {
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Error99Code,
                        Message = ResponseMapping.Error99Message
                    }
                };
            }

            
        }
        public EventLongitudeLatitudeDto GetEventLatitudeLongitude(string eventCity)
        {
            try
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
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Success00Code,
                        Message = ResponseMapping.Success00Message
                    }
                };
            }
            catch (Exception)
            {
                return new EventLongitudeLatitudeDto
                {
                    Response = new Response.Response
                    {
                        Code = ResponseMapping.Error99Code,
                        Message = ResponseMapping.Error99Message
                    }
                }; ;
            }
        }

    }
}
