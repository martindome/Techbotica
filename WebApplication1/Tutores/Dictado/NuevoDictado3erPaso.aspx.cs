using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class NuevoDictador3erPaso : System.Web.UI.Page
    {
        List<Usuario_BE> assignedTutors;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarDictados")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["dictado_crear"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    assignedTutors = new List<Usuario_BE>();
                    Session["AssignedTutors"] = assignedTutors;
                    LoadTutors();
                }
            }
            
        }

        private void LoadTutors()
        {
            Usuario_BLL userBLL = new Usuario_BLL();
            List<Usuario_BE> allUsers = userBLL.ListarUsuarios();
            List<Usuario_BE> assignedTutors = (List<Usuario_BE>)Session["AssignedTutors"];

            // Obtener tutores que no están en la lista de tutores asignados
            List<Usuario_BE> availableTutors = allUsers.Where(u => u.Familia.familia == "Tutor" && !assignedTutors.Any(at => at.IdUsuario == u.IdUsuario)).ToList();

            TutorsGrid.DataSource = availableTutors;
            TutorsGrid.DataBind();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            List<Usuario_BE> assignedTutors = (List<Usuario_BE>)Session["AssignedTutors"];
            if (assignedTutors.Count == 0)
            {
                Response.Write("<script>alert('Ingrese al menos 1 tutor');</script>");
                return;
            }
            Dictado_BE d = ((Dictado_BE)Session["dictado_crear"]);
            d.Tutores = assignedTutors;
            new Dictado_BLL().NuevoDictado(d);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado creado correctamente');window.location.href = '/Default.aspx'", true);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void SearchTutorButton_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchTutorTextBox.Text.ToLower();
            Usuario_BLL userBLL = new Usuario_BLL();
            List<Usuario_BE> allUsers = userBLL.ListarUsuarios();
            List<Usuario_BE> tutors = allUsers.Where(u => u.Familia.familia == "Tutor" && (u.Nombre.ToLower().Contains(searchTerm) || u.Apellido.ToLower().Contains(searchTerm) || u.Email.ToLower().Contains(searchTerm))).ToList();

            TutorsGrid.DataSource = tutors;
            TutorsGrid.DataBind();
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int userId = Convert.ToInt32(TutorsGrid.DataKeys[rowIndex].Value);

            Usuario_BLL userBLL = new Usuario_BLL();
            Usuario_BE selectedTutor = userBLL.obtener_usuario(userId);

            if (Session["AssignedTutors"] == null)
            {
                assignedTutors = new List<Usuario_BE>();
            }
            else
            {
                assignedTutors = (List<Usuario_BE>)Session["AssignedTutors"];
            }

            if (!assignedTutors.Any(t => t.IdUsuario == selectedTutor.IdUsuario))
            {
                assignedTutors.Add(selectedTutor);
                Session["AssignedTutors"] = assignedTutors;
                AssignedTutorsGrid.DataSource = assignedTutors;
                AssignedTutorsGrid.DataBind();
            }
            LoadTutors();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int userId = Convert.ToInt32(AssignedTutorsGrid.DataKeys[rowIndex].Value);

            Usuario_BLL userBLL = new Usuario_BLL();
            Usuario_BE selectedTutor = userBLL.obtener_usuario(userId);

            // Aquí, podrías agregar el tutor seleccionado a una lista en la sesión o a alguna otra estructura de almacenamiento temporal.
            // Por simplicidad, lo almacenaré en una lista en la sesión.
            List<Usuario_BE> assignedTutors;
            if (Session["AssignedTutors"] == null)
            {
                assignedTutors = new List<Usuario_BE>();
            }
            else
            {
                assignedTutors = (List<Usuario_BE>)Session["AssignedTutors"];
            }

            // Encontrar y eliminar el tutor por su IdUsuario
            var tutorToRemove = assignedTutors.FirstOrDefault(t => t.IdUsuario == selectedTutor.IdUsuario);
            if (tutorToRemove != null)
            {
                assignedTutors.Remove(tutorToRemove);
                Session["AssignedTutors"] = assignedTutors;
                AssignedTutorsGrid.DataSource = assignedTutors;
                AssignedTutorsGrid.DataBind();
            }
            LoadTutors();
        }
    }
}