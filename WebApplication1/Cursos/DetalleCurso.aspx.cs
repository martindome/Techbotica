using BusinessEntity.Composite;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace WebApplication1.Cursos
{
    public partial class DetalleCurso : System.Web.UI.Page
    {

        Curso_BLL mapperCurso = new Curso_BLL();
        Curso_BE cursoBE;
        Carrera_BLL mapper_carrera = new Carrera_BLL();
        List<Carrera_BE> carrerasAsignadas = new List<Carrera_BE>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_dictado_inscribir"] = null;
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Inscripciones")))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["id_curso_inscribir"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Curso inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    cursoBE = mapperCurso.ListarCursos().FirstOrDefault(item => item.Id == int.Parse(Session["id_curso_inscribir"].ToString()));
                    ViewState["cursoBE"] = cursoBE;

                    lblCourseName.Text = cursoBE.Nombre;
                    lblCourseDescription.Text = cursoBE.Descripcion;
                    lblCourseSpeciality.Text = cursoBE.Especialidad.Nombre;
                    CargarDictados();
                }
            }
        }

        private void CargarDictados()
        {
            Curso_BE curso = (Curso_BE)ViewState["cursoBE"];
            Dictado_BLL dictadobll = new Dictado_BLL();
            List<Dictado_BE> dictados = dictadobll.ListarDictadosCurso(curso);

            // Filtros aplicados desde la UI
            DateTime startDate;
            if (DateTime.TryParse(searchStartDate.Text, out startDate))
            {
                dictados = dictados.Where(d => d.FechaInicio >= startDate).ToList();
            }
            // else if filter dictations which FechaInicio is greater than today
            else
            {
                dictados = dictados.Where(d => d.FechaInicio >= DateTime.Now).ToList();
            }

            DateTime endDate;
            if (DateTime.TryParse(searchEndDate.Text, out endDate))
            {
                dictados = dictados.Where(d => d.FechaFin <= endDate).ToList();
            }

            string modalidad = searchCourseType.SelectedValue;
            if (!string.IsNullOrWhiteSpace(modalidad))
            {
                dictados = dictados.Where(d => d.TipoDictado == modalidad).ToList();
            } 

            // Mostrar resultados
            dictationsGrid.DataSource = dictados;
            dictationsGrid.DataBind();
        }


        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);


            // Obteniendo el valor de Id del curso usando DataKeys
            int idDictado = Convert.ToInt32(dictationsGrid.DataKeys[rowIndex].Value);
            // find dictado and save it in new dictadoBE
            Dictado_BLL dictadoBLL = new Dictado_BLL();
            Dictado_BE dictadoBE = dictadoBLL.ListarDictados().FirstOrDefault(item => item.Id == idDictado);

            //Getall the inscripciones for the dictado
            List<InscripcionCurso_BE> inscripciones = dictadoBLL.ListarInscripcionesPorDictado(idDictado);

            //if the inscripciones count is equal to the dictado cupo, show error message
            if (inscripciones.Count == dictadoBE.Cupo)
            {
                Response.Write("<script>alert('No se puede inscribir a un mensaje que ya esta lleno.');</script>");
            }
            // check if dictadoBE fechaInicio is minor than today If thats true, show error message
            else if (dictadoBE.FechaInicio < DateTime.Now)
            {
                Response.Write("<script>alert('No se puede inscribir a un mensaje que ya comenzo.');</script>");
            }
            else
            {
                Session["id_dictado_inscribir"] = idDictado;
                Response.Redirect("~/Cursos/DetalleDictado.aspx");
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CargarDictados();
        }
    }
}