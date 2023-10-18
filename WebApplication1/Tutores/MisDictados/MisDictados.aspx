<%@ Page Title="Mis Dictados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisDictados.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.MisDictaods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Mis Dictados</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Sección de búsqueda -->
                <h2 class="mt-4">Buscar Dictados</h2>
                <div class="form-group">
                    <label for="searchDictationName">Buscar por Nombre del Curso</label>
                    <asp:TextBox ID="searchDictationName" CssClass="form-control" runat="server"></asp:TextBox>
                    
                    <div class="form-group">
                        <label for="searchStartDate">Fecha de Inicio</label>
                        <asp:TextBox ID="searchStartDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="searchEndDate">Fecha de Fin</label>
                        <asp:TextBox ID="searchEndDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" OnClick="btnSearch_Click" />
                </div>

                <!-- GridView para listar los dictados -->
                <h2 class="mt-4">Lista de Dictados</h2>
                <!-- Sección de inscripciones a cursos -->
                <div class="table-responsive mt-4"> 
                    <asp:GridView ID="UserCoursesGrid" runat="server"  CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" >
                        <Columns>
                            <asp:TemplateField HeaderText="Especialidad">
                                <ItemTemplate>
                                    <%# Eval("Curso.Nombre") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" DataFormatString="{0:d}" HtmlEncode="false" />
                            <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Finalizacion" DataFormatString="{0:d}" HtmlEncode="false" />
                            <asp:BoundField DataField="TipoDictado" HeaderText="Tipo de dictado"/>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnSelect" runat="server" Text="Ingresar" CssClass="btn btn-primary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelect_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>