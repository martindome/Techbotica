<%@ Page Title="Gestionar Permisos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarPermisos.aspx.cs" Inherits="WebApplication1.Administracion.GestionarPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Gestión de Permisos (Familias)</h2>
    
        <!-- Sección de agregar nueva familia -->
        <asp:TextBox ID="NewFamilyNameTextBox" runat="server" CssClass="form-control mt-2" Placeholder="Nombre de la nueva familia"></asp:TextBox>
        <asp:Button ID="AddFamilyButton" runat="server" Text="Agregar Familia" CssClass="btn btn-success mt-2 mb-2" OnClick="AddFamilyButton_Click" />

        <!-- GridView para familias -->
        <div class="table-responsive mt-4">
            <asp:GridView ID="FamiliesGrid" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="familia" HeaderText="Familia" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditFamily" runat="server" Text="Editar" CommandName="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("id") %>' OnClick="btnEditFamily_Click" />
                            <asp:Button ID="btnDeleteFamily" runat="server" Text="Eliminar" CommandName="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("id") %>' OnClick="btnDeleteFamily_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
