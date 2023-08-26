<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h3 class="mb-0">Iniciar Sesión</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="username">Nombre de usuario</label>
                        <asp:TextBox ID="username" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña</label>
                        <asp:TextBox ID="password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-group text-center">
                        <asp:Button ID="btnLogin" CssClass="btn btn-primary" Text="Iniciar Sesión" runat="server" OnClick="btnLogin_Click" />
                    </div>
                    <div class="text-center">
                        <asp:HyperLink ID="btnRegister" CssClass="btn btn-link" NavigateUrl="~/Registrarse/Registrarse.aspx" Text="Registrarse" runat="server" />
                        <asp:HyperLink ID="btnRecover" CssClass="btn btn-link" NavigateUrl="~/Login/RecuperarCuenta.aspx" Text="Recuperar cuenta" runat="server" />               
                    </div>
                    <div class="text-center">
                        <asp:Label ID="Label1" Class="text-danger" runat="server" Text=""></asp:Label>
                        <asp:RequiredFieldValidator cssClass="hiddenValidator" ID="RequiredFieldValidatorCorreo" Display="None" runat="server" ControlToValidate="username" ErrorMessage="Debe ingresar un correo para continuar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator cssClass="hiddenValidator" ID="RegularExpressionValidatorCorreo" Display="None" runat="server" ControlToValidate="username"  ErrorMessage="Debe ingresar una casilla de email valida" ValidationExpression="^[a-zA-Z0-9+_.-]{1,50}@[a-zA-Z0-9.-]{1,49}$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator cssClass="hiddenValidator" ID="RequiredFieldValidatorPass" Display="None" runat="server" ControlToValidate="password"  ErrorMessage="Debe ingresar su password para continuar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator cssClass="hiddenValidator" ID="RegularExpressionValidatorPass" Display="None" runat="server" ControlToValidate="password"  ErrorMessage="La clave no excede 50 caracteres" ValidationExpression="^.{1,50}$"></asp:RegularExpressionValidator>
                        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
