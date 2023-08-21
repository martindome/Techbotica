<%@ Page Title="Nuevo Dictado - Paso 2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoDictado2doPaso.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.NuevoDictado2doPaso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container mt-5">
        <div class="row">
            <!-- Segunda Columna - Horarios -->
            <div class="col-lg-12">
                <h2>Paso 2: Horarios</h2>
                <hr />
                <div class="input-group">
                    <asp:TextBox ID="SearchScheduleTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="SearchScheduleButton" runat="server" Text="Asignar" CssClass="btn btn-primary" />
                </div>
                <asp:GridView ID="SchedulesGrid" runat="server" AutoGenerateColumns="false" CssClass="table mt-3">
                    <Columns>
                        <asp:BoundField HeaderText="Horario" DataField="Schedule" />
                        <asp:ButtonField Text="Asignar" CommandName="Assign" />
                    </Columns>
                </asp:GridView>
                <h3 class="mt-3">Horarios Asignados</h3>
                <asp:GridView ID="AssignedSchedulesGrid" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Horario" DataField="Schedule" />
                        <asp:ButtonField Text="Desasignar" CommandName="Unassign" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="NextPageButton" runat="server" Text="Siguiente" CssClass="btn btn-primary mt-3" OnClick="NextPageButton_Click" />
                <asp:Button ID="btnBack" CssClass="btn btn-secondary mt-3" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
            </div>
        </div>
    </div>
</asp:Content>
