<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageCréation.aspx.cs" Inherits="PageCréation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">
  <p>
    <br />
  </p>
  <p>
    Sujet:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbSujet" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="txtbSujet" runat="server" MaxLength="40" Width="650px"></asp:TextBox>
  </p>
  <p>
    Contenu:&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbContenu" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
  </p>
  <p style="margin-left: 40px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtbContenu" runat="server" Height="300px" TextMode="MultiLine" Width="650px"></asp:TextBox>
  </p>
  <p style="margin-left: 40px">
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
</asp:Content>

