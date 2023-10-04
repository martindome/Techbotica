using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Cursos
{
    public partial class ConfirmacionInscripcionCurso : System.Web.UI.Page
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
                if (Session["numero_inscripcion_curso"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado inexistente');window.location.href = '/Default.aspx'", true);
                }
                if (!IsPostBack)
                {

                    lblInscriptionNumber.Text = int.Parse(Session["numero_inscripcion_curso"].ToString()).ToString();
                    Session["numero_inscripcion_curso"] = null;
                    Session["id_curso_inscribir"] = null;
                    Session["id_dictado_inscribir"] = null;
                }
            }

        }
        protected void btnCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos/BuscarCursos.aspx");
        }

        protected void btnInscripciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/GestionarInscripciones");
        }
    }
}