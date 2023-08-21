<%@ Page Title="Confirmar Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarRegistro.aspx.cs" Inherits="WebApplication1.Registarse.ConfirmarRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="background-color: #f8f9fa; padding: 20px; border-radius: 5px;">
        <h2 class="mt-4">Confirmación de Registro</h2>
        <p>Por favor, ingresa el código de confirmación que te hemos enviado a tu correo electrónico.</p>
        <div class="form-group">
            <label for="codigoConfirmacion">Código de Confirmación</label>
            <asp:TextBox ID="codigoConfirmacion" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnConfirmar" CssClass="btn btn-primary" Text="Confirmar" runat="server" OnClick="btnConfirmar_Click"/>
        </div>
    </div>
</asp:Content>