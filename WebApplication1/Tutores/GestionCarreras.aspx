<%@ Page Title="Gestion de Carreras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionCarreras.aspx.cs" Inherits="WebApplication1.Tutores.NuevaCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Gestión de Carreras</h2>
        
        <asp:TextBox ID="SearchCareerTextBox" runat="server" CssClass="form-control" Placeholder="Buscar carreras por nombre"></asp:TextBox>
        <asp:Button ID="SearchCareerButton" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2 mb-2" />

        <asp:GridView ID="CareersGrid" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowDeleting="CareersGrid_RowDeleting" OnRowEditing="CareersGrid_RowEditing">
            <Columns>
                <asp:BoundField DataField="CareerName" HeaderText="Nombre de la Carrera" />

                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-primary" OnClick="EditCareerButton_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" OnClick="DeleteCareerButton_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>

        <div class="mt-3">
            <asp:Button ID="NewCareerButton" runat="server" Text="Nueva Carrera" CssClass="btn btn-success" OnClick="NewCareerButton_Click" />
        </div>
    </div>
</asp:Content>
