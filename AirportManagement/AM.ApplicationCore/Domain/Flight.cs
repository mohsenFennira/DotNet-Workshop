using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        //prop de navig
        public virtual Plane Plane { get; set; }  
        
        public virtual IList<Passenger> Passengers { get; set;}
    }
}
