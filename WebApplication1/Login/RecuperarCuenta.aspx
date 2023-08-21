<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="WebApplication1.Login.RecuperarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h3 class="mb-0">Recuperar Cuenta</h3>
                </div>
                <div class="card-body">
                    <p>Por favor, ingresa tu correo electrónico. Te enviaremos un codigo para restablecer tu contraseña.</p>
                    <div class="form-group">
                        <label for="email">Correo electrónico</label>
                        <asp:TextBox ID="email" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group text-center">
                        <asp:Button ID="btnRecover" CssClass="btn btn-primary" Text="Enviar enlace" runat="server" OnClick="btnRecover_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
