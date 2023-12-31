﻿<%@ Page Title="Nueva Entrega" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaEntrega.aspx.cs" Inherits="WebApplication1.Estudiantes.MisCursadas.NuevaEntrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Nueva Entrega</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de selección del archivo -->
                <div class="form-group">
                    <label for="pdfFile">Seleccionar Archivo PDF</label>
                    <asp:FileUpload ID="pdfFile" CssClass="form-control-file" runat="server" />
                </div>

                <!-- Botón de entrega -->
                <div class="form-group">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Entregar" runat="server" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>