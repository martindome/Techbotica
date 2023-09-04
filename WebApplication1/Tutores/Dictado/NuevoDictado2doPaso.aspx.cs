using BusinessEntity;
using BusinessEntity.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class NuevoDictado2doPaso : System.Web.UI.Page
    {
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
                    if (Session["HorariosList"] == null)
                    {
                        Session["HorariosList"] = new List<Horario_BE>();
                    }
                    BindGridView();
                }
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan horaInicio = TimeSpan.Parse(StartTimeTextBox.Text);
                TimeSpan horaFin = TimeSpan.Parse(EndTimeTextBox.Text);

                // Comprobación para asegurarse de que la hora de inicio es anterior a la hora de fin
                if (horaInicio >= horaFin)
                {
                    Response.Write("<script>alert('La hora de inicio debe ser anterior a la hora de fin');</script>");
                    return; // Finalizar la ejecución del método aquí
                }

                Horario_BE horario = new Horario_BE
                {
                    Dia = DayDropDownList.SelectedValue,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin,
                };
                horario.Dictado = ((Dictado_BE)Session["dictado_crear"]);

                List<Horario_BE> horarios = (List<Horario_BE>)Session["HorariosList"];

                // Verificar si ya existe un horario idéntico
                bool existeHorarioIdentico = horarios.Any(h => h.Dia == horario.Dia && h.HoraInicio == horario.HoraInicio && h.HoraFin == horario.HoraFin);
                if (existeHorarioIdentico)
                {
                    Response.Write("<script>alert('Ya existe un horario con el mismo día, hora de inicio y hora de fin');</script>");
                    return;
                }

                horarios.Add(horario);
                BindGridView();
            }
            catch
            {
                Response.Write("<script>alert('Por favor, ingrese horarios correctos');</script>");
                return;
            }
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            Dictado_BE dictado = (Dictado_BE)Session["dictado_crear"];
            dictado.Horarios = (List<Horario_BE>)Session["HorariosList"];
            if (dictado.Horarios.Count == 0)
            {
                Response.Write("<script>alert('Ingrese al menos 1 horario.');</script>");
                return;
            }
            // Aquí puedes guardar en la base de datos o hacer lo que necesites con dictado
            Response.Redirect("~/Tutores/Dictado/NuevoDictado3erPaso.aspx");
        }

        private void BindGridView()
        {
            HorariosGridView.DataSource = Session["HorariosList"];
            HorariosGridView.DataBind();
        }

        // Manejo del evento de eliminación en el GridView (necesitarás configurar esto)
        protected void HorariosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Horario_BE> horarios = (List<Horario_BE>)Session["HorariosList"];
            horarios.RemoveAt(e.RowIndex);
            BindGridView();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obtener la lista de horarios de la sesión y eliminar el horario en el índice especificado
            List<Horario_BE> horarios = (List<Horario_BE>)Session["HorariosList"];
            horarios.RemoveAt(rowIndex);

            // Volver a enlazar los datos al GridView
            BindGridView();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/NuevoDictado1erPaso.aspx");
        }
    }
}