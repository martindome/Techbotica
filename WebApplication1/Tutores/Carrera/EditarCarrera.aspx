<%@ Page Title="Editar Carrera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCarrera.aspx.cs" Inherits="WebApplication1.Tutores.Carrera.EditarCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Editar Carrera</h2>

        <div class="form-group">
            <label for="CareerName">Nombre de la Carrera</label>
            <asp:TextBox ID="CareerName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CareerDescription">Descripción de la Carrera</label>
            <asp:TextBox ID="CareerDescription" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="row">
            <div class="col-md-6">
                <h3>Cursos Disponibles</h3>
                <asp:ListBox ID="AvailableCourses" CssClass="form-control" runat="server">
                </asp:ListBox>
                <asp:Button ID="btnAssignCourse" CssClass="btn btn-primary mt-2" Text="Asignar Curso" runat="server" />
            </div>

            <div class="col-md-6">
                <h3>Cursos Asignados</h3>
                <asp:ListBox ID="AssignedCourses" CssClass="form-control" runat="server">
                </asp:ListBox>
                <asp:Button ID="btnRemoveCourse" CssClass="btn btn-danger mt-2" Text="Desasignar Curso" runat="server" />
            </div>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnEditCareer" CssClass="btn btn-success" Text="Aplicar cambios" runat="server" OnClick="btnEditCareer_Click" />
            <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />

        </div>
    </div>
</asp:Content>
