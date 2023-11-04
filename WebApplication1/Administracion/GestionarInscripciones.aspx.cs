using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntity;
using static WebApplication1.Estudiantes.GestionarInscripciones;
using BusinessEntity.Composite;

namespace WebApplication1.Administracion
{
    public partial class GestionarInscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarInscripciones")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
        }

        protected void SearchUserButton_Click(object sender, EventArgs e)
        {
            //filter and fill user grid
            Usuario_BLL usuariobll = new Usuario_BLL();
            List<Usuario_BE> usuarios = usuariobll.ListarUsuarios();
            //filter users by name (name and surname together) and email textboxes
            usuarios = usuarios.Where(u => u.Nombre.ToLower().Contains(SearchUserByNameTextBox.Text.ToLower()) && u.Apellido.ToLower().Contains(SearchUserByNameTextBox.Text.ToLower()) && u.Email.ToLower().Contains(SearchUserByEmailTextBox.Text.ToLower())).ToList();
            UsersGrid.DataSource = usuarios;
            UsersGrid.DataBind();
            TextBoxUsuarioSeleccioado.Text = "";

        }

        protected void btnUnsubscribeCourse_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idInscripcion = Convert.ToInt32(UsersGrid.DataKeys[rowIndex].Value);

            InscripcionCurso_BE inscripcion = new Dictado_BLL().ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);
            Dictado_BLL dictadoblll = new Dictado_BLL();
            dictadoblll.EliminarInscripcion(inscripcion);
            LoadInscripcionesCursos();
            LoadInscripcionesCarreras();
        }

        protected void btnUnsubscribeCareer_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idInscripcion = Convert.ToInt32(UsersGrid.DataKeys[rowIndex].Value);

            InscripcionCarrera_BE inscripcion = new Carrera_BLL().ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);
            Carrera_BLL carrerabll = new Carrera_BLL();
            carrerabll.EliminarInscripcion(inscripcion);
            LoadInscripcionesCursos();
            LoadInscripcionesCarreras();
        }

        protected void btnSelectUser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idInscripcion = Convert.ToInt32(UsersGrid.DataKeys[rowIndex].Value);
            Usuario_BE usuario = new Usuario_BLL().ListarUsuarios().FirstOrDefault(item => item.IdUsuario == idInscripcion);
            TextBoxUsuarioSeleccioado.Text = usuario.Email;
            ViewState["usuario"] = idInscripcion;
            LoadInscripcionesCursos();
            LoadInscripcionesCarreras();

        }

        private void LoadInscripcionesCarreras()
        {
            //gert user based in the id in the viewstate
            Usuario_BLL usuariobll = new Usuario_BLL();
            Usuario_BE usuario = usuariobll.ListarUsuarios().FirstOrDefault(item => item.IdUsuario == (int)ViewState["usuario"]);

            int userId = usuario.IdUsuario;

            // Obtener todas las InscripcionCarrera_BE para el usuario actual
            var inscripciones = new Carrera_BLL().ListarInscripcionesPorEstudiante(userId);

            // Obtener todas las carreras
            var carreras = new Carrera_BLL().ListarCarreras();

            // Preparar los datos para incluir la fecha de inscripción.
            var carrerasInscriptas = carreras.Join(inscripciones,
                                                   c => c.Id,
                                                   i => i.IdCarrera,
                                                   (c, i) => new CarreraInscripcionViewModel
                                                   {
                                                       Id = c.Id,
                                                       IdInscripcion = i.Id,
                                                       Nombre = c.Nombre,
                                                       FechaInscripcion = i.Fecha
                                                   })
                                             .ToList();
            // Vincular los datos a la grilla
            UserCareersGrid.DataSource = carrerasInscriptas;
            UserCareersGrid.DataBind();
        }

        private void LoadInscripcionesCursos()
        {
            //gert user based in the id in the viewstate
            Usuario_BLL usuariobll = new Usuario_BLL();
            Usuario_BE usuario = usuariobll.ListarUsuarios().FirstOrDefault(item => item.IdUsuario == (int)ViewState["usuario"]);

            int userId = usuario.IdUsuario;

            // Obtener todas las InscripcionCurso_BE para el usuario actual
            var inscripciones = new Dictado_BLL().ListarInscripcionesPorEstudiante(userId);

            // Obtener todos los dictados y cursos
            var dictados = new Dictado_BLL().ListarDictados();
            var cursos = new Curso_BLL().ListarCursos();

            // Preparar los datos para vincular, incluyendo la fecha de inscripción
            var cursosInscriptos = dictados.Join(inscripciones,
                                         d => d.Id,
                                         i => i.IdDictado,
                                         (d, i) => new CursoInscripcionViewModel
                                         {
                                             Id = d.Curso.Id, // o d.Id dependiendo de cómo esté estructurado tu Dictado_BE
                                             Nombre = d.Curso.Nombre,
                                             IdInscripcion = i.Id,
                                             FechaInscripcion = i.Fecha,
                                             FechaInicio = d.FechaInicio, // Asegurándonos de que las fechas se establezcan aquí
                                             FechaFin = d.FechaFin
                                         })
                                   .ToList();

            // Vincular los datos filtrados a la grilla
            UserCoursesGrid.DataSource = cursosInscriptos;
            UserCoursesGrid.DataBind();
        }
    }
}