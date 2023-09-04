using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class NuevoDictadoInteractivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarDictados")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarCursos();
                    Session["dictado_crear"] = new Dictado_BE();
                }
            }
            
        }

        protected void NextPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/NuevoDictado2doPaso.aspx");
        }

        protected void SearchCourseButton_Click(object sender, EventArgs e)
        {
            Session["dictado_curso_seleccionado"] = null;
            Session["dictado_crear"] = null;
            CargarCursos();
        }

        private void CargarCursos()
        {
            string terminoBusquedaNombre = SearchCourseTextBox.Text.Trim().ToLower();

            Curso_BLL cursoBll = new Curso_BLL();
            List<Curso_BE> todosLosCursos = cursoBll.ListarCursos();

            var cursosFiltrados = todosLosCursos;

            // Filtrar por Nombre
            if (!string.IsNullOrEmpty(terminoBusquedaNombre))
            {
                cursosFiltrados = cursosFiltrados.Where(c => c.Nombre.ToLower().Contains(terminoBusquedaNombre)).ToList();
            }

            coursesGrid.DataSource = cursosFiltrados;
            coursesGrid.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de Id del curso usando DataKeys
            int idCurso = Convert.ToInt32(coursesGrid.DataKeys[rowIndex].Value);

            // Almacena el ID del curso en una variable de sesión para usarlo en la página de edición
            Session["dictado_curso_seleccionado"] = new Curso_BLL().ListarCursos().FirstOrDefault(item => item.Id == idCurso);
            SelectedCourseTextBox.Text = ((Curso_BE)Session["dictado_curso_seleccionado"]).Nombre.ToString();
        }

        protected void NextPageButton_Click1(object sender, EventArgs e)
        {
            // Obtener la instancia del dictado actual de la sesión
            Dictado_BE dictadoActual = (Dictado_BE)Session["dictado_crear"];

            if (dictadoActual == null)
            {
                dictadoActual = new Dictado_BE();
            }

            // Capturar y guardar los valores introducidos por el usuario
            if (Session["dictado_curso_seleccionado"] != null)
            {
                dictadoActual.Curso = (Curso_BE)Session["dictado_curso_seleccionado"];
            }

            dictadoActual.Enlace = CourseLinkTextBox.Text.Trim();
            dictadoActual.TipoDictado = CourseTypeDropDown.SelectedValue;
            DateTime startDate;
            DateTime endDate;

            if (!DateTime.TryParseExact(StartDateTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate) ||
               !DateTime.TryParseExact(EndDateTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                // Mostrar un mensaje de error si no se pueden convertir las fechas
                Response.Write("<script>alert('Por favor, introduce fechas válidas en los campos correspondientes.');</script>");
                return;
            }

            if (endDate < startDate)
            {
                // Mostrar un mensaje de error si la fecha de fin es anterior a la fecha de inicio
                Response.Write("<script>alert('La fecha de fin no puede ser anterior a la fecha de inicio.');</script>");
                return;
            }

            // Aquí puedes asignar las fechas a tu objeto dictadoActual
            dictadoActual.FechaInicio = startDate;
            dictadoActual.FechaFin = endDate;

            int cupo;
            if (int.TryParse(CapacityTexBox.Text.Trim(), out cupo))
            {
                dictadoActual.Cupo = cupo;
            }
            else
            {
                Response.Write("<script>alert('Por favor, introduce un número válido para el cupo.');</script>");
                return;
            }

            // Guardar el dictado actualizado en la sesión
            Session["dictado_crear"] = dictadoActual;

            // Redireccionar al usuario a la siguiente página
            if(dictadoActual.TipoDictado == "Interactivo")
            {
                Response.Redirect("~/Tutores/Dictado/NuevoDictado2doPaso.aspx");
            }
            else
            {
                Response.Redirect("~/Tutores/Dictado/NuevoDictado3erPaso.aspx");
            }
            
        }
    }
}