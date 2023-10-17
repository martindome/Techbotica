<%@ Page Title="Detalle Inscripcion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleInscripcionCurso.aspx.cs" Inherits="WebApplication1.Estudiantes.DetalleInscripcionCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Detalles del Curso</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Detalles del curso -->
                <p><strong>Nombre:</strong> <asp:Label ID="lblCourseName" runat="server" Text="Curso 1"></asp:Label></p>
                <p><strong>Especialidad:</strong> <asp:Label ID="lblCourseEspeciality" runat="server" Text="Especialidad 1"></asp:Label></p>
                <p><strong>Descripción:</strong> <asp:Label ID="lblCourseDescription" runat="server" Text="Descripcion 1"></asp:Label></p>
                <p><strong>Fecha de inicio:</strong> <asp:Label ID="lblStartDate" runat="server" Text="01/01/1996"></asp:Label></p>
                <p><strong>Fecha de fin:</strong> <asp:Label ID="lblEndDate" runat="server" Text="01/01/1996"></asp:Label></p>
                <p><strong>Horarios:</strong> <asp:Label ID="lblSchedule" runat="server" Text="Miercoles 12:00-14:00"></asp:Label></p>
                <p><strong>Tutores:</strong> <asp:Label ID="lblTutores" runat="server" Text="Miercoles 12:00-14:00"></asp:Label></p>
            
                <!-- Botones de acción -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnUnenroll" CssClass="btn btn-danger" Text="Desinscribir" runat="server" OnClientClick="return confirmDesinscription();" OnClick="btnUnenroll_Click" />

                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function confirmDesinscription() {
            var confirmValue = confirm('¿Está seguro de que desea desinscribirse de esta carrera? Esta acción no se puede deshacer.');
            return confirmValue; // Si es true, continuará con el evento OnClick del lado del servidor. Si es false, no pasará nada.
        }
    </script>

</asp:Content>