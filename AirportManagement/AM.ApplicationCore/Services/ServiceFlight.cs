using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight:IServiceFlight
    {
        #region TP2
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
           //Linq
           /*var query=from f in Flights where f.Destination == destination   
                     select f.FlightDate;
            return query.ToList();*/

           //lambda
            return Flights.Where(f=>f.Destination==destination).Select(f=>f.FlightDate).ToList();
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
            //linq
            /*var query=from f in Flights where f.Plane== plane 
                      select new {f.FlightDate,f.Destination};
            foreach (var item in query)
            {
                Console.WriteLine("flight informations= "+item.Destination + " " + item.FlightDate);
            }*/
            //lambda
            var result =Flights.Where(f => f.Plane == plane).Select(f => new { f.FlightDate, f.Destination });
            foreach (var item in result)
            {
                Console.WriteLine("flight informations= " + item.Destination + " " + item.FlightDate);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //linq
            return( from f in Flights
                        where f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7)
                        select f).Count();
            //lambda
            //return Flights.Where(f => f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7)).Count();
            return Flights.Count(f => f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7));
               
        }

        public double DestinationAvg(string destination)
        {
            /*return (from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDuration).Average();*/
            return Flights.Where(f=>f.Destination==destination).Average(f=>f.EstimatedDuration);
           // return Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();

        }

        public IList<Flight> OrderedDurationFlights()
        {
            //linq
            /*return (from f in Flights
                    orderby f.EstimatedDuration descending
                    select f).ToList();*/
            //lambda
            return Flights.OrderByDescending(f=>f.EstimatedDuration).ToList();
        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            /*var query = from p in flight.Passengers.OfType<Traveller>()
                        orderby p.BirthDate ascending
                        select p;
            return query.Take(3).ToList();*/
            return flight.Passengers.OfType<Traveller>().OrderBy(f => f.BirthDate).Take(3).ToList();
        }
        public IList<Passenger> SeniorTravellers2(Flight flight)
        {
            /*var query = from p in flight.Passengers
                        where p is Traveller
                        orderby p.BirthDate ascending
                        select p;
            return query.Take(3).ToList();*/
            return flight.Passengers.Where(p=>p is Traveller).OrderBy(f => f.BirthDate).Take(3).ToList();   
        }
        public void DestinationGroupedFlights()
        {
            /*var query = from f in Flights
                        group f by f.Destination;

            foreach (var f in query)
            {
                Console.WriteLine("Destination "+f.Key);
                foreach (var item in f)
                {
                    Console.WriteLine("Décollage : "+item.FlightDate);
                }
            }*/
            foreach (var f in Flights.GroupBy(f=>f.Destination))
            {
                Console.WriteLine("Destination " + f.Key);
                foreach (var item in f)
                {
                    Console.WriteLine("Décollage : " + item.FlightDate);
                }
            }

        }
        #endregion

        #region Delegate
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        public ServiceFlight()
        {
            //DurationAverageDel = DestinationAvg;
            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };
            //FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.Plane == p
                          select new { f.FlightDate, f.Destination };
                foreach (var v in req)
                    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
            };
        }
        #endregion
    }
}
