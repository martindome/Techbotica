<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="WebApplication1.Registarse.Registarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="background-color: #f8f9fa; padding: 20px; border-radius: 5px;">
        <h2 class="mt-4">Registro de Estudiante</h2>
        <div class="form-group">
            <label for="nombre">Nombre</label>
            <asp:TextBox ID="nombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="apellido">Apellido</label>
            <asp:TextBox ID="apellido" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="telefono">Teléfono</label>
            <asp:TextBox ID="telefono" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="correoElectronico">Correo Electrónico</label>
            <asp:TextBox ID="correoElectronico" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="contrasenia">Contraseña</label>
            <asp:TextBox ID="contrasenia" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" Text="Registrar" runat="server" OnClick="btnRegistrar_Click"/>
        </div>
    </div>
</asp:Content>
