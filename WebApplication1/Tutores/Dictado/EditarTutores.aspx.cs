using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Tutores.MisDictados;

namespace WebApplication1.Tutores.Dictado
{
    public partial class EditarTutores : System.Web.UI.Page
    {
        List<Usuario_BE> assignedTutors;
        List<Usuario_BE> availableTutors;
        Dictado_BE dictado;
        Dictado_BLL dictado_BLL = new Dictado_BLL();
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
                    if (Session["id_dictado_editar"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_editar"].ToString()));
                    ViewState["dictado"] = dictado;
                    // Si hay un dictado disponible, establece los valores
                    if (dictado != null)
                    {
                        assignedTutors = new List<Usuario_BE>();
                        availableTutors = new List<Usuario_BE>();
                        Session["AssignedTutors"] = assignedTutors;
                        Session["AvailableTutors"] = availableTutors;
                        LoadTutors();
                    }

                }
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/EditarDictado.aspx");
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

            if (AssignedTutorsGrid.Rows.Count == 1)
            {
                Response.Write("<script>alert('Debe haber por lo menos 1 tutor.');</script>");
                return;
            }

            dictado = (Dictado_BE)ViewState["dictado"];

            // Encontrar y eliminar el tutor por su IdUsuario
            dictado_BLL.EliminarDictadoUsuario(dictado, selectedTutor);
            LoadTutors();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int userId = Convert.ToInt32(TutorsGrid.DataKeys[rowIndex].Value);

            Usuario_BLL userBLL = new Usuario_BLL();
            Usuario_BE selectedTutor = userBLL.obtener_usuario(userId);

            dictado = (Dictado_BE)ViewState["dictado"];

            // Comprobar solapamiento de horarios
           

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
            dictado_BLL.AgregarDictadoUsuario(dictado, selectedTutor);
            LoadTutors();
        }

        protected void SearchTutorButton_Click(object sender, EventArgs e)
        {
            //string searchTerm = SearchTutorTextBox.Text.ToLower();
            //Usuario_BLL userBLL = new Usuario_BLL();
            //List<Usuario_BE> allUsers = userBLL.ListarUsuarios();
            //List<Usuario_BE> tutors = allUsers.Where(u => u.Familia.familia == "Tutor" && (u.Nombre.ToLower().Contains(searchTerm) || u.Apellido.ToLower().Contains(searchTerm) || u.Email.ToLower().Contains(searchTerm))).ToList();

            //TutorsGrid.DataSource = tutors;
            //TutorsGrid.DataBind();

            LoadTutors();
        }

        private void LoadTutors()
        {
            string searchTerm = SearchTutorTextBox.Text.ToLower();
            Usuario_BLL userBLL = new Usuario_BLL();
            List<Usuario_BE> allUsers = userBLL.ListarUsuarios();

            dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_editar"].ToString()));
            ViewState["dictado"] = dictado;
            Session["AssignedTutors"] = dictado.Tutores;
            List<Usuario_BE> assignedTutors = (List<Usuario_BE>)Session["AssignedTutors"];

            // Obtener tutores que no están en la lista de tutores asignados
            List<Usuario_BE> allAvailableTutors = allUsers.Where(u => u.Familia.familia == "Tutor" && (u.Nombre.ToLower().Contains(searchTerm) || u.Apellido.ToLower().Contains(searchTerm) || u.Email.ToLower().Contains(searchTerm)) && !assignedTutors.Any(at => at.IdUsuario == u.IdUsuario)).ToList();
            List<Usuario_BE> availableTutors = new List<Usuario_BE>();

            foreach (Usuario_BE Tutor in allAvailableTutors) {
                if(!assignedTutors.Any(t => t.IdUsuario == Tutor.IdUsuario)){
                    availableTutors.Add(Tutor);
                }
            }

            AssignedTutorsGrid.DataSource = dictado.Tutores;
            AssignedTutorsGrid.DataBind();

            TutorsGrid.DataSource = allAvailableTutors;
            TutorsGrid.DataBind();
        }
    }
}