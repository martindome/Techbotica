<%@ Page Title="Nueva Empresa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaEmpresa.aspx.cs" Inherits="WebApplication1.Administracion.Empresas.NuevaEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Crear Nueva Empresa</h2>

        <div class="form-group">
            <label for="CompanyName">Nombre de la Empresa</label>
            <asp:TextBox ID="CompanyName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyDesc">Descripción de la Empresa</label>
            <asp:TextBox ID="CompanyDesc" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyPhone">Teléfono de la Empresa</label>
            <asp:TextBox ID="CompanyPhone" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <h3 class="mt-4">Dominios de la Empresa</h3>

        <asp:GridView ID="DomainsGrid" CssClass="table" runat="server" AutoGenerateColumns="false">
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
            <asp:Button ID="btnCreateDomain" CssClass="btn btn-success" Text="Agregar Dominio" runat="server" />
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnCreateCompany" CssClass="btn btn-primary" Text="Crear Empresa" runat="server" OnClick="btnCreateCompany_Click" />
        </div>
    </div>
</asp:Content>