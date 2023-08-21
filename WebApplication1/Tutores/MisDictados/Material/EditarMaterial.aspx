<%@ Page Title="Editar Material" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarMaterial.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Material.EditarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Editar Material</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de edición del nombre del material -->
                <div class="form-group">
                    <label for="materialName">Nombre del Material</label>
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