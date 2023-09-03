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


        <div class="form-group mt-4">
            <asp:Button ID="btnEditCareer" CssClass="btn btn-success" Text="Aplicar cambios" runat="server" OnClick="btnEditCareer_Click" />
            <asp:Button ID="ButtonEditCourses" CssClass="btn btn-primary ml-2" Text="Editar Cursos" runat="server" OnClick="ButtonEditCourses_Click" CausesValidation="false"/>
            <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBack_Click" CausesValidation="false" />
        </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="CareerName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="CareerName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^(?=.*[a-zA-Z0-9\-])[a-zA-Z0-9\- ]{1,50}$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" Display="None" runat="server" ControlToValidate="CareerDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripcion para continuar"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescripcion" Display="None" runat="server" ControlToValidate="CareerDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripcion valida" ValidationExpression="^(?=.*[a-zA-Z0-9\-])[a-zA-Z0-9\- ]{1,50}$"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
    </div>
</asp:Content>
