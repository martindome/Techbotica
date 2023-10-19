using BusinessEntity;
using BusinessLayer;
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
                Session["id_dictado_ver"] = null;
                CargarDictados();
            }
        }

        private void CargarDictados()
        {
            Usuario_BE usuario = (Usuario_BE)Session["usuario"];
            int userId = usuario.IdUsuario;

            Dictado_BLL dictadobll = new Dictado_BLL();
            List<Dictado_BE> dictados = dictadobll.ListarDictados();

            List<InscripcionCurso_BE> inscripciones = dictadobll.ListarInscripcionesPorEstudiante(userId);

            //filtrar todos los dictados los cuales no este inscript el usuario
            dictados = dictados.Where(d => inscripciones.Any(i => i.IdDictado == d.Id)).ToList();

            //filter dictados by Curso.name based on value serachDictationName
            dictados = dictados.Where(d => d.Curso.Nombre.ToLower().Contains(searchDictationName.Text.ToLower())).ToList();

            // Filtros aplicados desde la UI
            DateTime startDate;
            if (DateTime.TryParse(searchStartDate.Text, out startDate))
            {
                dictados = dictados.Where(d => d.FechaInicio >= startDate).ToList();
            }
            // else if filter dictations which FechaFin is greater than today
            else
            {
                dictados = dictados.Where(d => d.FechaFin >= DateTime.Now).ToList();
            }

            DateTime endDate;
            if (DateTime.TryParse(searchEndDate.Text, out endDate))
            {
                dictados = dictados.Where(d => d.FechaFin <= endDate).ToList();
            }

            // Mostrar resultados
            UserCoursesGrid.DataSource = dictados;
            UserCoursesGrid.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CargarDictados();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            // Obteniendo el valor de Id del curso usando DataKeys
            int idCurso = Convert.ToInt32(UserCoursesGrid.DataKeys[rowIndex].Value);
            // Almacena el ID del curso en una variable de sesión para usarlo en la página de edición
            Session["id_dictado_ver"] = idCurso;
            Response.Redirect("~/Estudiantes/MisCursadas/Cursada.aspx");
        }
    }
}