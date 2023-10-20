<%@ Page Title="Ver Entrega" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerEntrega.aspx.cs" Inherits="WebApplication1.Estudiantes.MisCursadas.Entregas.VerEntrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Ver Entrega</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Nombre del Material -->       
                <asp:Label ID="materialFechalabel" runat="server" CssClass="form-control-plaintext"></asp:Label>
                <br />
                <hr />
                <h3>Documento</h3>
                <!-- Visualizador de PDF -->
                <asp:Literal ID="pdfViewer" runat="server"></asp:Literal>
                <br />
                <!-- Botón de Descarga -->
                <asp:Button ID="btnDownload" CssClass="btn btn-primary" Text="Descargar" runat="server" OnClick="btnDownload_Click"/>
                <hr />
                <h3>Comentario</h3>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" Enabled="false" ID="comentario" CssClass="form-control w-100" Rows="10" style="height:150px;" TextMode="MultiLine"> </asp:TextBox>
                        </div>
                    </div>
                </div>                    
            </div>
        </div>
        <br />
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click" />
    </div>
</asp:Content>