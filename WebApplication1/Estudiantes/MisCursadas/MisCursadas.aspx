<%@ Page Title="Mis Cursadas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisCursadas.aspx.cs" Inherits="WebApplication1.Estudiantes.Cursadas.MisCursadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Mis Cursadas</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de búsqueda -->
                <div class="form-group">
                    <label for="searchCourseName">Buscar por Nombre del Curso</label>
                    <asp:TextBox ID="searchCourseName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
                </div>

                <!-- GridView para listar las cursadas -->
                <asp:GridView ID="coursesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Curso" />
                        <asp:BoundField DataField="Horario" HeaderText="Horario" />
                        <asp:BoundField DataField="FechadeInicio" HeaderText="Fecha de Inicio" />
                        <asp:BoundField DataField="FechadeFin" HeaderText="Fecha de Fin" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" OnClick="btnSelect_Click" CssClass="btn btn-secondary" CommandArgument='<%# Eval("Nombre") %>' Text="Seleccionar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>