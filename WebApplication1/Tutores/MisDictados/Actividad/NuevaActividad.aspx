<%@ Page Title="Nueva Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaActividad.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Actividad.NuevaActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Nueva Actividad</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de edición del nombre del material -->
                <div class="form-group">
                    <label for="materialName">Nombre de la Actividad</label>
                    <asp:TextBox ID="materialName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <!-- Sección de selección del archivo -->
                <div class="form-group">
                    <label for="pdfFile">Seleccionar Archivo PDF</label>
                    <asp:FileUpload ID="pdfFile" CssClass="form-control-file" runat="server" />
                </div>

                <!-- Botón de actualización -->
                <div class="form-group">
                    <asp:Button ID="btnUpdate" CssClass="btn btn-primary" Text="Subir" runat="server" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
