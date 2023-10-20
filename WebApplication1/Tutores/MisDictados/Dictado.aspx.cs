using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;

namespace WebApplication1.Tutores.MisDictados
{
    public partial class Dictado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/MisDictados")))
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
            Response.Redirect("~/Tutores/MisDictados/Material/VerMaterial.aspx");
        }

        protected void btnEditMaterial_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idMaterial = Convert.ToInt32(materialsGrid.DataKeys[rowIndex].Value);
            Session["material_view"] = idMaterial;
            Response.Redirect("~/Tutores/MisDictados/Material/EditarMaterial.aspx");
        }

        protected void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idMaterial = Convert.ToInt32(materialsGrid.DataKeys[rowIndex].Value);
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            //obtener dictado
            Dictado_BLL dictadobll = new Dictado_BLL();
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
            Material_BE material = dictadobll.ListarMaterialesDictado(dictado).FirstOrDefault(item => item.Id == int.Parse(idMaterial.ToString()));
            dictadobll.EliminarMaterial(material);
            CargarMateriales();
        }

        protected void btnViewActivity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idActividad = Convert.ToInt32(activitiesGrid.DataKeys[rowIndex].Value);
            Session["actividad_view"] = idActividad;
            Response.Redirect("~/Tutores/MisDictados/Actividad/VerActividad.aspx");
        }

        protected void btnEditActivity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idActividad = Convert.ToInt32(activitiesGrid.DataKeys[rowIndex].Value);
            Session["actividad_view"] = idActividad;
            Response.Redirect("~/Tutores/MisDictados/Actividad/EditarActividad.aspx");
        }

        protected void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idActividad = Convert.ToInt32(activitiesGrid.DataKeys[rowIndex].Value);
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            //obtener dictado
            Dictado_BLL dictadobll = new Dictado_BLL();
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
            Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == int.Parse(idActividad.ToString()));
            dictadobll.EliminarActividad(actividad);
            CargarActividades();
        }

        protected void btnViewDeliveries_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/Entrega/Entregas.aspx");
        }

        protected void btnNewMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Material/NuevoMaterial.aspx");
        }

        protected void btnNewActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/NuevaActividad.aspx");
        }
    }
}