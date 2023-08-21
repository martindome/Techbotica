<%@ Page Title="Dictado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dictado.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Dictado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Dictado</h2>

        <!-- Agregar div con Label para el enlace del curso -->
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="courseLinkLabel" runat="server">
                    Aula: 
                    <a href='https://meet.google.com/' runat="server" id="courseLink">Enlace a videollamada</a>
                </asp:Label>
            </div>
        </div>


        <div class="row">
            <div class="col-md-8">
                <!-- Lista de Materiales -->
                <h3 class="mt-4">Materiales</h3>
                <asp:GridView ID="materialsGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Material" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnViewMaterial" CssClass="btn btn-secondary" Text="Ver" runat="server" OnClick="btnViewMaterial_Click"/>
                                <asp:Button ID="btnEditMaterial" CssClass="btn btn-secondary" Text="Editar" runat="server" OnClick="btnEditMaterial_Click" />
                                <asp:Button ID="btnDeleteMaterial" CssClass="btn btn-secondary" Text="Eliminar" runat="server" OnClick="btnDeleteMaterial_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- Lista de Actividades -->
                <h3 class="mt-4">Actividades</h3>
                <asp:GridView ID="activitiesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre de la Actividad" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnViewActivity" CssClass="btn btn-secondary" Text="Ver" runat="server" OnClick="btnViewActivity_Click" />
                                <asp:Button ID="btnEditActivity" CssClass="btn btn-secondary" Text="Editar" runat="server" OnClick="btnEditActivity_Click" />
                                <asp:Button ID="btnDeleteActivity" CssClass="btn btn-secondary" Text="Eliminar" runat="server" OnClick="btnDeleteActivity_Click"/>
                                <asp:Button ID="btnViewDeliveries" CssClass="btn btn-secondary" Text="Ver Entregas" runat="server" OnClick="btnViewDeliveries_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- Botones para agregar nuevos elementos -->
                <div class="mt-4">
                    <asp:Button ID="btnNewMaterial" CssClass="btn btn-primary" Text="Nuevo Material" runat="server" OnClick="btnNewMaterial_Click"/>
                    <asp:Button ID="btnNewActivity" CssClass="btn btn-primary" Text="Nueva Actividad" runat="server" OnClick="btnNewActivity_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>