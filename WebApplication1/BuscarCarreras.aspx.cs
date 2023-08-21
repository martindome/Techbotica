using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BuscarCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCarrerasGrid();
            }
        }

        private void BindCarrerasGrid()
        {
            // Generar carreras dummy
            var carreras = new List<Carrera>
    {
        new Carrera { Nombre = "Carrera 1", Descripcion = "Descripción de la Carrera 1" },
        new Carrera { Nombre = "Carrera 2", Descripcion = "Descripción de la Carrera 2" },
        new Carrera { Nombre = "Carrera 3", Descripcion = "Descripción de la Carrera 3" }
    };

            // Asignar los datos al GridView
            carrerasGrid.DataSource = carreras;
            carrerasGrid.DataBind();
        }

        public class Carrera
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Carreras/DetalleCarrera");
        }
    }
}