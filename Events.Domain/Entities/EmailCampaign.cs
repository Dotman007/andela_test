using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EmailCampaign
    {
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public List<Event> Events { get; set; }
    }
}
