// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
// constructeur par defaut
Plane plane= new Plane();
plane.Capacity = 10;
Console.WriteLine("plane information  = " + plane.ToString());//cwl + (2*tab)
// constructeur parametré
Plane plane1 = new Plane(150,DateTime.Now,1,PlaneType.Airbus); 
Console.WriteLine("plane1 information  = " + plane1.ToString());
// initialiseur d'objet
Plane plane2 = new Plane { PlaneType= PlaneType.Airbus ,
    ManufactureDate=new DateTime(2023,01,30)};
Console.WriteLine("plane2 information  = " + plane2.ToString());
// test TP1
Passenger p = new Passenger()
{
    BirthDate = new DateTime(2022, 12, 30),
    EmailAddress = "amine@esprit.tn",
    FirstName="amine",
    LastName="cherif",
    PassportNumber="abc123456",
    TelNumber="+216 53596889",
};
Staff staff = new Staff()
{
    BirthDate = new DateTime(2022, 12, 30),
    EmailAddress = "tassnime@esprit.tn",
    FirstName = "tassnime",
    LastName = "kabous",
    PassportNumber = "abc123456",
    TelNumber = "+216 53596889",
    EmployementDate=new DateTime(2022,02,20),
    Function="Capitaine",
    Salary=15000,

};
// cwl +2tab
Console.WriteLine(p.PassengerType());
Console.WriteLine(staff.PassengerType());
//test TP2
ServiceFlight serviceFlight=new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;
Console.ReadKey();  


