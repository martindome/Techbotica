<%@ Page Title="Gestionar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarUsuarios.aspx.cs" Inherits="WebApplication1.Administracion.GestionarEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <hr />

    <div class="row mb-5">
        <div class="col-md-6">
            <h2>Filtros de búsqueda</h2>
            <div class="form-group">
                <label for="TextBoxUsuarioFiltro">Usuario:</label>
                <asp:TextBox ID="TextBoxUsuarioFiltro" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-check">
                <asp:CheckBox ID="CheckBoxBloqueadoFiltro" runat="server" Checked="false" CssClass="form-check-input" />
                <label class="form-check-label" for="CheckBoxBloqueadoFiltro">Bloqueado</label>
            </div>

            <div class="form-check mb-3">
                <asp:CheckBox ID="CheckBoxBorradoFiltro" runat="server" Checked="false" CssClass="form-check-input" />
                <label class="form-check-label" for="CheckBoxBorradoFiltro">Borrado</label>
            </div>

            <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar Usuarios" OnClick="ButtonFiltrar_Click" CssClass="btn btn-primary mb-3" />
            
            <hr />

            <h2>Selección de Usuario</h2>
            <div id="TablaUsuario">
                <asp:ListBox ID="ListBoxUsuarios" runat="server" class="list-group mb-3" SelectionMode="Single" Width="100%" Height="400" Font-Names="Arial" BackColor="#999999" BorderColor="Black" BorderStyle="Dashed" ForeColor="Black"></asp:ListBox>
                <asp:Button ID="ButtonSeleccionarUsuario" runat="server" Text="Seleccionar Usuario" OnClick="ButtonSeleccionar_Click" CssClass="btn btn-primary mb-3" />
            </div>
        </div>

        <div class="col-md-6">
            <h2>Información del Usuario</h2>
            <div id="CambiarInfo" class="mb-3">
                <div class="form-group">
                    <label for="LabelUsuarioSeleccionado">Usuario seleccionado:</label>
                    <asp:Label id="LabelUsuarioSeleccionado" runat="server" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group">
                    <label for="TextBoxNombre">Nombre:</label>
                    <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TextBoxApellido">Apellido:</label>
                    <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TextBoxEmail">Email:</label>
                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TextBoxTelefono">Teléfono:</label>
                    <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-check mb-3">
                    <asp:CheckBox ID="CheckBoxBloqueado" runat="server" Checked="false" CssClass="form-check-input" />
                    <label class="form-check-label" for="CheckBoxBloqueado">Bloqueado</label>
                </div>

                <div class="form-check mb-3">
                    <asp:CheckBox ID="CheckBoxBorrado" runat="server" Checked="false" CssClass="form-check-input" />
                    <label class="form-check-label" for="CheckBoxBorrado">Borrado</label>
                </div>

                <asp:Button ID="ButtonAplicar" runat="server" Text="Aplicar" OnClick="ButtonAplicar_Click" CssClass="btn btn-primary mb-3" />
            </div>
        </div>

    </div>

    <hr />

    <div class="d-flex justify-content-between">
        <asp:Button ID="ButtonNuevoUsuario" runat="server" Text="Nuevo Usuario" OnClick="ButtonNuevoUsuario_Click" CssClass="btn btn-primary" />
        <asp:Button ID="ButtonSalir" runat="server" Text="Salir" OnClick="ButtonSalir_Click" CssClass="btn btn-secondary" />
    </div>
</asp:Content>


