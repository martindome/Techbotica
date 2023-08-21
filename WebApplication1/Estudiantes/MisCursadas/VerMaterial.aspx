<%@ Page Title="Ver Material" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerMaterial.aspx.cs" Inherits="WebApplication1.Estudiantes.Cursadas.VerMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Ver Material</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Nombre del Material -->
                <asp:Label ID="materialNameLabel" runat="server"></asp:Label>
                <br />
                
                <!-- Visualizador de PDF -->
                <asp:Literal ID="pdfViewer" runat="server"></asp:Literal>
                <br />
                <!-- Botón de Descarga -->
                <asp:Button ID="btnDownload" CssClass="btn btn-primary" Text="Descargar" runat="server" OnClick="btnDownload_Click"/>
            </div>
        </div>
        <br />
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
    </div>
</asp:Content>
