using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.MockData
{
    public static class CustomerData
    {
        public static List<Customer> customerList;
        public static List<Customer> JohnSmithData;
        static CustomerData()
        {
            customerList = new List<Customer>
            {
                new Customer
                {
                    City =  "New York",
                    Email =  "jsmith@yahoo.com",
                    Name =  "John Smith",
                    
                },
                new Customer
                {
                    City =  "New York",
                    Email =  "mrfake@yahoo.com",
                    Name =  "Mr. Fake"
                },

                new Customer
                {
                    City =  "Chicago",
                    Email =  "johnsmith@yahoo.com",
                    Name =  "John Smith"
                }
                ,

                new Customer
                {
                    City =  "Boston",
                    Email =  "johnpaul@yahoo.com",
                    Name =  "John Paul"
                }
                ,

                new Customer
                {
                    City =  "San Francisco",
                    Email =  "johnwater@yahoo.com",
                    Name =  "John Water"
                }
            };


        }

        
    }

}
