<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageCréation.aspx.cs" Inherits="PageCréation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Wrapper" Runat="Server">

  <asp:Panel ID="pnlCreation" runat="server" OnPreRender="PreRendre">
    <p>
      Sujet:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbSujet" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
      &nbsp;<asp:TextBox ID="txtbSujet" runat="server" MaxLength="40" Width="650px"></asp:TextBox>
    </p>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtbSujet" ErrorMessage="Votre sujet doit être d'au moins 5 caractères." ForeColor="Red" ValidationExpression="^[\s\S]{8,20}$"></asp:RegularExpressionValidator>
    <p>
      Contenu:&nbsp;
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbContenu" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtbContenu" ErrorMessage="Votre contenu doit être d'au moins 5 caractères." ForeColor="Red"></asp:RegularExpressionValidator>
    </p>
    <p style="margin-left: 40px">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="txtbContenu" runat="server" Height="300px" TextMode="MultiLine" Width="650px"></asp:TextBox>
    </p>
    <p style="margin-left: 40px">
      &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnSoumettre" runat="server" Text="Soumettre" />
      &nbsp;<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" CausesValidation="False" OnClick="btnAnnuler_Click" />
    </p>
  </asp:Panel>
  <asp:Panel ID="pnlNestPasConnecte" runat="server" Visible="False">
    <br />
    Vous devez vous connecter pour utiliser cette page.</asp:Panel>

  </asp:Content>

