<%@ Page Title="Detalle Inscripcion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleInscripcionCarrera.aspx.cs" Inherits="WebApplication1.Estudiantes.DetalleInscripcionCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Detalles de la Carrera</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Detalles de la carrera -->
                <p><strong>Nombre:</strong> <asp:Label ID="lblCarreraName" runat="server" Text="Carrera 1"></asp:Label></p>
                <p><strong>Descripción:</strong> <asp:Label ID="lblCarreraDescription" runat="server" Text="Descripcion 1"></asp:Label></p>

                <h3 class="mt-4">Cursos contenidos</h3>
                <!-- Lista de cursos -->
                <asp:GridView ID="coursesGrid" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <%# Eval("Especialidad.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- Botones de acción -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnUnenroll" CssClass="btn btn-danger" Text="Desinscribir" runat="server" OnClientClick="return confirmDesinscription();" OnClick="btnUnenroll_Click" />
                    <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" Onclick="btnBack_Click"/>
                </div>
            </div>
        </div>
    </div>
        <script type="text/javascript">
        function confirmDesinscription() {
            var confirmValue = confirm('¿Está seguro de que desea desinscribirse de esta carrera? Esta acción no se puede deshacer.');
            return confirmValue; // Si es true, continuará con el evento OnClick del lado del servidor. Si es false, no pasará nada.
        }
    </script>

</asp:Content>
