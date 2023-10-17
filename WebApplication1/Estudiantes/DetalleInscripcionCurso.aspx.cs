using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes
{
    public partial class DetalleInscripcionCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Inscripciones")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {

                if (!IsPostBack)
                {
                    if (Session["id_inscripcion_curso"] == null)
                    {
                        Response.Write("<script>alert('No se encuentra la inscripcion');window.location.href = '/Default.aspx';</script>");
                    }
                    int idInscripcion = int.Parse(Session["id_inscripcion_curso"].ToString());
                    InscripcionCurso_BE inscripcion = new Dictado_BLL().ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);
                    Dictado_BE dictado = new Dictado_BLL().ListarDictados().SingleOrDefault(d => d.Id == inscripcion.IdDictado);
                    //complete the labels
                    lblCourseName.Text = dictado.Curso.Nombre;
                    lblCourseDescription.Text = dictado.Curso.Descripcion;
                    lblStartDate.Text = dictado.FechaInicio.ToString("dd/MM/yyyy");
                    lblEndDate.Text = dictado.FechaFin.ToString("dd/MM/yyyy");
                    lblCourseEspeciality.Text = dictado.Curso.Especialidad.Nombre;
                    lblTutores.Text = string.Join(", ", dictado.Tutores.Select(t => t.Nombre + " " + t.Apellido));
                    //show horarios which is a list in the label for schedul
                    lblSchedule.Text = string.Join(", ", dictado.Horarios.Select(h => h.Dia + " " + h.HoraInicio + " a " + h.HoraFin));
                }
            }
        }

        protected void btnUnenroll_Click(object sender, EventArgs e)
        {
            int idInscripcion = int.Parse(Session["id_inscripcion_curso"].ToString());
            InscripcionCurso_BE inscripcion = new Dictado_BLL().ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);
            Dictado_BLL dictadoblll = new Dictado_BLL();
            dictadoblll.EliminarInscripcion(inscripcion);
            Response.Redirect("~/Estudiantes/GestionarInscripciones.aspx");
        }

        protected void ButtonIrAlCurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/MisCursadas/Cursada.aspx");
        }
    }
}