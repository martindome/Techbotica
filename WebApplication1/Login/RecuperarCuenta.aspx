<%@ Page Title="Recuperar Cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="WebApplication1.Login.RecuperarCuenta" %>
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
                        <asp:Button ID="btnRecover" CssClass="btn btn-primary" Text="Enviar" runat="server" OnClick="btnRecover_Click" />
                    </div>
                    <div>
                        <asp:RequiredFieldValidator cssClass="hiddenValidator" ID="RequiredFieldValidatorCorreo" Display="None" runat="server" ControlToValidate="email" ErrorMessage="Debe ingresar un correo para continuar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator cssClass="hiddenValidator" ID="RegularExpressionValidatorCorreo" Display="None" runat="server" ControlToValidate="email"  ErrorMessage="Debe ingresar una casilla de email valida" ValidationExpression="^[a-zA-Z0-9+_.-]{1,50}@[a-zA-Z0-9.-]{1,49}$"></asp:RegularExpressionValidator>                      
                        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
