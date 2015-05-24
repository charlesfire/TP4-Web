<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageModification.aspx.cs" Inherits="PageModification" %>

<asp:Content ContentPlaceHolderId="Wrapper" runat="server">
  
  <asp:Label ID="lblPassword" runat="server" Text="Entrez votre mot de passe:" ToolTip=" "></asp:Label>
&nbsp;<asp:TextBox ID="txtBPassword" runat="server" TextMode="Password" Width="311px" MaxLength="20"></asp:TextBox>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mot de passe actuel:&nbsp;
<asp:Label ID="lblCurrentPassword" runat="server" OnPreRender="PreRender"></asp:Label>
<br />
  <asp:RegularExpressionValidator ID="RegExValLblPassword" runat="server" ControlToValidate="txtBPassword" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[\s\S]{8,20}$">Votre mot de passe doit avoir au moins 8 caractères</asp:RegularExpressionValidator>
  <br />
  <br />
  <asp:Label ID="lblConfPassword" runat="server" Text="Confirmez votre mot de passe:"></asp:Label>
&nbsp;<asp:TextBox ID="txtBConfirmPassword" runat="server" TextMode="Password" Width="288px" MaxLength="20"></asp:TextBox>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <br />
  <asp:CompareValidator ID="cmpValLblConfirmPassword" runat="server" ControlToCompare="txtBPassword" ControlToValidate="txtBConfirmPassword" ErrorMessage="Votre mot de passe de confirmation ne correspond pas avec le mot de passe" ForeColor="Red"></asp:CompareValidator>
  <br />
  <br />
  <asp:Label ID="lblEmail" runat="server" Text="Entrez votre adresse couriel:"></asp:Label>
&nbsp;<asp:TextBox ID="txtBEmail" runat="server" Width="301px"></asp:TextBox>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Adresse couriel actuel:
  <asp:Label ID="lblCurrentEmail" runat="server"></asp:Label>
  <br />
  <asp:RegularExpressionValidator ID="regExValLblEmail" runat="server" ControlToValidate="txtBEmail" ErrorMessage="Votre adresse couriel est invalide" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  <br />
  <br />
  <asp:Label ID="lblAdresse" runat="server" Text="Entrez votre adresse:"></asp:Label>
  <asp:TextBox ID="txtBAdresse" runat="server" Width="346px"></asp:TextBox>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Adresse actuelle:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="lblCurrentAdress" runat="server"></asp:Label>
  <br />
  <br />
  <asp:Label ID="lblAvatar" runat="server" Text="Choisissez votre avatar (optionnel): "></asp:Label>
  <asp:FileUpload ID="fileUAvatar" runat="server" />
  <asp:Label ID="lblAvatar2" runat="server"></asp:Label>
  <br />
  <br />Choisissez votre signature (optionnel):<br />
  <br />
  <asp:TextBox ID="txtBSignature" runat="server" Height="90px" Rows="3" TextMode="MultiLine" Width="400px" MaxLength="100"></asp:TextBox>
  <br />
  <br />
  <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" OnClick="btnConfirmer_Click" />
  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Button ID="btnAnnuler" runat="server" OnClick="btnAnnuler_Click" Text="Annuler" />
  
</asp:Content>


