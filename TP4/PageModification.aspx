<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PageModification.aspx.cs" Inherits="PageModification" %>

<asp:Content ContentPlaceHolderId="Wrapper" runat="server">
  
  <asp:Label ID="lblPassword" runat="server" Text="Entrez votre mot de passe:" ToolTip=" "></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
  <asp:TextBox ID="txtBPassword" runat="server" TextMode="Password" Width="311px" MaxLength="20"></asp:TextBox>
  <asp:RegularExpressionValidator ID="RegExValLblPassword" runat="server" ControlToValidate="txtBPassword" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[\s\S]{8,20}$">Votre mot de passe doit avoir au moins 8 caractères</asp:RegularExpressionValidator>
  <br />
  <br />
  <asp:Label ID="lblConfPassword" runat="server" Text="Confirmez votre mot de passe:"></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBConfirmPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
  <asp:TextBox ID="txtBConfirmPassword" runat="server" TextMode="Password" Width="288px" MaxLength="20"></asp:TextBox>
  <asp:CompareValidator ID="cmpValLblConfirmPassword" runat="server" ControlToCompare="txtBPassword" ControlToValidate="txtBConfirmPassword" ErrorMessage="Votre mot de passe de confirmation ne correspond pas avec le mot de passe" ForeColor="Red"></asp:CompareValidator>
  <br />
  <br />
  <asp:Label ID="lblEmail" runat="server" Text="Entrez votre adresse couriel:"></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
  <asp:TextBox ID="txtBEmail" runat="server" Width="301px"></asp:TextBox>
  <asp:RegularExpressionValidator ID="regExValLblEmail" runat="server" ControlToValidate="txtBEmail" ErrorMessage="Votre adresse couriel est invalide" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  <br />
  <br />
  <asp:Label ID="lblAdresse" runat="server" Text="Entrez votre adresse:"></asp:Label>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBAdresse" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
  <asp:TextBox ID="txtBAdresse" runat="server" Width="346px"></asp:TextBox>
  <br />
  <br />
  <asp:Label ID="lblAvatar" runat="server" Text="Choisissez votre avatar (optionnel): "></asp:Label>
  <asp:FileUpload ID="fileUAvatar" runat="server" />
  <asp:Label ID="lblAvatar2" runat="server"></asp:Label>
  <br />
  <br />Choisissez votre signature (optionnel):<br />
  <br />
  <asp:TextBox ID="txtBoxSignature" runat="server" Height="90px" Rows="3" TextMode="MultiLine" Width="477px"></asp:TextBox>
  <br />
  <br />
  <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" OnClick="btnConfirmer_Click" />
  
</asp:Content>


