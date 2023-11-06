<%@ Page Title="Gestionar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarUsuario.aspx.cs" Inherits="WebApplication1.Administracion.Usuarios.GestionarUsuario" %>
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
        <asp:TextBox ID="correoElectronico" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="ddlPerfil">Perfil</label>
        <asp:DropDownList ID="ddlPerfil" CssClass="form-control" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPerfil" runat="server" Display="None" ControlToValidate="ddlPerfil" CssClass="text-danger" ErrorMessage="Debe seleccionar un perfil"></asp:RequiredFieldValidator>
    </div>

    <div class="form-check mb-3">
        <asp:CheckBox ID="CheckBoxBloqueado" runat="server" Checked="false" CssClass="form-check-input" />
        <label class="form-check-label" for="CheckBoxBloqueado">Bloqueado</label>
    </div>

    <div class="form-check mb-3">
        <asp:CheckBox ID="CheckBoxBorrado" runat="server" Checked="false" CssClass="form-check-input" />
        <label class="form-check-label" for="CheckBoxBorrado">Borrado</label>
    </div>
    <div class="form-group">
        <asp:Button ID="btnConfirmar" CssClass="btn btn-primary" Text="Confirmar" runat="server" OnClick="btnConfirmar_Click"/>
    </div>
    <div class="form-group mt-4">
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click" CausesValidation="false" />
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="" Class="text-danger"></asp:Label>
        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
    </div>
</div>
</asp:Content>
