<%@ Page Title="Business days" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    Start date:
    <br />
    <asp:Calendar ID="StartDatePicker" runat="server" OnSelectionChanged="OnStartDateSelectionChanged"></asp:Calendar>

    <br />
    <br />

    End date:
    <asp:Calendar ID="EndDatePicker" runat="server" OnSelectionChanged="OnEndDateSelectionChanged"></asp:Calendar>

    <br />
    <asp:Button ID="ActionButton" runat="server" Text="Calculate" OnClick="OnActionButtonClick" />
    <br />

    <br />
    <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
    <br />

</asp:Content>
