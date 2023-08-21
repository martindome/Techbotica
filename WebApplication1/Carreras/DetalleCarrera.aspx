<%@ Page Title="Detalle Carrera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCarrera.aspx.cs" Inherits="WebApplication1.Carreras.DetalleCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Detalles de la Carrera</h2>
        <div class="form-group">
            <label for="nombreCarrera">Nombre de la Carrera</label>
            <asp:Label ID="nombreCarrera" CssClass="form-control" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <label for="descripcionCarrera">Descripción</label>
            <asp:Label ID="descripcionCarrera" CssClass="form-control" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <label for="cursosCarrera">Cursos Contenidos</label>
            <asp:GridView ID="cursosCarrera" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="form-group">
            <asp:Button ID="btnInscribirse" CssClass="btn btn-primary" Text="Inscribirse" runat="server" OnClick="btnInscribirse_Click" />
        </div>
    </div>
</asp:Content>
