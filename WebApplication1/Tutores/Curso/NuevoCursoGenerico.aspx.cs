using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Nuevo
{
    public partial class NuevoCursoGenerico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDummyData();
            }
        }

        private void BindDummyData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre de la Carrera");

            // Añade algunas filas con datos dummy
            dt.Rows.Add("Carrera 1");
            dt.Rows.Add("Carrera 2");
            dt.Rows.Add("Carrera 3");

            //careersGrid.DataSource = dt;
            //careersGrid.DataBind();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            //Si cursoBE es uno, derivas a uno, sino derivas al otro
            Response.Redirect("~/Tutores/GestionCursos.aspx");
        }
    }
}