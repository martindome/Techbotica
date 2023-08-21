<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-end align-items-start pt-3 pr-3" style="height: 10vh;">
    <div runat="server" method="get" action="SearchResults.aspx" class="w-50">
        <div class="input-group">
            <input name="query" class="form-control form-control-lg" type="search" placeholder="Curso o carrera">
            <asp:button runat="server" class="btn btn-secondary my-2 my-sm-0" type="submit" Text="Buscar" OnClick="Unnamed_Click"></asp:button>
        </div>
    </div>
    </div>

</asp:Content>
