using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ConsultarTutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridWithDummyData();
            }
        }

        private void FillGridWithDummyData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Curso");

            DataRow dr1 = dt.NewRow();
            dr1["Nombre"] = "John Doe";
            dr1["Curso"] = "Curso Interactivo 1";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["Nombre"] = "Jane Smith";
            dr2["Curso"] = "Curso Autodirigido 2";
            dt.Rows.Add(dr2);

            // Asigna la tabla de datos como origen de datos del GridView y haz un enlace de datos
            tutorsGrid.DataSource = dt;
            tutorsGrid.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // Implementa la lógica para manejar la selección de un tutor aquí
        }
    }
}