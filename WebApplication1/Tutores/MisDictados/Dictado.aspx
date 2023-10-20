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
                <div class="table-responsive mt-4">
                    <asp:GridView ID="materialsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Material" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" HtmlEncode="false" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnViewMaterial" CssClass="btn btn-info" Text="Ver" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnViewMaterial_Click"/>
                                    <asp:Button ID="btnEditMaterial" CssClass="btn btn-primary" Text="Editar" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnEditMaterial_Click" />
                                    <asp:Button ID="btnDeleteMaterial" CssClass="btn btn-danger" Text="Eliminar" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnDeleteMaterial_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                

                <!-- Lista de Actividades -->
                <h3 class="mt-4">Actividades</h3>
                <div class="table-responsive mt-4">
                    <asp:GridView ID="activitiesGrid" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre de la Actividad" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" HtmlEncode="false" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnViewActivity" CssClass="btn btn-info" Text="Ver" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnViewActivity_Click" />
                                    <asp:Button ID="btnEditActivity" CssClass="btn btn-primary" Text="Editar" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnEditActivity_Click" />
                                    <asp:Button ID="btnDeleteActivity" CssClass="btn btn-danger"  Text="Eliminar" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnDeleteActivity_Click"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                

                <!-- Botones para agregar nuevos elementos -->
                <div class="mt-4">
                    <asp:Button ID="btnNewMaterial" CssClass="btn btn-primary" Text="Nuevo Material" runat="server" OnClick="btnNewMaterial_Click"/>
                    <asp:Button ID="btnNewActivity" CssClass="btn btn-primary" Text="Nueva Actividad" runat="server" OnClick="btnNewActivity_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>