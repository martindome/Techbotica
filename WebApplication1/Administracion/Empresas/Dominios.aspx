<%@ Page Title="Editar Dominios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dominios.aspx.cs" Inherits="WebApplication1.Administracion.Empresas.Dominios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Dominios de la Empresa</h2>

        <asp:GridView ID="DomainsGrid" CssClass="table" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField DataField="DomainSuffix" HeaderText="Sufijo del Dominio" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-danger"/>
            </Columns>
        </asp:GridView>

        <div class="form-group mt-4">
            <label for="NewDomain">Nuevo Dominio</label>
            <asp:TextBox ID="NewDomain" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnCreateDomain" CssClass="btn btn-success" Text="Crear Dominio" runat="server" />
        </div>
    </div>
</asp:Content>
