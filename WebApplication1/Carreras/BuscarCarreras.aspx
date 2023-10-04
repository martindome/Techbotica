<%@ Page Title="Busqueda Carreras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCarreras.aspx.cs" Inherits="WebApplication1.BuscarCarreras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Gestión de Carreras</h2>
        
        <asp:TextBox ID="SearchCareerTextBox" runat="server" CssClass="form-control" Placeholder="Buscar carreras por nombre"></asp:TextBox>
        <asp:Button ID="SearchCareerButton" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2 mb-2" OnClick="SearchCareerButton_Click" />

        <asp:GridView ID="CareersGrid" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" /> 
                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" ButtonType="Button" CommandName="Edit" Text="Inscribir" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ControlStyle-CssClass="btn btn-primary" OnClick="EnrollCareer_CLICK"/>
                    </ItemTemplate>
                </asp:TemplateField>          
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
