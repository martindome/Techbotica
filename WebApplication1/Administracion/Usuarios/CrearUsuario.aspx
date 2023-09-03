<%@ Page Title="Crear Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="WebApplication1.Administracion.Usuarios.CrearUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="background-color: #f8f9fa; padding: 20px; border-radius: 5px;">
        <h2 class="mt-4">Registro de Usuario</h2>
        <div class="form-group">
            <label for="nombre">Nombre</label>
            <asp:TextBox ID="TextBoxNombre" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="TextBoxNombre" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="TextBoxNombre" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="apellido">Apellido</label>
            <asp:TextBox ID="TextBoxApellido" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" Display="None" runat="server" ControlToValidate="TextBoxApellido" CssClass="text-danger" ErrorMessage="Debe ingresar un apellido para continuar"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ControlToValidate="TextBoxApellido" CssClass="text-danger" ErrorMessage="Debe ingresar un apellido valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="telefono">Teléfono</label>
            <asp:TextBox ID="TextBoxTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" Display="None" ControlToValidate="TextBoxTelefono" CssClass="text-danger" ErrorMessage="Debe ingresar un telefono para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefono" Display="None" runat="server" ControlToValidate="TextBoxTelefono" CssClass="text-danger" ErrorMessage="Debe ingresar un numero telefonico valido" ValidationExpression="^[\d-]{7,15}$"></asp:RegularExpressionValidator>

        </div>
        <div class="form-group">
            <label for="correoElectronico">Correo Electrónico</label>
            <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreo" runat="server" Display="None" ControlToValidate="TextBoxEmail" CssClass="text-danger" ErrorMessage="Debe ingresar un correo para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCorreo" Display="None" runat="server" ControlToValidate="TextBoxEmail" CssClass="text-danger" ErrorMessage="Debe ingresar una casilla de email valida" ValidationExpression="^[a-zA-Z0-9+_.-]{1,50}@[a-zA-Z0-9.-]{1,49}$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="correoElectronico">Contraseña</label>
            <asp:TextBox ID="TextBoxPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Debe ingresar una clave para continuar"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Su password debe contener entre 8 y 20 caracteres, al menos 1 número y 1 carácter especial" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,30}$"></asp:RegularExpressionValidator>
        </div>
       
        <div class="form-group">
            <label >Familia</label>
                <asp:ListBox ID="GridView2" runat="server" SelectionMode="Single" CssClass="list-group" Width="200" Height="200" Font-Names="Arial" BackColor="#f5f5f5" BorderColor="#e0e0e0" BorderStyle="Solid" ForeColor="Black"></asp:ListBox>
        </div>

        <!-- Lista Especialidad -->
        <%--<div class="form-group">
            <label >Especialidad</label>
            <asp:ListBox ID="ListBoxEspecialidades" runat="server" SelectionMode="Single" CssClass="list-group" Width="200" Height="200" Font-Names="Arial" BackColor="#f5f5f5" BorderColor="#e0e0e0" BorderStyle="Solid" ForeColor="Black"></asp:ListBox>
        </div>--%>

        <!-- Lista Empresa -->
        <div class="form-group">
            <label>Empresa</label>
            <asp:ListBox ID="ListBoxEmpresas" runat="server" SelectionMode="Single" CssClass="list-group" Width="200" Height="200" Font-Names="Arial" BackColor="#f5f5f5" BorderColor="#e0e0e0" BorderStyle="Solid" ForeColor="Black"></asp:ListBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" Text="Registrar" runat="server" OnClick="btnRegistrar_Click"/>
            <asp:Button ID="ButtonSalir" runat="server" Text="Salir" OnClick="ButtonSalir_Click" CssClass="btn btn-secondary" CausesValidation="false"/>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="" Class="text-danger"></asp:Label>
            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
        </div>
    </div>

    <asp:RequiredFieldValidator 
        ID="RequiredFieldValidatorFamilia" 
        runat="server" 
        Display="None" 
        ControlToValidate="GridView2" 
        CssClass="text-danger" 
        ErrorMessage="Debe seleccionar una familia para continuar">
    </asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidatorEmpresa" 
        runat="server" 
        Display="None" 
        ControlToValidate="ListBoxEmpresas" 
        CssClass="text-danger" 
        ErrorMessage="Debe seleccionar una empresa para continuar">
    </asp:RequiredFieldValidator>




</asp:Content>
