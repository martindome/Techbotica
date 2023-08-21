<%@ Page Title="Editar Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCurso.aspx.cs" Inherits="WebApplication1.Tutores.Curso.EditarCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Editar Curso</h2>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" AssociatedControlID="CourseName" CssClass="form-label">Nombre del Curso:</asp:Label>
                <asp:TextBox ID="CourseName" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="CourseDescription" CssClass="form-label">Descripción del Curso:</asp:Label>
                <asp:TextBox ID="CourseDescription" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="CourseSpeciality" CssClass="form-label">Especialidad:</asp:Label>
                <asp:DropDownList ID="CourseSpeciality" runat="server" CssClass="form-control"></asp:DropDownList>

                <div>
                <h4>Carreras</h4>
                <div class="input-group mb-3">
                    <asp:TextBox ID="SearchTutorTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button class="btn btn-primary" type="button" ID="SearchTutorButton" Text="Buscar" runat="server" />
                </div>

                <asp:ListBox ID="AvailableTutorsList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-secondary mb-3" type="button" ID="AddTutorButton" Text="Asignar Carrera" runat="server" />

                <h4>Carreras Asignadas</h4>
                <asp:ListBox ID="AssignedTutorsList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-danger mb-3" type="button" ID="RemoveTutorButton" Text="Desasignar Carrera " runat="server" />
            </div>
                <asp:Button class="btn btn-primary" type="button" ID="Button2" Text="Actualizar" runat="server" OnClick="Button2_Click"/>
                 <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />

            </div>

    </div>
    </div>
</asp:Content>



