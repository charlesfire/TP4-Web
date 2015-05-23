<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageConfirmation.aspx.cs" Inherits="PageConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">
  <p style="font-size: large; text-align: center">
    <br />
    <asp:Label ID="lblConfirmation" runat="server" Text="Votre inscription a été réussie!" OnPreRender="PreRender"></asp:Label>
  </p>
  <p style="font-size: large; text-align: center">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Retourner à la page d'origine" PostBackUrl="~/tp4.aspx" UseSubmitBehavior="False" />
  </p>
</asp:Content>

