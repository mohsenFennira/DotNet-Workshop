using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public /*abstract*/ class Passenger
    {
        // public int Id { get; set; } 
        
        [Display (Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [MaxLength(255,ErrorMessage ="max length must be 255")]
        [MinLength(1,ErrorMessage ="min length must be 1")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9](8)$")]
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
