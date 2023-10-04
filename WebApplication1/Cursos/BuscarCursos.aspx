﻿<%@ Page Title="Busqueda Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCursos.aspx.cs" Inherits="WebApplication1.BuscarCursos" %>
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
                    <label for="searchCareer">Buscar por Carrera</label>
                    <asp:TextBox ID="searchCareer" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="searchSpeciality">Buscar por Especialidad</label>
                    <asp:DropDownList ID="searchSpeciality" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" OnClick="btnSearch_Click" />
                </div>
                <div class="table-responsive mt-4">
                    <!-- GridView para listar los cursos -->
                    <asp:GridView ID="coursesGrid" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
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
                                    <asp:Button ID="btnDictation" CssClass="btn btn-primary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Ver Dictados" runat="server" OnClick="btnDictation_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>     
            </div>
        </div>
    </div>
</asp:Content>