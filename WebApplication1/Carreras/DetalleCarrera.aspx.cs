using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Carreras
{
    public partial class DetalleCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer los valores para los detalles de la carrera
                nombreCarrera.Text = "Ciencias de la Computación";
                descripcionCarrera.Text = "Esta carrera proporciona un profundo entendimiento de los conceptos y prácticas fundamentales en torno a la computación y sus aplicaciones.";

                // Generar lista de cursos
                List<Course> cursos = new List<Course>()
        {
            new Course() { Nombre = "Programación 101", Especialidad = "Programación" },
            new Course() { Nombre = "Algoritmos y Estructuras de Datos", Especialidad = "Computación" },
            new Course() { Nombre = "Diseño de Sistemas", Especialidad = "Sistemas" },
            new Course() { Nombre = "Matemáticas para Computación", Especialidad = "Matemáticas" }
        };

                // Asignar la lista de cursos al GridView
                cursosCarrera.DataSource = cursos;
                cursosCarrera.DataBind();
            }
        }

        public class Course
        {
            public string Nombre { get; set; }
            public string Especialidad { get; set; }
        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Carreras/ConfirmacionInscripcionCarrera.aspx");
        }
    }
}