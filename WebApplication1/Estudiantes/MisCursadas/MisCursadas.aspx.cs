using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes.Cursadas
{
    public partial class MisCursadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Llena los datos de prueba en el GridView
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4]
                    {
                new DataColumn("Nombre", typeof(string)),
                new DataColumn("Horario", typeof(string)),
                new DataColumn("FechadeInicio", typeof(string)),
                new DataColumn("FechadeFin", typeof(string))
                    });

                dt.Rows.Add("Curso 1", "8:00 AM - 10:00 AM", "01/01/2023", "01/06/2023");
                dt.Rows.Add("Curso 2", "10:00 AM - 12:00 PM", "02/01/2023", "02/06/2023");

                // Asignar DataTable al GridView
                coursesGrid.DataSource = dt;
                coursesGrid.DataBind();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/MisCursadas/Cursada.aspx");
       }
    }
}