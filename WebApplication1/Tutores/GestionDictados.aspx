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

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" onclick="btnSearch_Click"/>
                </div>

                <!-- GridView para listar los cursos -->
                <asp:GridView ID="coursesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <%# Eval("Especialidad.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Seleccionar" runat="server" onclick="btnSelect_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- GridView para listar los dictados -->
                <h2 class="mt-4">Dictados</h2>
                <asp:GridView ID="dictationsGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnSorting="dictationsGrid_Sorting" DataKeyNames="Id">
                    <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" SortExpression="FechaInicio" />
                    <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Fin" SortExpression="FechaFin"/>
                    <asp:BoundField DataField="TipoDictado" HeaderText="Tipo de Dictado" SortExpression="TipoDictado" />
                    <asp:TemplateField HeaderText="Curso">
                        <ItemTemplate>
                            <%# Eval("Curso.Nombre") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Seleccionar" runat="server" OnClick="btnSelect_Click1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>