<%@ Page Title="Mis Dictados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisDictados.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.MisDictaods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Mis Dictados</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de búsqueda -->
                <div class="form-group">
                    <label for="searchDictationName">Buscar por Nombre del Curso</label>
                    <asp:TextBox ID="searchDictationName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
                </div>

                <!-- GridView para listar los dictados -->
                <h2 class="mt-4">Lista de Dictados</h2>
                <asp:GridView ID="dictationsGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Curso" HeaderText="Nombre del Curso" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" />
                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Fin" />
                        <asp:BoundField DataField="Horario" HeaderText="Horario" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" CssClass="btn btn-secondary" Text="Seleccionar" runat="server" OnClick="btnSelect_Click1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>