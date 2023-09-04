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
    public partial class EditarHorarios : System.Web.UI.Page
    {
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
                if (Session["id_dictado_editar"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado inexistente');window.location.href = '/Default.aspx'", true);
                }
                if (!IsPostBack)
                {
                    dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_editar"].ToString()));
                    ViewState["dictado"] = dictado;
                    // Si hay un dictado disponible, establece los valores
                    if (dictado != null)
                    {
                        CargarHorarios();

                    }
                    if (Session["HorariosList"] == null)
                    {
                        Session["HorariosList"] = new List<Horario_BE>();
                    }
                }
            }
            
        }

        private void CargarHorarios()
        {
            dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_editar"].ToString()));
            ViewState["dictado"] = dictado;
            // Asumiendo que dictado.Horarios es la lista de horarios
            HorariosGridView.DataSource = dictado.Horarios;
            HorariosGridView.DataBind();
            Session["HorariosList"] = dictado.Horarios;
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/EditarDictado.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            dictado = (Dictado_BE)ViewState["dictado"];
            if (HorariosGridView.Rows.Count == 1)
            {
                Response.Write("<script>alert('Debe haber por lo menos 1 horario.');</script>");
                return;
            }
            Button btn = (Button)sender;
            int rowIndex = int.Parse(btn.CommandArgument); // Obtener el índice de la fila del GridView

            Horario_BE horarioaeliminar = dictado.Horarios[rowIndex];
            dictado_BLL.EliminarHorario(horarioaeliminar);

            // Actualizar la base de datos aquí si es necesario

            // Refrescar el GridView
            CargarHorarios();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Horario_BE nuevoHorario = new Horario_BE();
                nuevoHorario.Dia = DayDropDownList.SelectedValue;
                nuevoHorario.HoraInicio = TimeSpan.Parse(StartTimeTextBox.Text);
                nuevoHorario.HoraFin = TimeSpan.Parse(EndTimeTextBox.Text);
                nuevoHorario.Dictado = (Dictado_BE)ViewState["dictado"];

                TimeSpan horaInicio = TimeSpan.Parse(StartTimeTextBox.Text);
                TimeSpan horaFin = TimeSpan.Parse(EndTimeTextBox.Text);

                // Comprobación para asegurarse de que la hora de inicio es anterior a la hora de fin
                if (horaInicio >= horaFin)
                {
                    Response.Write("<script>alert('La hora de inicio debe ser anterior a la hora de fin');</script>");
                    return; // Finalizar la ejecución del método aquí
                }

                List<Horario_BE> horarios = (List<Horario_BE>)Session["HorariosList"];

                // Verificar si ya existe un horario idéntico
                bool existeHorarioIdentico = horarios.Any(h => h.Dia == nuevoHorario.Dia && h.HoraInicio == nuevoHorario.HoraInicio && h.HoraFin == nuevoHorario.HoraFin);
                if (existeHorarioIdentico)
                {
                    Response.Write("<script>alert('Ya existe un horario con el mismo día, hora de inicio y hora de fin');</script>");
                    return;
                }

                dictado_BLL.NuevoHorario(nuevoHorario);

                // Actualizar la base de datos aquí si es necesario

                // Refrescar el GridView
                CargarHorarios();
            }
            catch
            {
                Response.Write("<script>alert('Por favor, ingrese horarios correctos');</script>");
                return;
            }
        }
    }
}