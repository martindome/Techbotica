using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Curso
{
    public partial class EditarCurso : System.Web.UI.Page
    {
        Curso_BLL mapperCurso = new Curso_BLL();
        Curso_BE cursoBE;
        Carrera_BLL mapper_carrera = new Carrera_BLL();
        List<Carrera_BE> carrerasAsignadas = new List<Carrera_BE>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCursos")))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["id_curso_editar"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Curso inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    cursoBE = mapperCurso.ListarCursos().FirstOrDefault(item => item.Id == int.Parse(Session["id_curso_editar"].ToString()));
                    ViewState["cursoBE"] = cursoBE;

                    CourseName.Text = cursoBE.Nombre;
                    CourseDescription.Text = cursoBE.Descripcion;
                    CargarEspecialidades();
                    ListItem selectedItem = CourseSpeciality.Items.FindByValue(cursoBE.Especialidad.IdEspecialidad.ToString());
                    if (selectedItem != null)
                    {
                        CourseSpeciality.ClearSelection();
                        selectedItem.Selected = true;
                    }
                }
            }
        }

        protected void UpdateCourseButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cursoBE = (Curso_BE)ViewState["cursoBE"];
                Session["id_curso_editar"] = null;
                cursoBE.Nombre = CourseName.Text;
                cursoBE.Descripcion = CourseDescription.Text;
                mapperCurso.ActualizarCurso(cursoBE);


                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Curso actualizado con éxito');window.location.href = '/Tutores/GestionCursos.aspx'", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id_curso_editar"] = null;
            Response.Redirect("~/Tutores/GestionCursos.aspx");
        }

        private void CargarEspecialidades()
        {
            Especialidad_BLL especialidadBLL = new Especialidad_BLL();
            List<Especialidad_BE> listaEspecialidades = especialidadBLL.ListarEspecialidades();

            CourseSpeciality.DataSource = listaEspecialidades;
            CourseSpeciality.DataTextField = "Nombre";  // Asumiendo que tu clase Especialidad_BE tiene un atributo "NombreEspecialidad"
            CourseSpeciality.DataValueField = "IdEspecialidad";                 // y un atributo "Id"
            CourseSpeciality.DataBind();
        }

        protected void ButtonEditCareers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Curso/EditarCarreras.aspx");
        }
    }
}