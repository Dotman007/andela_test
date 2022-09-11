using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Interface
{
    public interface ICustomerService
    {
        List<Customer> AllCustomer();
        List<EmailCampaign> GetCustomerByEventLocation();

        List<EmailCampaign> GetClosestEventLocation(string eventCity, string customerCity);
        List<EmailCampaign> GetEventByName(string name);
    }
}
