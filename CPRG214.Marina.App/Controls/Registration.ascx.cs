using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Data;

namespace CPRG214.Marina.App.Controls
{
    public partial class Registration : System.Web.UI.UserControl
    {
        public bool IsUpdate { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                //get customer id out of session
                if (Session["CustomerID"] != null && uxFirstName.Text == string.Empty)
                {
                    //need to convert the object in session to an int
                    var id = Convert.ToInt32(Session["CustomerID"]);

                    //get the Authentication object from the manager
                    var auth = MarinaManager.FindAuthentication(id);

                    //set the state of the form
                    if (auth != null)
                    {
                        uxFirstName.Text = auth.FirstName;
                        uxLastName.Text = auth.LastName;
                        uxPhone.Text = auth.Phone;
                        uxCity.Text = auth.City;
                        uxUsername.Text = $"{auth.FirstName}";      // pseudo login 
                        uxPassword.Text = $"{auth.LastName}";       // pseudo login 
                    }
                }
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (IsUpdate)
            {
                //updating the record
                //get customer id out of session
                if (Session["CustomerID"] != null)
                {
                    var id = Convert.ToInt32(Session["CustomerID"]);
                    //get the Authentication object from the manager
                    var auth = MarinaManager.FindAuthentication(id);

                    auth.FirstName = uxFirstName.Text;
                    auth.LastName = uxLastName.Text;
                    auth.City = uxCity.Text;
                    auth.Username = uxUsername.Text;
                    auth.Password = uxPassword.Text;
                    //pass auth to the manager for updating
                    MarinaManager.UpdateAuthentication(auth);

                    //remove from auth ticket, clear session and redirect
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Response.Redirect("~/Login");
                }
            }
            else
            {
                //inserting the record
                var auth = new AuthenticationDTO
                {
                    FirstName = uxFirstName.Text,
                    LastName = uxLastName.Text,
                    Phone = uxPhone.Text,
                    City = uxCity.Text
                };
                //pass the auth object to the manager for inserting
                MarinaManager.AddAuthentication(auth);

                Response.Redirect("~/Login");
            }
        }
    }
}