<%@ Page Title="Nuevo Material" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoMaterial.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Material.NuevoMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Nuevo Material</h2>

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
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click" />
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="materialName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="materialName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-Z0-9 ]{1,50}$"></asp:RegularExpressionValidator>
                <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
            </div>
        </div>
    </div>
</asp:Content>