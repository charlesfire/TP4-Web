<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Resume.aspx.cs" Inherits="Resume" %>

<asp:Content ContentPlaceHolderId="Wrapper" runat="server">
  <div id = "main">
	
		<asp:Label ID="lblResume" runat="server" CssClass="subTitles" Text="Résumé"></asp:Label>
		<br />
		Nous avons reçu,
	
		<asp:Label ID="lblPrenom" runat="server"></asp:Label>
		&nbsp;, votre demande de réservation en date du
		<asp:Label ID="lblDate" runat="server"></asp:Label>
		pour les matchs suivants :<br />
		<br />
		<asp:Table ID="tbInscriptions" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" HorizontalAlign="Center">
			<asp:TableRow runat="server" BackColor="Gray" Font-Bold="True" ForeColor="White">
				<asp:TableCell runat="server">Événement</asp:TableCell>
				<asp:TableCell runat="server">Jeu</asp:TableCell>
				<asp:TableCell runat="server">Plancher</asp:TableCell>
				<asp:TableCell runat="server">Date</asp:TableCell>
				<asp:TableCell runat="server">Heure</asp:TableCell>
			</asp:TableRow>
		</asp:Table>
	
		<br />
		<br />
		<asp:Label ID="lblNote" runat="server" ForeColor="Red" Text="Note : Veuillez imprimer et conserver ce document. Il est la preuve que vous vous êtes bien inscrit aux match ci-dessus."></asp:Label>
		<br />
		<br />
		<asp:Button ID="btnRetour0" runat="server" OnClick="btnRetour_Click" Text="Retour à la page des évènements" CssClass="button" PostBackUrl="~/PageÉvènement.aspx" />
	
		<asp:Button ID="btnRetour" runat="server" OnClick="btnRetour_Click" Text="Retour à l'acceuil" CssClass="button" />
	
	</div>
</asp:Content>
