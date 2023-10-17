using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using static WebApplication1.Carreras.DetalleCarrera;

namespace WebApplication1.Tutores
{
    public partial class GestionDictados : System.Web.UI.Page
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
                Session["id_dictado_editar"] = null;
                if (!IsPostBack)
                {
                    CargarCursos();
                    ViewState["empresabe"] = null;
                }
            }
        }

        protected void btnEditDictation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/EditarDictado.aspx");
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
            ViewState["empresabe"] = new Curso_BLL().ListarCursos().FirstOrDefault(item => item.Id == idCurso);
            CargarDictados();
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);


            // Obteniendo el valor de Id del curso usando DataKeys
            int idDictado = Convert.ToInt32(dictationsGrid.DataKeys[rowIndex].Value);
            Session["id_dictado_editar"] = idDictado;
            Response.Redirect("~/Tutores/Dictado/EditarDictado.aspx");
        }

        private void CargarCursos()
        {
            string terminoBusquedaNombre = searchCourseName.Text.Trim().ToLower();

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CargarCursos();
        }


        protected void dictationsGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            Curso_BE curso = (Curso_BE)ViewState["empresabe"];
            Dictado_BLL dictadobll = new Dictado_BLL();
            List<Dictado_BE> dictados = dictadobll.ListarDictadosCurso(curso);

            if (dictados != null)
            {
                DataTable dt = ConvertToDataTable(dictados);
                DataView dv = dt.DefaultView;

                // Alterna entre la dirección de ordenación
                if (ViewState["SortDirection"] == null || ViewState["SortDirection"].ToString() == "DESC")
                {
                    ViewState["SortDirection"] = "ASC";
                }
                else
                {
                    ViewState["SortDirection"] = "DESC";
                }

                dv.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();

                dictationsGrid.DataSource = dv;
                dictationsGrid.DataBind();
            }
        }

        // Función auxiliar para convertir una lista a DataTable
        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            // Limpiamos las fechas del filtro.
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;

            // Recargar los dictados.
            CargarDictados();
        }

        private void CargarDictados()
        {
            Curso_BE curso = (Curso_BE)ViewState["empresabe"];
            Dictado_BLL dictadoBLL = new Dictado_BLL();

            // Verificamos si se ingresaron fechas en los campos correspondientes.
            DateTime fechaInicio;
            DateTime fechaFin;
            bool filtroFechaInicio = DateTime.TryParse(txtFechaInicio.Text, out fechaInicio);
            bool filtroFechaFin = DateTime.TryParse(txtFechaFin.Text, out fechaFin);

            List<Dictado_BE> dictados;

            if (filtroFechaInicio && filtroFechaFin)
            {
                // Aplicamos el filtro de fechas si ambos campos tienen fechas válidas.
                dictados = dictadoBLL.ListarDictadosPorFechas(curso, fechaInicio, fechaFin);
            }
            else
            {
                // Si no hay fechas de filtro, obtenemos todos los dictados.
                dictados = dictadoBLL.ListarDictadosCurso(curso);
            }

            // Enlazamos la lista resultante con el GridView.
            dictationsGrid.DataSource = dictados;
            dictationsGrid.DataBind();

            if (dictationsGrid.Rows.Count > 0)
            {
                MostrarControlesDeFechas(true);
            }
            else
            {
                MostrarControlesDeFechas(false);
                txtFechaInicio.Text = string.Empty;
                txtFechaFin.Text = string.Empty;
            }
        }
        private void MostrarControlesDeFechas(bool mostrar)
        {
            // Aquí, debes reemplazar 'dateFilterSection' con el ID real de tu div que contiene los datepickers y botones si no usaste el estilo inline como se mencionó anteriormente.
            dateFilterSection.Style["display"] = mostrar ? "block" : "none";
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Recargar dictados con el nuevo filtro aplicado.
            CargarDictados();
        }



    }
}