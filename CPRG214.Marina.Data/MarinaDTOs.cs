using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG214.Marina.Data
{

    public class DockDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string WaterService { get; set; }
        public string ElectricalService { get; set; }
    }


    public class SlipDTO
    {
        public string ID { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string DockID { get; set; }
    }


    public class LeaseDTO
    {
        public string ID { get; set; }
        public string SlipID { get; set; }
        public string CustomerID { get; set; }
    }


    public class CustomerDTO
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }


    public class AuthenticationDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }


    public class LeaseOnBoardDTO
    {
        public string CustomerName { get; set; }         // First+LastName
        public string DockName { get; set; }
        public string SlipID { get; set; }
        //public string DateEnrolled { get; set; }
    }

}
