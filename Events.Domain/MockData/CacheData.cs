using Events.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.MockData
{
    public class CacheData
    {
        public string eventCity { get; set; }
        public string customerCity { get; set; }

        public GetLocationDto GetLocationDto { get; set; }
    }
}
