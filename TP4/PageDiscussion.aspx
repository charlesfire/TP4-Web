<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageDiscussion.aspx.cs" Inherits="PageDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">
  <asp:Label ID="lblTitre" runat="server" OnPreRender="lblTitre_PreRender" Text="Label"></asp:Label>
</asp:Content>

