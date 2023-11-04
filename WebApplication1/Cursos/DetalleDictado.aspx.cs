using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication1.Cursos
{
    public partial class DetalleDictado : System.Web.UI.Page
    {
        Dictado_BE dictado;
        Dictado_BLL dictado_BLL = new Dictado_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Inscripciones")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (Session["id_dictado_inscribir"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado inexistente');window.location.href = '/Default.aspx'", true);
                }
                if (!IsPostBack)
                {
                    Session["numero_inscripcion_curso"] = null;
                    ViewState["dictado"] = new Dictado_BE();
                    dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_inscribir"].ToString()));
                    ViewState["dictado"] = dictado;
                    // Si hay un dictado disponible, establece los valores
                    if (dictado != null)
                    {
                        CargarDatosDictado(dictado);
                    }
                }

            }

        }

        private void CargarDatosDictado(Dictado_BE dictado)
        {
            // Cargando y mostrando la información básica del dictado
            lblCourseName.Text = dictado.Curso?.Nombre ?? "No disponible";
            lblCourseDescription.Text = dictado.Curso?.Descripcion ?? "No disponible";
            lblStartDate.Text = dictado.FechaInicio.ToString("dd/MM/yyyy");
            lblEndDate.Text = dictado.FechaFin.ToString("dd/MM/yyyy");
            lblAvailableSpots.Text = dictado.Cupo.ToString();

            // Cargando y mostrando los tutores
            lblTutors.Text = (dictado.Tutores != null && dictado.Tutores.Count > 0) ?
                string.Join(", ", dictado.Tutores.Select(t => t.Nombre + " " + t.Apellido)) :
                "No hay tutores asignados";

            // Cargando y mostrando los horarios
            lblTutors.Text = string.Join(", ", dictado.Tutores.Select(t => t.Nombre + " " + t.Apellido));

            // Cargando y mostrando los horarios utilizando foreach
            StringBuilder horariosBuilder = new StringBuilder();
            foreach (var horario in dictado.Horarios)
            {
                if (horario != null)
                {
                    horariosBuilder.AppendLine($"{horario.Dia} {horario.HoraInicio:hh\\:mm} - {horario.HoraFin:hh\\:mm}");
                    horariosBuilder.AppendLine($"--");
                }
            }

            string horariosStr = horariosBuilder.ToString();
            lblSchedule.Text = !string.IsNullOrEmpty(horariosStr) ? horariosStr : "No disponible";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                // Si no hay una URL de referencia, puedes redirigir a una página predeterminada
                Response.Redirect("~/Default.aspx");
            }
        }


        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            // Obteniendo el usuario actual
            Usuario_BE usuario = (Usuario_BE)Session["usuario"];

            if (usuario != null)
            {
                // Obteniendo la información del dictado desde la variable de sesión
                int? id_dictado_inscribir = Session["id_dictado_inscribir"] as int?;

                if (id_dictado_inscribir.HasValue)
                {
                    Dictado_BLL dictado_BLL = new Dictado_BLL();
                    dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_inscribir"].ToString()));
                    InscripcionCurso_BE nuevaInscripcion = dictado_BLL.NuevaInscripcion(usuario.IdUsuario, id_dictado_inscribir.Value, dictado.Curso.Id);

                    if (nuevaInscripcion != null)
                    {
                        Session["numero_inscripcion_curso"] = nuevaInscripcion.Id;
                        Response.Redirect("~/Cursos/ConfirmacionInscripcion.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error en la inscripcion.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error en la inscripcion');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Error en la inscripcion');</script>");
            }
        }

        protected void btnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos/DetalleCurso.aspx");
        }
    }
}