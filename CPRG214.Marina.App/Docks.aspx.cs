using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Data;

namespace CPRG214.Marina.App
{
    public partial class Docks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = new MarinaEntities();
                uxDocks.DataSource = db.Docks.ToList();
                uxDocks.DataBind();
            }
        }
    }
}