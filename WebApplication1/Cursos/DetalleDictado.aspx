<%@ Page Title="Dictado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleDictado.aspx.cs" Inherits="WebApplication1.Cursos.DetalleDictado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Detalles del Curso</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Detalles del curso -->
                <p><strong>Nombre:</strong> <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label></p>
                <p><strong>Descripción:</strong> <asp:Label ID="lblCourseDescription" runat="server" Text=""></asp:Label></p>
                <p><strong>Fecha de inicio:</strong> <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label></p>
                <p><strong>Fecha de fin:</strong> <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label></p>
                <p><strong>Cupos disponibles:</strong> <asp:Label ID="lblAvailableSpots" runat="server" Text=""></asp:Label></p>
                <p><strong>Tutores:</strong> <asp:Label ID="lblTutors" runat="server" Text=""></asp:Label></p>
                <p><strong>Horarios:</strong> <asp:Label ID="lblSchedule" runat="server" Text=""></asp:Label></p>

                <!-- Botones de acción -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnEnroll" CssClass="btn btn-primary" Text="Inscribirse" runat="server" OnClick="btnInscribir_Click" />
                    
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>