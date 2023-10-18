﻿<%@ Page Title="Nueva Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaActividad.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Actividad.NuevaActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Nueva Actividad</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de edición del nombre del material -->
                <div class="form-group">
                    <label for="materialName">Nombre de la Actividad</label>
                    <asp:TextBox ID="actividadName" CssClass="form-control" runat="server"></asp:TextBox>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" Display="None" runat="server" ControlToValidate="actividadName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" Display="None" runat="server" ControlToValidate="actividadName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-Z0-9 ]{1,50}$"></asp:RegularExpressionValidator>
                <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
            </div>
        </div>
    </div>
</asp:Content>
