<%@ Page Title="Gestion de Dictados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionDictados.aspx.cs" Inherits="WebApplication1.Tutores.GestionDictados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Gestión de Dictados</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de búsqueda -->
                <div class="form-group">
                    <label for="searchCourseName">Buscar por Nombre del Curso</label>
                    <asp:TextBox ID="searchCourseName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="searchCourseDate">Buscar por Fecha</label>
                    <asp:TextBox ID="searchCourseDate" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
                </div>

                <!-- GridView para listar los cursos -->
                <asp:GridView ID="coursesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Curso" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" CssClass="btn btn-secondary" CommandArgument='<%# Eval("Nombre") %>' Text="Seleccionar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- GridView para listar los dictados -->
                <h2 class="mt-4">Dictados</h2>
                <asp:GridView ID="dictationsGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FechadeInicio" HeaderText="Fecha de Inicio" />
                        <asp:BoundField DataField="FechadeFin" HeaderText="Fecha de Fin" />
                        <asp:BoundField DataField="Horarios" HeaderText="Horarios" />
                        <asp:BoundField DataField="Tutores" HeaderText="Tutores" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEditDictation" CssClass="btn btn-secondary" Text="Editar" runat="server" OnClick="btnEditDictation_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </div>
        </div>
    </div>
</asp:Content>