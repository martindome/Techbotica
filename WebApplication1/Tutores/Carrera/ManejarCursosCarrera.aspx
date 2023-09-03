<%@ Page Title="Manejar Cursos de Carrera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManejarCursosCarrera.aspx.cs" Inherits="WebApplication1.Tutores.Carrera.ManejarCursosCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-4">Cursos de la carrera</h2>
    <div class="row">
        <div class="col-md-6">
            <h3>Cursos Disponibles</h3>
            <asp:ListBox ID="AvailableCourses" CssClass="form-control" Height="400" runat="server">
            </asp:ListBox>
            <asp:Button ID="btnAssignCourse" CssClass="btn btn-primary mt-2" Text="Asignar Curso" runat="server" OnClick="btnAssignCourse_Click" CausesValidation="false" />
        </div>

        <div class="col-md-6">
            <h3>Cursos Asignados</h3>
            <asp:ListBox ID="AssignedCourses" CssClass="form-control" Height="400" runat="server">
            </asp:ListBox>
            <asp:Button ID="btnRemoveCourse" CssClass="btn btn-danger mt-2" Text="Desasignar Curso" runat="server" OnClick="btnRemoveCourse_Click" CausesValidation="false"/>
        </div>
        <div>
            <br />
            <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBack_Click" CausesValidation="false" />
        </div>
        
    </div>
</asp:Content>
