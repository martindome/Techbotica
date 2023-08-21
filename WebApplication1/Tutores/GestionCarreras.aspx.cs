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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear lista de carreras dummy
                List<string> dummyCareers = new List<string>
                {
                    "Ingeniería de Sistemas",
                    "Ciencias de la Computación",
                    "Ingeniería Industrial",
                    "Psicología",
                    "Administración de Empresas",
                    "Marketing",
                    "Ingeniería Civil",
                    "Biología"
                    // Añade las carreras que desees
                };

                // Convertir la lista a un DataTable para enlazar con GridView
                DataTable dt = new DataTable();
                dt.Columns.Add("CareerName");

                foreach (string career in dummyCareers)
                {
                    dt.Rows.Add(career);
                }

                // Enlazar el DataTable con el GridView
                CareersGrid.DataSource = dt;
                CareersGrid.DataBind();
            }

            
        }

        protected void CareersGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Aquí puedes poner tu lógica para manejar la edición de una carrera.
            // Por ejemplo, redirigir a la página de edición de carrera con la id de la carrera seleccionada.
        }

        protected void CareersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Aquí puedes poner tu lógica para manejar la eliminación de una carrera.
            // Por ejemplo, mostrar un cuadro de diálogo de confirmación y luego eliminar la carrera si el usuario confirma.
        }

        protected void NewCareerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Carrera/NuevaCarrera.aspx");
        }

        protected void EditCareerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Carrera/EditarCarrera.aspx");
        }

        protected void DeleteCareerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionCarreras.aspx");
        }
    }
}