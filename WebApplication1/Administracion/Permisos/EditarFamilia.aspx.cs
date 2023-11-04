using BusinessEntity.Composite;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace WebApplication1.Administracion.Permisos
{
    public partial class EditarFamilia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarPermisos")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }

            if (!IsPostBack)
            {
                CargarPatentes();
                CargarPatentesAsignadas();
            }
        }

        private void CargarPatentes()
        {
            int idfamilia = int.Parse(Session["familia_editar"].ToString());
            //get all families
            List<Patente_BE> patentes = new Permisos_BLL().ListarPatentes();
            //get family to edit
            Familia_BE familia = new Permisos_BLL().ListarFamilias().FirstOrDefault(f => f.id == idfamilia);
            // filter patntes with family's patentes
            //List<Patente_BE> patentesNoFamilia = patentes.Where(p => familia.listaPatentes.Any(p2 => ((Patente_BE)p2).id != p.id)).ToList();
            List<Patente_BE> patentesNoFamilia = new List<Patente_BE>();
            foreach (Patente_BE patente in patentes)
            {
                if (!familia.listaPatentes.Any(p2 => ((Patente_BE)p2).id == patente.id))
                    patentesNoFamilia.Add(patente);
            }
            patentesGrid.DataSource = patentesNoFamilia;
            patentesGrid.DataBind();
                

        }

        private void CargarPatentesAsignadas()
        {
            int idfamilia = int.Parse(Session["familia_editar"].ToString());
            //get all families
            List<Patente_BE> patentes = new Permisos_BLL().ListarPatentes();
            //get family to edit
            Familia_BE familia = new Permisos_BLL().ListarFamilias().FirstOrDefault(f => f.id == idfamilia);
            // filter patntes with family's patentes
            List<Patente_BE> patentesFamilia = patentes.Where(p => familia.listaPatentes.Any(p2 => ((Patente_BE)p2).id == p.id)).ToList();
            AssignedPatentesGrid.DataSource = patentesFamilia;
            AssignedPatentesGrid.DataBind();
        }



        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int idfamilia = int.Parse(Session["familia_editar"].ToString());
            if (idfamilia == 1)
            {
                Response.Write("<script>alert('No se puede editar la familia Web Master');</script>");
                return;
            }
            else if (idfamilia == 2)
            {
                Response.Write("<script>alert('No se puede editar la familia Estudainte');</script>");
                return;
            }
            else if (idfamilia == 3)
            {
                Response.Write("<script>alert('No se puede editar la familia Tutor');</script>");
                return;
            }
            else if (idfamilia == 4)
            {
                Response.Write("<script>alert('No se puede editar la familia Administrador');</script>");
                return;
            }


            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int patenteId = Convert.ToInt32(AssignedPatentesGrid.DataKeys[rowIndex].Value);

            //get the patente based on patente id
            Patente_BE patente = new Permisos_BLL().ListarPatentes().FirstOrDefault(p => p.id == patenteId);

            new Permisos_BLL().BorrarPatenteFamilia(int.Parse(Session["familia_editar"].ToString()), patenteId);
            CargarPatentes();
            CargarPatentesAsignadas();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int idfamilia = int.Parse(Session["familia_editar"].ToString());
            if (idfamilia == 1)
            {
                Response.Write("<script>alert('No se puede editar la familia Web Master');</script>");
                return;
            }
            else if (idfamilia == 2)
            {
                Response.Write("<script>alert('No se puede editar la familia Estudainte');</script>");
                return;
            }
            else if (idfamilia == 3)
            {
                Response.Write("<script>alert('No se puede editar la familia Tutor');</script>");
                return;
            }
            else if (idfamilia == 4)
            {
                Response.Write("<script>alert('No se puede editar la familia Administrador');</script>");
                return;
            }

            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int patenteId = Convert.ToInt32(patentesGrid.DataKeys[rowIndex].Value);

            //get the patente based on patente id
            Patente_BE patente = new Permisos_BLL().ListarPatentes().FirstOrDefault(p => p.id == patenteId);

            new Permisos_BLL().AgregarPatenteFamilia(int.Parse(Session["familia_editar"].ToString()), patenteId);
            CargarPatentes();
            CargarPatentesAsignadas();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarPermisos.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarPermisos.aspx");
        }
    }
}