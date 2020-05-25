using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG214.Marina.Data
{
    public class MarinaManager
    {

        public static AuthenticationDTO AuthenticateCustomer(string username, string password)
        {
            //declare a dto object
            AuthenticationDTO dto = null;

            //creating the session to the database (called a context or DbContext)
            var db = new MarinaEntities();

            //find the authentication object based on credentials passed in
            var auth = db.Customers.
                SingleOrDefault(a => a.FirstName == username && a.LastName == password);      // pseudo login
            if (auth != null)
            {
                //authentication passed, so instantiate the dto object
                dto = new AuthenticationDTO
                {
                    Id = auth.ID.ToString(),
                    FirstName = auth.FirstName,
                    LastName = auth.LastName,
                    Phone = auth.Phone,
                    City = auth.City,
                    Username = $"{auth.FirstName}",                       // pseudo login
                    Password = $"{auth.LastName}"                         // pseudo login
                };
            }
            //return the dto object
            return dto;
        }


        public static AuthenticationDTO FindAuthentication(int customerId)
        {
            //use the context to find the authentication object based on customer id
            var db = new MarinaEntities();

            var auth = db.Customers.
                SingleOrDefault(a => a.ID == customerId);
            var dto = new AuthenticationDTO
            {
                Id = auth.ID.ToString(),
                FirstName = auth.FirstName,
                LastName = auth.LastName,
                Phone = auth.Phone,
                City = auth.City,
                Username = $"{auth.FirstName}",                       // pseudo login
                Password = $"{auth.LastName}"                         // pseudo login
            };

            return dto;
        }


        /// <summary>
        /// Static method handles adding a new authentication object to the DB
        /// </summary>
        /// <param name="auth">The authentication object is a DTO object</param>
        public static void AddAuthentication(AuthenticationDTO auth)
        {
            //use the context to add a new authentication object
            var db = new MarinaEntities();

            //assign from dto object to the entity object
            var authFromContext = new Customer
            {
                FirstName = auth.FirstName,
                LastName = auth.LastName,
                Phone = auth.Phone,
                City = auth.City
             };

            db.Customers.Add(authFromContext);
            db.SaveChanges();
        }

        /// <summary>
        /// Static method handles the update of an existing authentication object
        /// </summary>
        /// <param name="auth">The authentication object as a DTO</param>
        public static void UpdateAuthentication(AuthenticationDTO auth)
        {
            //use the context to update an existing record
            var id = Convert.ToInt32(auth.Id);
            var db = new MarinaEntities();

            //we need to get an authentication object from the context
            //so that we can update it with values from the dto passed in
            var authFromContext = db.Customers.SingleOrDefault(a => a.ID == id);
            authFromContext.FirstName = auth.FirstName;
            authFromContext.Phone = auth.Phone;
            authFromContext.City = auth.City;

            //save changes--no need to add the object back to the context as the context
            //already has it
            db.SaveChanges();
        }


        public IList GetAllAsListDocks()
        {
            var db = new MarinaEntities();
            var docks = db.Docks.Select(dks => new
            { ID = dks.ID, Name = dks.Name }).ToList();
            return docks;
        }

        public static Dock FindDock(int id)
        {
            var db = new MarinaEntities();
            var dock = db.Docks.SingleOrDefault(c => c.ID == id);
            return dock;
        }


        public static List<SlipDTO> GetAllSlipsByDockId(int id)
        {
            var db = new MarinaEntities();
            //get the filtered data using Where and transform to dto objects using Select
            var slips = db.Slips.
                              Where(cs => cs.DockID == id && cs.Leases.Count == 0).
                              Select(s => new SlipDTO
                              {
                                  ID = s.ID.ToString(),
                                  Width = s.Width.ToString(),
                                  Length = s.Length.ToString(),
                                  DockID = s.DockID.ToString()
                              }).ToList();
            return slips;
        }


        public static void EnrollService(LeaseDTO LeaseToDB)
        {
            var db = new MarinaEntities();

            var sc = new Lease
            {
                SlipID = int.Parse(LeaseToDB.SlipID),
                CustomerID = int.Parse(LeaseToDB.CustomerID)
            };

            //add lease object to the context and save changes in the database
            db.Leases.Add(sc);
            db.SaveChanges();
        }


        public static List<LeaseOnBoardDTO> GetCustomerLeaseEnrollment(int id)
        {
            var db = new MarinaEntities();
            //get the list of leases registered by the customer
            var leaseList = db.Leases.Where(cs => cs.CustomerID == id).
                Select(s => new LeaseOnBoardDTO
                {
                    CustomerName = s.Customer.FirstName + " " + s.Customer.LastName,
                    DockName = s.Slip.Dock.Name.ToString(),
                    SlipID = s.SlipID.ToString()
                }).ToList();
            return leaseList;
        }
    }
}
