<%@ Page Title="Cursada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursada.aspx.cs" Inherits="WebApplication1.Estudiantes.Cursadas.Cursada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Cursada</h2>

        <!-- Agregar div con Label para el enlace del curso -->
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="courseLinkLabel" runat="server">
                    Aula: 
                    <a href='https://meet.google.com/' runat="server" id="courseLink">Enlace a videollamada</a>
                </asp:Label>
            </div>
        </div>
        
        <!-- Información adicional -->
        <div class="row">
            <div class="col-md-12">
                <br />
                <asp:Label ID="startDateLabel" runat="server">
                    Fecha de inicio: <asp:Label ID="startDate" runat="server"></asp:Label>
                </asp:Label>
                <br />
                <asp:Label ID="endDateLabel" runat="server">
                    Fecha de fin: <asp:Label ID="endDate" runat="server"></asp:Label>
                </asp:Label>
                <br />
                <asp:Label ID="scheduleLabel" runat="server">
                    Horario: <asp:Label ID="schedule" runat="server"></asp:Label>
                </asp:Label>
                <br />
                <asp:Label ID="tutorsLabel" runat="server">
                    Tutores: <asp:Label ID="tutors" runat="server"></asp:Label>
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
                                <asp:Button ID="btnViewMaterial" CssClass="btn btn-secondary" Text="Ver" runat="server" onclick="btnViewMaterial_Click"/>
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
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
    </div>
</asp:Content>