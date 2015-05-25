<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageDiscussion.aspx.cs" Inherits="PageDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">
  <asp:Label ID="lblTitre" runat="server" OnPreRender="lblTitre_PreRender" Text="Label" OnUnload="lblTitre_Unload"></asp:Label>
  <br />
  <br />
  <asp:Table ID="tblContent" runat="server">
  </asp:Table>
  <br />
  <asp:Panel ID="pnlMessage" runat="server" OnPreRender="pnlMessage_PreRender">
    Message:<br />
    <asp:TextBox ID="txtbMessage" runat="server" Height="199px" TextMode="MultiLine" Width="485px"></asp:TextBox>
    <br />
    <asp:Button ID="btnSoumettre" runat="server" Text="Soumettre" OnClick="btnSoumettre_Click" />
  </asp:Panel>
</asp:Content>

