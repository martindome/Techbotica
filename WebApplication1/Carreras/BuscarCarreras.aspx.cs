using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
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
        Carrera_BLL mapper = new Carrera_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["id_carrera_inscribir"] = null;
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Inscripciones")))
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarCarreras();
                }
            }

        }

        private void CargarCarreras()
        {
            Usuario_BE usuario = (Usuario_BE)Session["usuario"];
            if (usuario != null)
            {
                int idUsuario = usuario.IdUsuario; // Asume que la clase Usuario_BE tiene una propiedad IdUsuario para el ID del usuario.

                // Obtener todas las inscripciones del usuario
                List<InscripcionCarrera_BE> inscripciones = mapper.ListarInscripcionesPorEstudiante(idUsuario);
                List<int> carrerasInscritasIds = inscripciones.Select(i => i.IdCarrera).ToList();

                string terminoBusqueda = SearchCareerTextBox.Text.Trim().ToLower();

                List<Carrera_BE> todasLasCarreras = mapper.ListarCarreras();

                // Filtrar carreras basado en el término de búsqueda y que no estén en la lista de inscripciones del usuario
                var carrerasFiltradas = todasLasCarreras
                    .Where(c => c.Nombre.ToLower().Contains(terminoBusqueda) && !carrerasInscritasIds.Contains(c.Id))
                    .ToList();

                CareersGrid.DataSource = carrerasFiltradas;
                CareersGrid.DataBind();
            }
        }


        protected void EnrollCareer_CLICK(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de IdEmpresa usando DataKeys
            string idEmpresa = CareersGrid.DataKeys[rowIndex].Value.ToString();


            Session["id_carrera_inscribir"] = idEmpresa;

            Response.Redirect("~/Carreras/DetalleCarrera.aspx");
        }

        protected void SearchCareerButton_Click(object sender, EventArgs e)
        {
            CargarCarreras();
        }
    }
}