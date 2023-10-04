using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Carreras
{
    public partial class DetalleCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["numero_inscripcion_carrera"] = null;
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Inscripciones")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (Session["id_carrera_inscribir"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Carrera inexistente');window.location.href = '/Default.aspx'", true);
                }
                if (!IsPostBack)
                {
                    Session["numero_inscripcion_carrera"] = null;
                    Carrera_BLL carreraBLL = new Carrera_BLL();
                    int id_carrera = int.Parse(Session["id_carrera_inscribir"].ToString());
                    Carrera_BE carrera = carreraBLL.ListarCarreras().SingleOrDefault(c => c.Id == id_carrera);

                    if (carrera != null)
                    {
                        CargarDatosCarrera(carrera);
                    }
                }
            }
        }

        private void CargarDatosCarrera(Carrera_BE carrera)
        {
            // Cargando y mostrando la información básica de la carrera
            nombreCarrera.Text = carrera.Nombre ?? "No disponible";
            descripcionCarrera.Text = carrera.Descripcion ?? "No disponible";

            if (carrera.Cursos != null && carrera.Cursos.Count > 0)
            {
                cursosCarrera.DataSource = carrera.Cursos;
                cursosCarrera.DataBind();
            }
        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            // Obteniendo el usuario actual
            Usuario_BE usuario = (Usuario_BE)Session["usuario"];
            if (usuario != null)
            {
                // Obteniendo la información de la carrera desde la variable de sesión

                int id_carrera_inscribir = int.Parse(Session["id_carrera_inscribir"].ToString());

                //if (id_carrera_inscribir)
                //{
                    Carrera_BLL carreraBLL = new Carrera_BLL();

                    InscripcionCarrera_BE nuevaInscripcion = carreraBLL.NuevaInscripcion(usuario.IdUsuario, id_carrera_inscribir);

                    if (nuevaInscripcion != null)
                    {
                        // Suponiendo que quieras guardar el ID de la inscripción en la sesión
                        Session["numero_inscripcion_carrera"] = nuevaInscripcion.Id;
                        Response.Redirect("~/Carreras/ConfirmacionInscripcionCarrera.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error en la inscripcion.');</script>");
                    }
                //}
                //else
                //{
                //    Response.Write("<script>alert('Error en la inscripcion');</script>");
                //}
            }
            else
            {
                Response.Write("<script>alert('Error en la inscripcion');</script>");
            }
        }

    }
}