using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class NuevoDictado2doPaso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                AssignedSchedulesGrid.DataSource = new List<object>
        {
            new { Schedule = "Horario 2" },
            new { Schedule = "Horario 3" },
            // Agrega más horarios aquí
        };
                AssignedSchedulesGrid.DataBind();

            }
        }

        protected void NextPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/NuevoDictado3erPaso.aspx");
        }
    }
}