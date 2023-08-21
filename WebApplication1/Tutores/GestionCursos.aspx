<%@ Page Title="Gestion de Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionCursos.aspx.cs" Inherits="WebApplication1.Tutores.MisCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Gestión de Cursos</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de búsqueda -->
                <div class="form-group">
                    <label for="searchName">Buscar por Nombre</label>
                    <asp:TextBox ID="searchName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="searchSpeciality">Buscar por Especialidad</label>
                    <asp:DropDownList ID="searchSpeciality" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="searchSpeciality">Buscar por Carrera</label>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
                </div>

                <!-- GridView para listar los cursos -->
                <asp:GridView ID="coursesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CssClass="btn btn-secondary" CommandArgument='<%# Eval("Nombre") %>' Text="Editar" runat="server" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Nombre") %>' Text="Eliminar" runat="server" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnDictation" CssClass="btn btn-primary" CommandArgument='<%# Eval("Nombre") %>' Text="Ver Dictados" runat="server" OnClick="btnDictation_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </div>
        </div>
    </div>
</asp:Content>