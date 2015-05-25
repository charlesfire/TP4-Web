<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="PageÉvènement.aspx.cs" Inherits="PageÉvènement" %>

<asp:Content ContentPlaceHolderId="Wrapper" runat="server">
  <asp:Panel ID="pnlEvenement" runat="server" Visible="True" CssClass="pnl">
    <asp:Label ID="lblJeu" runat="server" Text="Jeu : "></asp:Label>
    <asp:DropDownList ID="ddlJeu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJeu_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Label ID="lblPlancher" runat="server" Text="Plancher : "></asp:Label>
    <asp:DropDownList ID="ddlPlancher" runat="server">
    </asp:DropDownList>
    <asp:Label ID="lblHeure" runat="server" Text="Heure : "></asp:Label>
    <asp:DropDownList ID="ddlHeure" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" CssClass="button" ValidationGroup="validerAjoutInscription" />
    <asp:CustomValidator ID="cvInscriptionsMemeHeure" runat="server" Display="None" ErrorMessage="Vous ne pouvez pas vous inscrire à deux matchs se passant en même temps." ValidationGroup="validerAjoutInscription" ClientValidationFunction="validerInscriptionsMemeHeure" OnServerValidate="cvInscriptionsMemeHeure_ServerValidate"></asp:CustomValidator>
    <asp:CustomValidator ID="cvNbMaxInscriptionsParPlancher" runat="server" ClientValidationFunction="validerNbMaxInscriptionsParPlancher" Display="None" ErrorMessage="Vous ne pouvez pas vous inscrire à plus de trois matchs par plancher." ValidationGroup="validerAjoutInscription" OnServerValidate="cvNbMaxInscriptionsParPlancher_ServerValidate"></asp:CustomValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" ValidationGroup="validerAjoutInscription" />
    <br />
  </asp:Panel>
  <br />
  <br />
  <asp:Panel ID="pnlEditionInscription" runat="server" CssClass="pnl" Visible="True">
    <asp:Label ID="lblVosInscriptions" runat="server" CssClass="subTitles" Text="Vos inscriptions"></asp:Label>
      <asp:CheckBoxList ID="cblInscriptions" runat="server" Enabled="False">
      </asp:CheckBoxList>
      <asp:Button ID="btnModifier" runat="server" CssClass="alignLeft button" OnClick="btnModifier_Click" Text="Modifier" />
      <asp:Button ID="btnSuprimerSelection" runat="server" CssClass="alignLeft button" OnClick="btnSuprimerSelection_Click" Text="Suprimer la sélection" Visible="False" />
  </asp:Panel>
  <br />
  <br />
  <asp:CustomValidator ID="cvNbMinimumMatch" runat="server" ClientValidationFunction="validerNbMinInscription" Display="None" ErrorMessage="Vous devez vous inscrire à au moins un match." OnServerValidate="cvNbMinimumMatch_ServerValidate" ValidationGroup="validerDocument"></asp:CustomValidator>
  <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" OnClick="btnConfirmer_Click" CssClass="button" ValidationGroup="validerDocument" />
  <asp:Button ID="btnAnnuler" runat="server" Text="Retour à l'acceuil" OnClick="btnAnnuler_Click" CssClass="button" EnableTheming="True" />
  <br />
  <br />
  <asp:Label ID="lblAssocies" runat="server" CssClass="subTitles" Text="Nos associés"></asp:Label>
  <br />
  <asp:Image ID="imgLogoSteam" runat="server" Height="78px" ImageUrl="~/Images/LogoDota.png" />
  <asp:Image ID="Image1" runat="server" Height="78px" ImageUrl="~/Images/LogoSteam.png" />
  <asp:Image ID="Image2" runat="server" Height="78px" ImageUrl="~/Images/LogoRiot.jpg" />
</asp:Content>