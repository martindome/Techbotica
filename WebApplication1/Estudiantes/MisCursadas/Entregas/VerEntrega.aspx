<%@ Page Title="Ver Entrega" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerEntrega.aspx.cs" Inherits="WebApplication1.Estudiantes.MisCursadas.Entregas.VerEntrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Ver Entrega</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Visualizador de PDF -->
                <asp:Literal ID="pdfViewer" runat="server"></asp:Literal>
                <br />
                
                <!-- Botón de Descarga -->
                <asp:Button ID="btnDownload" CssClass="btn btn-primary" Text="Descargar" runat="server" OnClick="btnDownload_Click"/>
                <asp:Button ID="Button1" CssClass="btn btn-primary" Text="Atras" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
            </div>
        </div>
    </div>
</asp:Content>