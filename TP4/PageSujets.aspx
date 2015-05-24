<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageSujets.aspx.cs" Inherits="PageSujets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">
  <p>
    Forum</p>
    <asp:Literal ID="LtlSujets" runat="server" OnPreRender="PreRender"></asp:Literal>
  <br />
  <asp:Panel ID="pnlSujet" runat="server" BorderStyle="Solid">
    <asp:HyperLink ID="Titre" runat="server" NavigateUrl="~/PageDiscussion.aspx">Titre</asp:HyperLink>
    &nbsp;CreationDate Créé par: Username<br /> &nbsp;Nb repliques: NbPosts Derniere modification: LastPost Par: LastPoster</asp:Panel>
</asp:Content>