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
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
