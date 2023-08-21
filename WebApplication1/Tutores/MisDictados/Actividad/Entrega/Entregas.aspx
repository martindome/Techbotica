<%@ Page Title="Ver Entregas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entregas.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Actividad.Entregas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Lista de Entregas</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Lista de entregas -->
                <asp:GridView ID="deliveriesGrid" CssClass="table" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="NombreAlumno" HeaderText="Nombre del Alumno" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnViewDelivery" CssClass="btn btn-secondary" runat="server" Text="Ver Entrega" OnClick="btnViewDelivery_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
       <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
    </div>
</asp:Content>

