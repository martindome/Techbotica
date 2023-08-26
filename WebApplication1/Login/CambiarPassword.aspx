<%@ Page Title="Actualizar Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="WebApplication1.Login.CambiarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <section id="LoginForm">
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group" id="PasswordActual">
                        <asp:Label runat="server" AssociatedControlID="TextBoxPassActual" CssClass="col-md-2 control-label">Clave Actual</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxPassActual" runat="server" class="form-group" TextMode="Password"></asp:TextBox>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassActual" CssClass="text-danger" ErrorMessage="Debe ingresar la clave actual para continuar"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" id="Password">
                        <asp:Label runat="server" AssociatedControlID="TextBoxPassword" CssClass="col-md-2 control-label">Nueva Clave</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxPassword" runat="server" class="form-group" TextMode="Password"></asp:TextBox>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Debe ingresar una contraseña para continuar"></asp:RequiredFieldValidator>
                            <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Su password debe contener entre 8 y 20 caracteres, al menos 1 numero y 1 caracter especial" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cambiar Clave" CssClass="btn btn-primary" />
                            <asp:Button ID="btnUnenroll" CausesValidation="false" CssClass="btn btn-danger" Text="Cancelar" runat="server" OnClick="btnUnenroll_Click"/>
                        </div>
                        <asp:Label ID="Label1" runat="server" Text="" class="alert-danger"></asp:Label>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
