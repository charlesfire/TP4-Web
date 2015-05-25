<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="tp4.aspx.cs" Inherits="tp4" %>

<asp:Content ContentPlaceHolderId="Wrapper" runat="server">
    <div>
      Bienvenue dans le site de GameOn!<br />
      <br />
      Le but du site est de permettre aux membres de la ligue de discuter ensemble dans le forum ou de s&#39;inscrire à un de nos événements<br />
      <br />
      <br />
      <br />
      Nous nous trouvons ici:<br />
      <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4103.521048033648!2d123.35208900000036!3d-75.10048840639682!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xae51a4a78376dcd1%3A0x9b7c1a1b12be6d48!2sBase+antarctique+Concordia%2C+Antarctique!5e0!3m2!1sfr!2sca!4v1431630118437" width="600" height="450" frameborder="0" style="border:0"></iframe>
      <br />
      <br />
      Contactez-nous!<br />
      <br />
      <asp:Label ID="lblSujet" runat="server" Text="Sujet:"></asp:Label>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBSujet" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
      <asp:TextBox ID="txtBSujet" runat="server" MaxLength="50" Width="447px"></asp:TextBox>
      <br />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBSujet" ErrorMessage="Votre sujet doit être d'au moins 5 caractères." ForeColor="Red" ValidationExpression="^[\s\S]{5,}$"></asp:RegularExpressionValidator>
      <br />
      <asp:Label ID="lblVotreAdresse" runat="server" Text="Votre Adresse Email:"></asp:Label>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
      <asp:TextBox ID="txtBEmail" runat="server" Width="355px"></asp:TextBox>
      <br />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBEmail" ErrorMessage="Votre adresse email n'est pas valide." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
      <br />
      <asp:Label ID="lblContenu" runat="server" Text="Contenu:"></asp:Label>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBContenu" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
      <br />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtBContenu" ErrorMessage="Votre contenu doit être d'au moins 10 caractères." ForeColor="Red" ValidationExpression="^[\s\S]{10,}$"></asp:RegularExpressionValidator>
      <br />
      <asp:TextBox ID="txtBContenu" runat="server" Height="218px" Rows="10" TextMode="MultiLine" Width="483px"></asp:TextBox>
      <br />
      <asp:Label ID="lblErreur" runat="server"></asp:Label>
      <br />
      <asp:Button ID="btnSoumettre" runat="server" OnClick="btnSoumettre_Click" Text="Soumettre" />
    </div>
</asp:Content>

