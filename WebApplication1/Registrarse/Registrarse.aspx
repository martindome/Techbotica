<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="WebApplication1.Registarse.Registarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="background-color: #f8f9fa; padding: 20px; border-radius: 5px;">
        <h2 class="mt-4">Registro de Estudiante</h2>
        <div class="form-group">
            <label for="nombre">Nombre</label>
            <asp:TextBox ID="nombre" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="nombre" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="nombre" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="apellido">Apellido</label>
            <asp:TextBox ID="apellido" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" Display="None" runat="server" ControlToValidate="apellido" CssClass="text-danger" ErrorMessage="Debe ingresar un apellido para continuar"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ControlToValidate="apellido" CssClass="text-danger" ErrorMessage="Debe ingresar un apellido valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="telefono">Teléfono</label>
            <asp:TextBox ID="telefono" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" Display="None" ControlToValidate="telefono" CssClass="text-danger" ErrorMessage="Debe ingresar un telefono para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefono" Display="None" runat="server" ControlToValidate="telefono" CssClass="text-danger" ErrorMessage="Debe ingresar un numero telefonico valido" ValidationExpression="^[\d-]{7,15}$"></asp:RegularExpressionValidator>

        </div>
        <div class="form-group">
            <label for="correoElectronico">Correo Electrónico</label>
            <asp:TextBox ID="correoElectronico" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreo" runat="server" Display="None" ControlToValidate="correoElectronico" CssClass="text-danger" ErrorMessage="Debe ingresar un correo para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCorreo" Display="None" runat="server" ControlToValidate="correoElectronico" CssClass="text-danger" ErrorMessage="Debe ingresar una casilla de email valida" ValidationExpression="^[a-zA-Z0-9+_.-]{1,50}@[a-zA-Z0-9.-]{1,49}$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="empresa">Empresa</label>
            <asp:TextBox ID="empresa" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmpresa" runat="server" Display="None" ControlToValidate="Empresa" CssClass="text-danger" ErrorMessage="Debe indicar la empresa"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmpresa" Display="None" runat="server" ControlToValidate="empresa" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre de empresa valido" ValidationExpression="^(?=.{1,50}$)[a-zA-Z-]+(?: [a-zA-Z-]+)*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" Text="Registrar" runat="server" OnClick="btnRegistrar_Click"/>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="" Class="text-danger"></asp:Label>
            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
        </div>
    </div>
</asp:Content>
