<%@ Page Title="Nueva Carrera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaCarrera.aspx.cs" Inherits="WebApplication1.Tutores.Carrera.NuevaCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Nueva Carrera</h2>

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
                <asp:Button ID="btnAssignCourse" CssClass="btn btn-primary mt-2" Text="Asignar Curso" runat="server" OnClick="btnAssignCourse_Click" CausesValidation="false" />
            </div>

            <div class="col-md-6">
                <h3>Cursos Asignados</h3>
                <asp:ListBox ID="AssignedCourses" CssClass="form-control" runat="server">
                </asp:ListBox>
                <asp:Button ID="btnRemoveCourse" CssClass="btn btn-danger mt-2" Text="Desasignar Curso" runat="server" OnClick="btnRemoveCourse_Click" CausesValidation="false" />
            </div>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnCreateCareer" CssClass="btn btn-success" Text="Crear Carrera" runat="server" OnClick="btnCreateCareer_Click" />
            <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBack_Click" CausesValidation="false" />
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="CareerName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="CareerName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" Display="None" runat="server" ControlToValidate="CareerDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripcion para continuar"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescripcion" Display="None" runat="server" ControlToValidate="CareerDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripcion valida" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
    </div>
</asp:Content>

