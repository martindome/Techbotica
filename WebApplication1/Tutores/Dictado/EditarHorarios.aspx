<%@ Page Title="Editar Horarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHorarios.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.EditarHorarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <div class="container mt-5">
    
        <h2>Configuración de Horarios</h2>
    
        <div class="card mt-4 p-4">
            <h4 class="mb-4">Agregar Nuevo Horario</h4>

            <div class="form-group row">
                <label for="DayDropDownList" class="col-sm-2 col-form-label">Día:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="DayDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Lunes" Value="Lunes"></asp:ListItem>
                        <asp:ListItem Text="Martes" Value="Martes"></asp:ListItem>
                        <asp:ListItem Text="Miércoles" Value="Miércoles"></asp:ListItem>
                        <asp:ListItem Text="Jueves" Value="Jueves"></asp:ListItem>
                        <asp:ListItem Text="Viernes" Value="Viernes"></asp:ListItem>
                        <asp:ListItem Text="Sábado" Value="Sábado"></asp:ListItem>
                        <asp:ListItem Text="Domingo" Value="Domingo"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="StartTimeTextBox" class="col-sm-2 col-form-label">Hora Inicio:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="StartTimeTextBox" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="EndTimeTextBox" class="col-sm-2 col-form-label">Hora Fin:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="EndTimeTextBox" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10 offset-sm-2">
                    <asp:Button ID="AddButton" runat="server" Text="Agregar" onclick="AddButton_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>

        <div class="mt-5">
            <h4 class="mb-4">Horarios Agregados</h4>
            <asp:GridView ID="HorariosGridView" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Dia" HeaderText="Día" />
                    <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" />
                    <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Eliminar" runat="server" onclick="btnEliminar_Click" CausesValidation="false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="mt-4 text-right">
        
            <asp:Button ID="Volver" runat="server" Text="Volver" OnClick="Volver_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
