using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Data;


namespace CPRG214.Marina.App.Controls
{
    public partial class DockSelector : System.Web.UI.UserControl
    {

        // declare the event
        public event DockSelectionHandler DockSelect;

        // Dock Property to someone can get the course object
        public Dock Dock { get; set; }

        //Boolean property to set the AutoPostBack
        public bool AllowPostBack
        {
            get { return uxDocks.AutoPostBack; }
            set { uxDocks.AutoPostBack = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var mgr = new MarinaManager();
                uxDocks.DataSource = mgr.GetAllAsListDocks();
                uxDocks.DataTextField = "Name";
                uxDocks.DataValueField = "ID";
                uxDocks.DataBind();
                uxDocks.SelectedIndex = 0;
                uxDocks_SelectedIndexChanged(this, e);
            }
        }


        protected void uxDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // the event is fired here
            if (DockSelect != null)
            {
                // get the id from the dropdownlist(ddl) (SelectedValue cast to an int)
                var id = Convert.ToInt32(uxDocks.SelectedValue);

                // call the manager class to get the dock object
                Dock dock = MarinaManager.FindDock(id);

                // instantiate the CourseEventArgs 
                var arg = new DockEventArgs
                {
                    ID = dock.ID,
                    Name = dock.Name,
                    WaterService = dock.WaterService,
                    ElectricalService = dock.ElectricalService
                };

                // invoke the event and pass the param values
                DockSelect.Invoke(this, arg);
            }
        }
    }
}