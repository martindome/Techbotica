<%@ Page Title="Detalle Empresa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleEmpresa.aspx.cs" Inherits="WebApplication1.Administracion.Empresas.DetalleEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Editar Empresa</h2>

        <div class="form-group">
            <label for="CompanyName">Nombre de la Empresa</label>
            <asp:TextBox ID="CompanyName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyDesc">Descripción de la Empresa</label>
            <asp:TextBox ID="CompanyDesc" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyEmail">Email de la Empresa</label>
            <asp:TextBox ID="CompanyEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CompanyPhone">Teléfono de la Empresa</label>
            <asp:TextBox ID="CompanyPhone" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnEditCompany" CssClass="btn btn-success" Text="Aplicar cambios" runat="server" OnClick="btnEditCompany_Click" />
            <asp:Button ID="btnEditDomains" CssClass="btn btn-primary ml-2" Text="Editar Dominios" runat="server" OnClick="btnEditDomains_Click" />
        </div>
        
    </div>
</asp:Content>

