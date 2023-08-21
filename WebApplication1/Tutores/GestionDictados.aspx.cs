using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores
{
    public partial class GestionDictados : System.Web.UI.Page
    {

        public class Curso
        {
            public string Nombre { get; set; }
        }

        public class Dictado
        {
            public DateTime FechadeFin { get; set; }
            public DateTime FechadeInicio { get; set; }
            public string Horarios { get; set; }
            public string Tutores { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lista de prueba para Cursos
                List<Curso> listaCursos = new List<Curso>
        {
            new Curso { Nombre = "Curso 1" },
            new Curso { Nombre = "Curso 2" }
        };

                // Bind la lista de prueba a GridView
                coursesGrid.DataSource = listaCursos;
                coursesGrid.DataBind();

                // Lista de prueba para Dictados
                List<Dictado> listaDictados = new List<Dictado>
        {
            new Dictado { FechadeInicio = DateTime.Now, FechadeFin = DateTime.Now.AddDays(7), Horarios = "Lunes y Miércoles 18:00 - 20:00", Tutores = "Juan, Maria" },
            new Dictado { FechadeInicio = DateTime.Now.AddDays(1), FechadeFin = DateTime.Now.AddDays(8), Horarios = "Martes y Jueves 16:00 - 18:00", Tutores = "Carlos, Ana" }
        };

                // Bind la lista de prueba a GridView
                dictationsGrid.DataSource = listaDictados;
                dictationsGrid.DataBind();
            }
        }

        protected void btnEditDictation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/EditarDictado.aspx");
        }
    }
}