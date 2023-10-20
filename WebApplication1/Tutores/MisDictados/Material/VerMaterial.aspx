<%@ Page Title="Ver Material" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerMaterial.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Material.VerMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Ver Material</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Nombre del Material -->     
                <asp:Label ID="materialNameLabel" runat="server" CssClass="form-control-plaintext"></asp:Label>
                <br />
                <hr />
                <asp:Label ID="materialFechalabel" runat="server" CssClass="form-control-plaintext"></asp:Label>
                <br />
                <hr />
                <h3>Documento</h3>
                <!-- Visualizador de PDF -->
                <asp:Literal ID="pdfViewer" runat="server"></asp:Literal>
                <br />
                <!-- Botón de Descarga -->
                <asp:Button ID="btnDownload" CssClass="btn btn-primary" Text="Descargar" runat="server" OnClick="btnDownload_Click"/>
            </div>
        </div>
        <br />
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click" />
    </div>
</asp:Content>
