using System;
using System.Web.UI;
using System.Web.Security;

namespace CPRG214.Marina.App
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if Context.User.Identity.IsAuthenticated (set innerhtml of uxLogin and uxWelcome)
            if (Context.User.Identity.IsAuthenticated)
            {
                uxWelcome.InnerText = $"Welcome {Context.User.Identity.Name}";
                uxLogin.InnerHtml = "<span class='fa fa-sign-out-alt'>";
            }
            else
            {
                uxLogin.InnerHtml = "<span class='fa fa-sign-in-alt'>";
                uxWelcome.InnerText = string.Empty;
            }
        }

        protected void HandleLoginClick(object sender, EventArgs e)
        {
            //check if Context.User.Identity.IsAuthenticated (signout auth ticket, clear session, redirect)
            if (Context.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Response.Redirect("~/");
            }
            else
            {
                Response.Redirect("~/Login");
            }

            Response.Write("<script>alert('Login Clicked');</script>");

        }
    }
}