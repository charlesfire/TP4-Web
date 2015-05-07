<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageInscription.aspx.cs" Inherits="PageInscription" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <br />
      <br />
      <asp:Label ID="lblNom" runat="server" Text="Nom d'utilisateur:"></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBUserName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
      <asp:TextBox ID="txtBUserName" runat="server" Width="363px" MaxLength="20"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegExValLblUsername" runat="server" ControlToValidate="txtBUserName" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[\s\S]{3,20}$">Votre nom d&#39;utilisateur doit avoir au moins 3 caractères</asp:RegularExpressionValidator>
      <br />
      <br />
      <asp:Label ID="lblPassword" runat="server" Text="Entrez votre mot de passe:" ToolTip=" "></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBUserName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
      <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" />
      <br />
    
    </div>
    </form>
</body>
</html>
