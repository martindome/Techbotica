<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCarreras.aspx.cs" Inherits="WebApplication1.Tutores.Curso.EditarCarreras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-4">Carreras del curso</h2>
    <div class="row">
        <div class="col-md-6">
            <h3>Carreras Disponibles</h3>
            <asp:ListBox ID="AvailableCareers" CssClass="form-control" Height="400" runat="server">
            </asp:ListBox>
            <asp:Button ID="btnAssignCareer" CssClass="btn btn-primary mt-2" Text="Asignar Carrera" runat="server" OnClick="btnAssignCareer_Click" CausesValidation="false" />
        </div>

        <div class="col-md-6">
            <h3>Carreras Asignadas</h3>
            <asp:ListBox ID="AssignedCareers" CssClass="form-control" Height="400" runat="server">
            </asp:ListBox>
            <asp:Button ID="btnRemoveCareer" CssClass="btn btn-danger mt-2" Text="Desasignar Carrera" runat="server" OnClick="btnRemoveCareer_Click" CausesValidation="false"/>
        </div>
        <div>
            <br />
            
            <asp:Button ID="btnBackToCourses" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBackToCourses_Click" CausesValidation="false" />
        </div>
        
    </div>
</asp:Content>
