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

namespace WebApplication1
{
    public partial class ConsultarTutores : System.Web.UI.Page
    {
        Usuario_BLL usuariobll = new Usuario_BLL();
        Curso_BLL cursobll = new Curso_BLL();
        Dictado_BLL dictadobll = new Dictado_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Consultas")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            if (!IsPostBack)
                txtSelectedTutor.Text = "";
                btnSendQuery.Enabled = false;
                ViewState["tutor"] = null;
        }

        private void LoadTutores()
        {
            // Instanciar la capa de lógica de negocio.
            Curso_BLL cursoBll = new Curso_BLL();
            Dictado_BLL dictadoBll = new Dictado_BLL();
            Usuario_BLL usuarioBll = new Usuario_BLL();

            // Obtener todos los tutores del sistema con los que en la propiesdad Familia.familia es Tutor
            List<Usuario_BE> todosLosTutores = usuarioBll.ListarUsuarios().Where(u => u.Familia.familia == "Tutor").ToList();

            // Obtener el curso basado en el nombre proporcionado si hay contenido en el textbox del curso.
            Curso_BE curso = null;
            if (!string.IsNullOrWhiteSpace(searchCourse.Text))
            {
                curso = cursoBll.ListarCursos().FirstOrDefault(c => c.Nombre == searchCourse.Text);
            }

            // Filtrar tutores que estén asociados a los dictados del curso especificado, si es que hay un curso especificado.
            List<Usuario_BE> tutoresFiltrados = todosLosTutores;

            if (curso != null)
            {
                List<Dictado_BE> dictadosDelCurso = dictadoBll.ListarDictados(curso);
                tutoresFiltrados = tutoresFiltrados.Where(tutor =>
                    dictadosDelCurso.Any(dictado => dictado.Tutores.Any(t => t.IdUsuario == tutor.IdUsuario))
                ).ToList();
            }

            // Si hay contenido en el textbox de nombre del tutor, filtrar por nombre y/o apellido.
            if (!string.IsNullOrWhiteSpace(searchName.Text))
            {
                tutoresFiltrados = tutoresFiltrados.Where(tutor =>
                    tutor.Nombre.ToLower().Contains(searchName.Text.ToLower()) ||
                    tutor.Apellido.ToLower().Contains(searchName.Text.ToLower())
                ).ToList();
            }

            //si no hay tutores, limpiar el text de tutor seleccionado
            if (tutoresFiltrados.Count == 0)
            {
                txtSelectedTutor.Text = "";
                btnSendQuery.Enabled = false;
                ViewState["tutor"] = null;
            }
            

            tutorsGrid.DataSource = tutoresFiltrados;
            tutorsGrid.DataBind();
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idTutor = Convert.ToInt32(tutorsGrid.DataKeys[rowIndex].Value);
            Usuario_BE tutor = usuariobll.ListarUsuarios().FirstOrDefault(item => item.IdUsuario == idTutor);
            // mostar usuario en usuario seleecionado
            txtSelectedTutor.Text = tutor.Nombre + " " + tutor.Apellido;
            //guardar en un viewstate el tutor
            ViewState["tutor"] = tutor;
            btnSendQuery.Enabled = true;
        }

        protected void btnSendQuery_Click(object sender, EventArgs e) {
            if (IsValid)
            {
                //enviar email al tutor que esta guardado en el viewstate con el nombre, apellido, mail y comentario del alumno usando Notificacion del projecto Servicio
                Usuario_BE tutor = (Usuario_BE)ViewState["tutor"];
                //armar un cuerpo de email con Nombre: , Apellido: , Email: , Comentario:
                string cuerpo = "Nombre: " + txtName.Text + "<br/>" + "Apellido: " + txtSurname.Text + "<br/>" + "Email: " + txtEmail.Text + "<br/>" + "Comentario: " + txtComment.Text;
                Servicio.Notificacion.EnviarEmail(cuerpo, "TECHBOTICA - Contacto estudiante", tutor.Email);
                // escribir una alerta de mensaje enviado con exito
                Response.Write("<script>alert('Mensaje enviado con exito');window.location ='ConsultarTutores.aspx';</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                LoadTutores();
            }
        }
    }
}