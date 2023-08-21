<%@ Page Title="Detalle Inscripcion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleInscripcionCarrera.aspx.cs" Inherits="WebApplication1.Estudiantes.DetalleInscripcionCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Detalles de la Carrera</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Detalles de la carrera -->
                <p><strong>Nombre:</strong> <asp:Label ID="lblCarreraName" runat="server" Text="Carrera 1"></asp:Label></p>
                <p><strong>Descripción:</strong> <asp:Label ID="lblCarreraDescription" runat="server" Text="Descripcion 1"></asp:Label></p>

                <h3 class="mt-4">Cursos contenidos</h3>
                <!-- Lista de cursos -->
                <asp:GridView ID="coursesGrid" CssClass="table" runat="server">
                    <Columns>
                        <asp:ButtonField Text="Ver Detalles" CommandName="Select" />
                    </Columns>
                </asp:GridView>

                <!-- Botones de acción -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnUnenroll" CssClass="btn btn-danger" Text="Desinscribir" runat="server" OnClick="btnUnenroll_Click" />
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
