using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Data;

namespace CPRG214.Marina.App
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxAuthenticate_Click(object sender, EventArgs e)
        {
            //pass the credentials to the AuthenticationManager
            var Customer = MarinaManager.AuthenticateCustomer(uxUsername.Text, uxPassword.Text);

            // add customer id to session
            Session.Add("CustomerID", Customer.Id);

            // redirect
            FormsAuthentication.RedirectFromLoginPage(Customer.FirstName, false);
            //FormsAuthentication.SetAuthCookie(Customer.FirstName, true);
            Response.Redirect("~/secure/lease.aspx");
        }
    }
}