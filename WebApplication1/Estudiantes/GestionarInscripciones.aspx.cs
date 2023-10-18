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
    public partial class GestionarInscripciones : System.Web.UI.Page
    {
        Carrera_BLL carreraBll = new Carrera_BLL();
        Dictado_BLL dictadoBll = new Dictado_BLL();

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
                    Session["id_inscripcion_carrera"] = null;
                    Session["id_inscripcion_curso"] = null;
                    CargarInscripcionesCarrera();
                    CargarInscripcionesCurso();
                }
            }
        }

        private void CargarInscripcionesCarrera()
        {
            // Obtener el ID del usuario actual
            Usuario_BE usuario = (Usuario_BE)Session["usuario"];
            int userId = usuario.IdUsuario;

            // Obtener todas las InscripcionCarrera_BE para el usuario actual
            var inscripciones = carreraBll.ListarInscripcionesPorEstudiante(userId);

            // Obtener todas las carreras
            var carreras = carreraBll.ListarCarreras();

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
            careersGrid.DataSource = carrerasInscriptas;
            careersGrid.DataBind();
        }



        private void CargarInscripcionesCurso()
        {
            // Obtener el ID del usuario actual
            Usuario_BE usuario = (Usuario_BE)Session["usuario"];
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
                                     IdInscripcion = i.Id,
                                     Nombre = d.Curso.Nombre,
                                     FechaInscripcion = i.Fecha,
                                     FechaInicio = d.FechaInicio, // Asegurándonos de que las fechas se establezcan aquí
                                     FechaFin = d.FechaFin
                                 })
                           .OrderByDescending(c => c.FechaInicio) // Ordenando aquí por FechaInicio en orden descendente
                           .ToList();

            // Vincular los datos a la grilla
            coursesGrid.DataSource = cursosInscriptos;
            coursesGrid.DataBind();
        }


        protected void btnSearchCourse_Click(object sender, EventArgs e)
        {
            // Convertir las fechas seleccionadas en los date pickers
            DateTime fechaInicio;
            DateTime fechaFin;

            if (DateTime.TryParse(searchStartDate.Text, out fechaInicio) && DateTime.TryParse(searchEndDate.Text, out fechaFin))
            {
                // Asegurarse de que la fecha de inicio no sea posterior a la fecha de finalización
                if (fechaInicio <= fechaFin)
                {
                    // Obtener el ID del usuario actual
                    Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                    int userId = usuario.IdUsuario;

                    // Obtener todas las InscripcionCurso_BE para el usuario actual
                    var inscripciones = new Dictado_BLL().ListarInscripcionesPorEstudiante(userId);

                    // Filtrar las inscripciones basadas en las fechas seleccionadas
                    var inscripcionesFiltradas = inscripciones.Where(i => i.Fecha >= fechaInicio && i.Fecha <= fechaFin).ToList();

                    // Obtener todos los dictados y cursos
                    var dictados = new Dictado_BLL().ListarDictados();
                    var cursos = new Curso_BLL().ListarCursos();

                    // Preparar los datos para vincular, incluyendo la fecha de inscripción
                    var cursosInscriptos = dictados.Join(inscripcionesFiltradas,
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
                    coursesGrid.DataSource = cursosInscriptos;
                    coursesGrid.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Fecha de inicio no puede ser posteior a la fecha de finalizacion');</script>");
                    
                }
            }
            else
            {
                Response.Write("<script>alert('Las fechas son invalidas');</script>");
            }
        }


        protected void btnSelectCarrera_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            int idInscripcion = Convert.ToInt32(careersGrid.DataKeys[rowIndex].Value);

            Session["id_inscripcion_carrera"] = idInscripcion;

            Response.Redirect("~/Estudiantes/DetalleInscripcionCarrera.aspx");
        }

        protected void btnSelectCurso_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            int idInscripcion = Convert.ToInt32(coursesGrid.DataKeys[rowIndex].Value);

            Session["id_inscripcion_curso"] = idInscripcion;

            Response.Redirect("~/Estudiantes/DetalleInscripcionCurso.aspx");
        }

        public class CarreraInscripcionViewModel
        {
            public int Id { get; set; }
            public int IdInscripcion { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaInscripcion { get; set; }
        }

        public class CursoInscripcionViewModel
        {
            public int Id { get; set; }
            public int IdInscripcion { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaInscripcion { get; set; }
            public DateTime FechaInicio { get; set; } 
            public DateTime FechaFin { get; set; }
        }

    }
}