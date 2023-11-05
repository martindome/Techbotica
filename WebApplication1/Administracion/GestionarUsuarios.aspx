<%@ Page Title="GestionarUsuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarUsuarios.aspx.cs" Inherits="WebApplication1.Administracion.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Gestión de Usuarios e Inscripciones</h2>
    
        <!-- Sección de búsqueda de usuarios -->
        <asp:TextBox ID="SearchUserByNameTextBox" runat="server" CssClass="form-control" Placeholder="Buscar usuarios por nombre"></asp:TextBox>
        <asp:TextBox ID="SearchUserByEmailTextBox" runat="server" CssClass="form-control mt-2" Placeholder="Buscar usuarios por nombre de usuario"></asp:TextBox>
        <div class="form-check mb-3">
            <asp:CheckBox ID="CheckBoxBloqueado" runat="server" Checked="false" CssClass="form-check-input" />
            <label class="form-check-label" for="CheckBoxBorrado">Bloqueado</label>
        </div>
        <asp:Button ID="SearchUserButton" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2 mb-2" onclick="SearchUserButton_Click" />

        <!-- GridView para usuarios -->
        <div class="table-responsive mt-4">
            <asp:GridView ID="UsersGrid" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="IdUsuario">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelectUser" runat="server" Text="Seleccionar" CommandName="Select" CssClass="btn btn-primary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' onclick="btnSelectUser_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="ButtonNuevoUsuario" runat="server" Text="Nuevo Usuario" OnClick="ButtonNuevoUsuario_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
