﻿using Events.Domain.Entities;
using Events.Domain.Interface;
using Events.Domain.Services;

public class Program
{
    static void Main()
    {
        ICustomerService _customer = new CustomerService();
        ICampaignSender _sender = new CampaignEmailSender();
        IEventService _eventService = new EventService();
        //_eventService.GetDistance();
        #region Approach for getting list of events by locations
        var listOfCustomerEvents = _customer.GetCustomerByEventLocation();
        #endregion

        #region If John Smith was the only client, we can filter out event that is related to John Smith Location
        var johnSmithEvents  = _customer.GetEventByName("John Smith");
        #endregion

        #region Called the add to email by getting clients events and passing the list as parameter to the email method
        var emailSend = _sender.AddToEmail(listOfCustomerEvents);
        #endregion

        Console.ReadLine();
    }
}