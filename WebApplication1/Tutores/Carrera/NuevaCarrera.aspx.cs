using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Carrera
{
    public partial class NuevaCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateCareer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionCarreras.aspx");
        }
    }
}