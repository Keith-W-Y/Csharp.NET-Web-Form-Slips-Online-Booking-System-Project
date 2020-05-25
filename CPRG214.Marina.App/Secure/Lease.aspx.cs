using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Data;

namespace CPRG214.Marina.App.Secure
{
    public partial class Lease : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DockSelector.DockSelect += DockSelector_DockSelect;
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            if (Session["CustomerID"] == null) return;
            var CustomerID = Session["CustomerID"].ToString();
            var id = int.Parse(CustomerID);

            var LeaseEnrollment = MarinaManager.GetCustomerLeaseEnrollment(id);

            uxEnrollment.DataSource = LeaseEnrollment;
            uxEnrollment.DataBind();
        }



        private void DockSelector_DockSelect(object sender, Controls.DockEventArgs e)
        {
            var dockID = e.ID;
            var slips = MarinaManager.GetAllSlipsByDockId(dockID);
            uxSlips.DataSource = slips;
            uxSlips.DataValueField = "ID";
            uxSlips.DataTextField = "ID";      // slip ID
            uxSlips.DataBind();
        }

        protected void uxEnroll_Click(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null) return;

            var CustomerID = Session["CustomerID"].ToString();

            var LeaseToDB = new LeaseDTO
            {
                SlipID = uxSlips.SelectedValue,
                CustomerID = CustomerID,
            };

            //pass the dto object to the service to enroll
            MarinaManager.EnrollService(LeaseToDB);
        }

    }
}