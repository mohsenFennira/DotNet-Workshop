using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight:IServiceFlight
    {
        public List<Flight> Flights { get; set; }=new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        {   //IList<DateTime> result = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++)

            {
                if (Flights[i].Destination == destination)
                result.Add(Flights[i].FlightDate);
            }*/
           /* foreach (var flight in Flights) {
                if (flight.Destination == destination)
                    result.Add(flight.FlightDate);
            }
            return result;*/
           var query=from f in Flights where f.Destination == destination   
                     select f.FlightDate;
            return query.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType.ToLower())
            {
                case "destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "flightdate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "effectivearrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query=from f in Flights where f.Plane== plane 
                      select new {f.FlightDate,f.Destination};
            foreach (var item in query)
            {
                Console.WriteLine("flight informations= "+item.Destination + " " + item.FlightDate);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return( from f in Flights
                        where f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7)
                        select f).Count();
               
        }

        public double DestinationAvg(string destination)
        {
            return (from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDuration).Average();
            

        }
    }
}
