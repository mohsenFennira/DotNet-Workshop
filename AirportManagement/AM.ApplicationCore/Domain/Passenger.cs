using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public /*abstract*/ class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        // prop de navig
        public virtual IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName : " + FirstName + "LastName : " + LastName+
              "TelNumber : " + TelNumber + "EmailAdress : " + EmailAddress +
             "PassportNumber : " + PassportNumber;
        }
       public bool CheckProfile(string firstName ,string lastName)
        {
            if(firstName==this.FirstName && lastName==this.LastName)
                return true; 
            return false;   
        }
        public bool CheckProfile(string firstName, string lastName,string email)
        {
            if (firstName == this.FirstName && lastName == this.LastName && email==this.EmailAddress)
                return true;
            return false;
        }
        public bool CheckProfile2(string firstName, string lastName, string? email = null)
        {
            if (email == null)
            
               return  CheckProfile(firstName, lastName);    
            
            else return CheckProfile(firstName, lastName,email); 
        }
       public  virtual string PassengerType()

        {
            return "I am a passenger";
        }
      //  public abstract string PassengerType2();
       
    }


}
