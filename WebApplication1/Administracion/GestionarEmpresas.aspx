<%@ Page Title="Gestionar Empresas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarEmpresas.aspx.cs" Inherits="WebApplication1.Administracion.GestionarEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Gestión de Empresas</h2>
        
        <asp:TextBox ID="SearchCompanyByNameTextBox" runat="server" CssClass="form-control" Placeholder="Buscar empresas por nombre"></asp:TextBox>
        <asp:TextBox ID="SearchCompanyByDescTextBox" runat="server" CssClass="form-control mt-2" Placeholder="Buscar empresas por descripción"></asp:TextBox>
        <asp:Button ID="SearchCompanyButton" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2 mb-2" OnClick="SearchCompanyButton_Click" />

        <asp:GridView ID="CompaniesGrid" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="IdEmpresa">
            <Columns>
                <asp:BoundField DataField="IdEmpresa" HeaderText="Id" Visible="false" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" ID="botoneditar" ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="botoneditar_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" id="botoneliminar" ButtonType="Button" CommandName="Delete" Text="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ControlStyle-CssClass="btn btn-danger" OnClick="botoneliminar_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="mt-3">
            <asp:Button ID="NewCompanyButton" runat="server" Text="Nueva Empresa" CssClass="btn btn-success" OnClick="NewCompanyButton_Click" />
        </div>
        <div>
            <asp:RegularExpressionValidator cssClass="hiddenValidator" ID="RegularExpressionNombre" Display="None" runat="server" ControlToValidate="SearchCompanyByNameTextBox"  ErrorMessage="Formato de nombre invalido" ValidationExpression="^[a-zA-Z0-9+_.-]{0,50}$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator cssClass="hiddenValidator" ID="RegularExpressionDescripcion" Display="None" runat="server" ControlToValidate="SearchCompanyByDescTextBox"  ErrorMessage="Formato de descripcion invalido" ValidationExpression="^[a-zA-Z0-9+_.-]{0,50}$"></asp:RegularExpressionValidator>
            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
        </div>
    </div>
</asp:Content>

