<%@ Page Title="Editar Dictado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDictado.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.EditarDictado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Editar Dictado</h2>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" AssociatedControlID="DictationStartDate" CssClass="form-label">Fecha de inicio:</asp:Label>
                <asp:TextBox ID="DictationStartDate" type="date" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="DictationEndDate" CssClass="form-label">Fecha de finalización:</asp:Label>
                <asp:TextBox ID="DictationEndDate" type="date" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="TextBoxcupo" CssClass="form-label">Cupo:</asp:Label>
                <asp:TextBox ID="TextBoxcupo"  runat="server" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-md-4">
                <h4>Horarios</h4>
                <div class="input-group mb-3">
                    <asp:TextBox ID="SearchScheduleTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button class="btn btn-primary" type="button" ID="SearchScheduleButton" Text="Buscar" runat="server" />
                </div>

                <asp:ListBox ID="AvailableSchedulesList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-secondary mb-3" type="button" ID="AddScheduleButton" Text="Agregar Horario" runat="server" />

                <h4>Horarios Asignados</h4>
                <asp:ListBox ID="AssignedSchedulesList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-danger mb-3" type="button" ID="RemoveScheduleButton" Text="Eliminar Horario" runat="server" />
            </div>

            <div class="col-md-4">
                <h4>Tutores</h4>
                <div class="input-group mb-3">
                    <asp:TextBox ID="SearchTutorTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button class="btn btn-primary" type="button" ID="SearchTutorButton" Text="Buscar" runat="server" />
                </div>

                <asp:ListBox ID="AvailableTutorsList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-secondary mb-3" type="button" ID="AddTutorButton" Text="Agregar Tutor" runat="server" />

                <h4>Tutores Asignados</h4>
                <asp:ListBox ID="AssignedTutorsList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-danger mb-3" type="button" ID="RemoveTutorButton" Text="Eliminar Tutor" runat="server" />
            </div>
        </div>

        <asp:Button class="btn btn-primary mt-3" type="button" ID="UpdateDictationButton" Text="Actualizar Dictado" runat="server" OnClick="UpdateDictationButton_Click" />
        <asp:Button class="btn btn-danger mt-3" type="button" ID="DeleteDictationButton" Text="Eliminar Dictado" runat="server" OnClick="DeleteDictationButton_Click" />
    </div>
</asp:Content>