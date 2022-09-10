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
    public class CustomerService: ICustomerService
    {
        public List<Customer> AllCustomer()
        {
            return CustomerData.customerList;
        }


        public List<EmailCampaign> GetCustomerByEventLocation()
        {
            return CustomerData.customerList.Join(EventsData.eventList,city=>city.City,eventCity=>eventCity.City,(city,eventCity)=>new EmailCampaign
            {
                Email = city.Email,
                CustomerName = city.Name,
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
