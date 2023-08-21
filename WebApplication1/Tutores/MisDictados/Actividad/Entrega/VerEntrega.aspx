<%@ Page Title="Ver Entrega" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerEntrega.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Actividad.VerEntrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Ver Entrega</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Nombre de la Actividad -->
                <asp:Label ID="activityNameLabel" runat="server"></asp:Label>
                <br />
                
                <!-- Visualizador de PDF -->
                <asp:Literal ID="pdfViewer" runat="server"></asp:Literal>
                <br />

                <!-- Botón de Descarga -->
                <asp:Button ID="btnDownload" CssClass="btn btn-primary" Text="Descargar" runat="server" OnClick="btnDownload_Click"/>
                <br />   
            </div>
        </div>
        <br/>
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
    </div>
</asp:Content>
