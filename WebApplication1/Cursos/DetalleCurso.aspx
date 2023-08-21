<%@ Page Title="Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCurso.aspx.cs" Inherits="WebApplication1.Cursos.DetalleCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Detalles del Curso</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Detalles del curso -->
                <p><strong>Nombre:</strong> <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label></p>
                <p><strong>Descripción:</strong> <asp:Label ID="lblCourseDescription" runat="server" Text=""></asp:Label></p>
                <p><strong>Especialidad:</strong> <asp:Label ID="lblCourseSpeciality" runat="server" Text=""></asp:Label></p>

                <!-- Filtros para dictados -->
                <h2 class="mt-4">Buscar clases</h2>
                <div class="form-group">
                    <label for="searchStartDate">Fecha de Inicio</label>
                    <asp:TextBox ID="searchStartDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label for="searchEndDate">Fecha de Fin</label>
                    <asp:TextBox ID="searchEndDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="searchStartDate">Modalidad de Dictado</label>
                    <asp:DropDownList ID="searchCourseType" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Interactivo" Value="Interactivo" />
                        <asp:ListItem Text="Autodirigido" Value="Autodirigido" />
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="searchSchedule">Horario</label>
                    <asp:TextBox ID="searchSchedule" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="searchTutor">Tutor</label>
                    <asp:TextBox ID="searchTutor" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnFilter" CssClass="btn btn-primary" Text="Filtrar" runat="server" />
                </div>

                <!-- Lista de dictados -->
                <asp:GridView ID="lecturesGrid" CssClass="table" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha de Inicio" DataField="Fecha de Inicio" />
                        <asp:BoundField HeaderText="Fecha de Fin" DataField="Fecha de Fin" />
                        <asp:BoundField HeaderText="Horarios" DataField="Horarios" />
                        <asp:BoundField HeaderText="Tutores" DataField="Tutores" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" runat="server" CssClass="btn btn-secondary" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelect_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- Botones de acción -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
