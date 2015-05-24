<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageSujets.aspx.cs" Inherits="PageSujets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">
  <p>
    Forum</p>
    <asp:Button ID="btnTopCreerSujet" runat="server" Text="Créer un nouveau sujet" OnClick="btnCreerSujet_Click" Visible="False" />
    <br />
    <asp:Literal ID="LtlSujets" runat="server" OnPreRender="PreRender"></asp:Literal>
  <br />
    <asp:Button ID="btnBottomCreerSujet" runat="server" Text="Créer un nouveau sujet" OnClick="btnCreerSujet_Click" Visible="False" />
  <br />
</asp:Content>