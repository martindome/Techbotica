<%@ Page Title="Ver Entrega" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerEntrega.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Actividad.VerEntrega" %>
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
                            <asp:TextBox runat="server" ID="comentario" CssClass="form-control w-100" Rows="10" style="height:150px;" TextMode="MultiLine"> </asp:TextBox>
                            <asp:Button ID="ButtonComment" CssClass="btn btn-primary" Text="Comentar" runat="server" OnClick="ButtonComment_Click" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="comentario" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^.{0,500}$"></asp:RegularExpressionValidator>
                            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
                        </div>
                    </div>
                </div>                    
            </div>
        </div>
        <br />
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click" />
    </div>
</asp:Content>