<%@ Page Title="Busqueda Carreras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCarreras.aspx.cs" Inherits="WebApplication1.BuscarCarreras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Buscar Carreras</h2>
        <div class="form-group">
            <label for="searchName">Buscar por Nombre</label>
            <asp:TextBox ID="searchName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
        </div>
        <asp:GridView ID="carrerasGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" CssClass="btn btn-secondary" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelect_Click1" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
