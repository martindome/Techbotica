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

namespace WebApplication1.Estudiantes.Cursadas
{
    public partial class Cursada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Dictados")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    Session["material_view"] = null;
                    Session["actividad_view"] = null;
                    if (Session["id_dictado_ver"] == null)
                    {
                        Response.Write("<script>alert('No se encuentra el dictado');window.location.href = '/Default.aspx';</script>");
                    }
                    int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
                    //obtener dictado
                    Dictado_BLL dictadobll = new Dictado_BLL();
                    Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
                    ViewState["dictado"] = dictado;
                    string linkText = "Enlace a videollamada";
                    courseLinkLabel.Text = "Aula: <a href='" + dictado.Enlace + "' target='_blank'>" + linkText + "</a>";
                    CargarMateriales();
                    CargarActividades();


                }
            }
        }

        private void CargarMateriales()
        {
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            //obtener dictado
            Dictado_BLL dictadobll = new Dictado_BLL();
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);

            List<Material_BE> materiales = dictadobll.ListarMaterialesDictado(dictado);
            materialsGrid.DataSource = materiales;
            materialsGrid.DataBind();
        }

        private void CargarActividades()
        {
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            //obtener dictado
            Dictado_BLL dictadobll = new Dictado_BLL();
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);

            List<Actividad_BE> materiales = dictadobll.ListarActividadesDictado(dictado);
            activitiesGrid.DataSource = materiales;
            activitiesGrid.DataBind();
        }

        protected void btnViewMaterial_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idMaterial = Convert.ToInt32(materialsGrid.DataKeys[rowIndex].Value);
            Session["material_view"] = idMaterial;
            Response.Redirect("~/Estudiantes/MisCursadas/VerMaterial.aspx");
        }

        protected void btnViewActivity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idActividad = Convert.ToInt32(activitiesGrid.DataKeys[rowIndex].Value);
            Session["actividad_view"] = idActividad;
            Response.Redirect("~/Estudiantes/MisCursadas/VerActividad.aspx");
        }

    }
}