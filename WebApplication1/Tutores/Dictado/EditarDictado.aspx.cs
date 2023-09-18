using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class EditarDictado : System.Web.UI.Page
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
                    ViewState["dictado"] = new Dictado_BE();
                    dictado = dictado_BLL.ListarDictados().SingleOrDefault(d => d.Id == int.Parse(Session["id_dictado_editar"].ToString()));
                    ViewState["dictado"] = dictado;
                    // Si hay un dictado disponible, establece los valores
                    if (dictado != null)
                    {
                        // Establecer la fecha de inicio, fecha fin, enlace y cupo
                        StartDateTextBox.Text = dictado.FechaInicio.ToString("dd/MM/yyyy");
                        EndDateTextBox.Text = dictado.FechaFin.ToString("dd/MM/yyyy");
                        LinkTextBox.Text = dictado.Enlace;
                        TextBoxcupo.Text = dictado.Cupo.ToString();
                        if (dictado.TipoDictado == "Autodirigido")
                        {
                            ButtonEditarHorarios.Visible = false;
                        }
                    }
                }

            }
            
        }

        protected void UpdateDictationButton_Click(object sender, EventArgs e)
        {
            // Obtener la instancia del dictado actual de la sesión
            Dictado_BE dictadoActual = (Dictado_BE)ViewState["dictado"];

            if (dictadoActual == null)
            {
                // Mostrar un mensaje de error si no hay dictado en la sesión
                Response.Write("<script>alert('Error: No hay un dictado para editar.');</script>");
                return;
            }

            // Capturar y guardar los valores introducidos por el usuario
            dictadoActual.Enlace = LinkTextBox.Text.Trim();

            DateTime startDate;
            DateTime endDate;

            if (!DateTime.TryParseExact(StartDateTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate) ||
               !DateTime.TryParseExact(EndDateTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                // Mostrar un mensaje de error si no se pueden convertir las fechas
                Response.Write("<script>alert('Por favor, introduce fechas válidas en los campos correspondientes.');</script>");
                return;
            }

            if (endDate < startDate)
            {
                // Mostrar un mensaje de error si la fecha de fin es anterior a la fecha de inicio
                Response.Write("<script>alert('La fecha de fin no puede ser anterior a la fecha de inicio.');</script>");
                return;
            }

            dictadoActual.FechaInicio = startDate;
            dictadoActual.FechaFin = endDate;

            int cupo;
            if (int.TryParse(TextBoxcupo.Text.Trim(), out cupo))
            {
                dictadoActual.Cupo = cupo;
            }
            else
            {
                Response.Write("<script>alert('Por favor, introduce un número válido para el cupo.');</script>");
                return;
            }

            // En este punto, puedes llamar a tu lógica BLL/DAL para actualizar el dictado en la base de datos, por ejemplo:
            Dictado_BLL dictadoBLL = new Dictado_BLL();
            dictadoBLL.ActualizarDictado(dictadoActual);

            // Redireccionar al usuario de vuelta a GestionDictados.aspx
            Response.Redirect("~/Tutores/GestionDictados.aspx");
        }

        protected void DeleteDictationButton_Click(object sender, EventArgs e)
        {
            new Dictado_BLL().EliminarDictado((Dictado_BE)ViewState["dictado"]);
            Session["id_dictado_editar"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dictado eliminado');window.location.href = '/Tutores/GestionDictados.aspx'", true);
        }

        protected void ButtonEditarHorarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/EditarHorarios.aspx");
        }

        protected void ButtonEditarTutores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/EditarTutores.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionDictados.aspx");
        }
    }
}