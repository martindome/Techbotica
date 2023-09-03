using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Carrera
{
    public partial class EditarCarrera : System.Web.UI.Page
    {
        Carrera_BLL mappercarrera = new Carrera_BLL();
        Carrera_BE carrerabe;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCarreras")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["id_carrera_editar"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Carrera inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    carrerabe = (Carrera_BE)mappercarrera.ListarCarreras().FirstOrDefault(item => item.Id == int.Parse(Session["id_carrera_editar"].ToString()));
                    ViewState["carrerabe"] = carrerabe;
                    CareerName.Text = carrerabe.Nombre.ToString();
                    CareerDescription.Text = carrerabe.Descripcion.ToString();
                }
            }
            
        }

        protected void btnEditCareer_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                carrerabe = (Carrera_BE)ViewState["carrerabe"];
                Session["id_carrera_editar"] = null;
                carrerabe.Nombre = CareerName.Text;
                carrerabe.Descripcion = CareerDescription.Text;
                mappercarrera.ActualizarCarrera(carrerabe);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empresa editada con exito');window.location.href = '/Tutores/GestionCarreras.aspx'", true);
            }
        }

        protected void ButtonEditCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Carrera/ManejarCursosCarrera.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id_carrera_editar"] = null;
            Response.Redirect("~/Tutores/GestionCarreras.aspx");
        }
    }
}