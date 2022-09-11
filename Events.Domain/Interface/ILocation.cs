using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Interface
{
    public interface ILocation
    {
        long GetLatitudeLongitude(string customerCity, string eventCity);
    }
}
