<%@ Page Title="Detalle Empresa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleEmpresa.aspx.cs" Inherits="WebApplication1.Administracion.Empresas.DetalleEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Editar Empresa</h2>

        <div class="form-group">
            <label for="CompanyName">Nombre de la Empresa</label>
            <asp:TextBox ID="CompanyName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyDesc">Descripción de la Empresa</label>
            <asp:TextBox ID="CompanyDesc" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyEmail">Email de la Empresa</label>
            <asp:TextBox ID="CompanyEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyPhone">Teléfono de la Empresa</label>
            <asp:TextBox ID="CompanyPhone" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnEditCompany" CssClass="btn btn-success" Text="Aplicar cambios" runat="server" OnClick="btnEditCompany_Click" />
            <asp:Button ID="btnEditDomains" CssClass="btn btn-primary ml-2" Text="Editar Dominios" runat="server" OnClick="btnEditDomains_Click" />
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="CompanyName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="CompanyName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" Display="None" runat="server" ControlToValidate="CompanyDesc" CssClass="text-danger" ErrorMessage="Debe ingresar una descripcion para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescripcion" Display="None" runat="server" ControlToValidate="CompanyDesc" CssClass="text-danger" ErrorMessage="Debe ingresar una descripcion valida" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" Display="None" runat="server" ControlToValidate="CompanyPhone" CssClass="text-danger" ErrorMessage="Debe ingresar un telefono para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefono" Display="None" runat="server" ControlToValidate="CompanyPhone" CssClass="text-danger" ErrorMessage="Debe ingresar un telefono valido" ValidationExpression="^[\d-]{7,15}$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" Display="None" runat="server" ControlToValidate="CompanyEmail" CssClass="text-danger" ErrorMessage="Debe ingresar un telefono para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" Display="None" runat="server" ControlToValidate="CompanyEmail" CssClass="text-danger" ErrorMessage="Debe ingresar un telefono valido" ValidationExpression="^[a-zA-Z0-9+_.-]{1,50}@[a-zA-Z0-9.-]{1,49}$"></asp:RegularExpressionValidator>
            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
        </div>
    </div>
</asp:Content>

