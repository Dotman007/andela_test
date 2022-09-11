using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Domain.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching;

public class Program
{
    static void Main()
    {

        Events.Domain.Utility.Utility.InitializeCache();
        ICustomerService _customer = new CustomerService();
        #region Get latitude and longitude by location
        ILocation _location = new LocationService();
        var getDistance = _location.GetDistance("New York", "New York");

        #endregion

        //ICampaignSender _sender = new CampaignEmailSender();
        //IEventService _eventService = new EventService();
        ////_eventService.GetDistance();
        //#region Approach for getting list of events by locations
        //var listOfCustomerEvents = _customer.GetCustomerByEventLocation();
        //#endregion

        var getDistance2 = _location.GetDistance("New York", "New York");


        var sortByLowerPrice = _customer.SortEventByLowerPrice("New York", "New York");
        var sortByHigherPrice = _customer.SortEventByHigherPrice("New York", "New York");
        #region Approach for getting list of events by locations
        var listOfClosestEvent = _customer.GetClosestEventLocation("New York","Boston");
        #endregion

        #region If John Smith was the only client, we can filter out event that is related to John Smith Location
        var johnSmithEvents  = _customer.GetEventByName("John Smith");
        #endregion



        #region Called the add to email by getting clients events and passing the list as parameter to the email method
        //var emailSend = _sender.AddToEmail(listOfCustomerEvents);
        #endregion

        Console.ReadLine();
    }
}