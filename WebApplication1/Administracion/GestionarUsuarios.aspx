<%@ Page Title="Gestionar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarUsuarios.aspx.cs" Inherits="WebApplication1.Administracion.GestionarEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />

    <div class="col-md-4">
        <strong>Seleccionar el usuario:</strong>
        <div id="TablaUsuario">
            <asp:ListBox ID="ListBoxUsuarios" runat="server" class="list-group" SelectionMode="Single" Width="300" Height="400" Font-Names="Arial" AutoGenerateSelectButton="True" BackColor="#999999" BorderColor="Black" BorderStyle="Dashed" ForeColor="Black"></asp:ListBox>
            <br />
            <asp:Button ID="ButtonSeleccionarUsuario" runat="server" Text="Seleccionar Usuario" OnClick="ButtonSeleccionar_Click" CssClass="btn btn-primary" />
            <br />
            <strong>Filtros: </strong>
            <br />
            Usuario: <asp:TextBox ID="TextBoxUsuarioFiltro" runat="server"></asp:TextBox>
            <br />
            Bloqueado: <asp:CheckBox ID="CheckBoxBloqueadoFiltro" runat="server" Checked="false" />
            <br />
            Borrado: <asp:CheckBox ID="CheckBoxBorradoFiltro" runat="server" Checked="false" />
            <br />
            <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar Usuarios" OnClick="ButtonFiltrar_Click" CssClass="btn btn-primary" />
            <br />
        </div>
    </div>
    <hr />
    <div class="col-md-4">
        <strong>Informacion: </strong>
        <div id="CambiarInfo">
            Usuario seleccionado: <asp:Label id="LabelUsuarioSeleccionado" runat="server"></asp:Label>
            <br />
            Nombre: <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <br />
            Nombre: <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
            <br />
            Email: <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <br />
            Telefono: <asp:TextBox ID="TextBoxTelefono" runat="server"></asp:TextBox>
            <br />
            Bloqueado: <asp:CheckBox ID="CheckBoxBloqueado" runat="server" Checked="false" />
            <br />
            Borrado: <asp:CheckBox ID="CheckBoxBorrado" runat="server" Checked="false" />
            <br />
            <%--Familia Actual: <asp:Label id="LabelFamiliaActual" runat="server"></asp:Label>--%>
        </div>
    </div>

    <%--<div class="col-md-4">
        <strong>Seleccionar el nuevo perfil:</strong>
        <div id="TablaPerfilesAgregar">
            <asp:ListBox ID="ListBoxFamilias" runat="server" SelectionMode="Single" CssClass="list-group" Width="300" Height="400" Font-Names="Arial" BackColor="#999999" BorderColor="Black" BorderStyle="Dashed" ForeColor="Black"></asp:ListBox>
        </div>
    </div>--%>

    <hr />
    <asp:Label ID="LabelAccion" runat="server" Text="" CssClass="text-info"></asp:Label>
    <br />
    <asp:Button ID="ButtonAplicar" runat="server" Text="Aplicar" OnClick="ButtonAplicar_Click" CssClass="btn btn-primary"/>

    
    <br />
    <asp:Button ID="ButtonNuevoUsuario" runat="server" Text="Nuevo Usuario" OnClick="ButtonNuevoUsuario_Click" CssClass="btn btn-primary" />
    <br />
    <asp:Button ID="ButtonSalir" runat="server" Text="Salir" OnClick="ButtonSalir_Click" CssClass="btn btn-secondary" />
</asp:Content>

