using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores
{
    public partial class NuevaCarrera : System.Web.UI.Page
    {
        Carrera_BLL mapper = new Carrera_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["id_carrera_editar"] = null;
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCarreras")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
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
            string terminoBusqueda = SearchCareerTextBox.Text.Trim().ToLower(); // Obtener el término de búsqueda y convertirlo a minúsculas

            Carrera_BLL carreraBll = new Carrera_BLL();
            List<Carrera_BE> todasLasCarreras = carreraBll.ListarCarreras();

            // Utilizar LINQ para filtrar las carreras basado en el término de búsqueda
            var carrerasFiltradas = todasLasCarreras.Where(c => c.Nombre.ToLower().Contains(terminoBusqueda)).ToList();

            CareersGrid.DataSource = carrerasFiltradas;
            CareersGrid.DataBind();
        }

        protected void NewCareerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Carrera/NuevaCarrera.aspx");
        }

        protected void EditCareerButton_Click(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de IdEmpresa usando DataKeys
            string idEmpresa = CareersGrid.DataKeys[rowIndex].Value.ToString();

            // Ahora puedes usar idEmpresa para tus propósitos
            Session["id_carrera_editar"] = idEmpresa;

            Response.Redirect("~/Tutores/Carrera/EditarCarrera.aspx");
        }

        protected void DeleteCareerButton_Click(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de IdEmpresa usando DataKeys
            string idCarrera = CareersGrid.DataKeys[rowIndex].Value.ToString();

            Carrera_BE carrerabe = (Carrera_BE)mapper.ListarCarreras().FirstOrDefault(item => item.Id == int.Parse(idCarrera.ToString()));

            mapper.EliminarCarrera(carrerabe);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empresa eliminada con exito')", true);

            CargarCarreras();
         
        }

        protected void SearchCareerButton_Click(object sender, EventArgs e)
        {
            CargarCarreras();
        }
    }
}