using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class MyExtensions
    {
        public static void UpperFullName(this Passenger pass)
        {
            pass.FirstName = pass.FirstName[0].ToString().ToUpper()+pass.FirstName.Substring(1);
            pass.LastName = pass.LastName[0].ToString().ToUpper()+pass.LastName.Substring(1);    
        }
        public static void AddToCapacity(this Plane plane)
        {
            plane.Capacity = plane.Capacity + 10;
        }
    }
}
