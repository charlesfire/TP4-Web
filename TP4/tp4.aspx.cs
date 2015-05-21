using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class tp4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSoumettre_Click(object sender, EventArgs e)
    {
      try
      {
        MailMessage couriel = new MailMessage();
        couriel.From = new MailAddress(txtBEmail.Text);
        couriel.To.Add(new MailAddress("joj@joj.joj"));
        couriel.Subject = txtBSujet.Text;
        couriel.Body = txtBContenu.Text;
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.UseDefaultCredentials = false;
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential("joj@joj.joj", "xxxxxxxx");
        client.Send(couriel);
      }
      catch (Exception ex)
      {
        //Traitement des erreurs
        lblErreur.Text = "Erreur lors de l'envoi du courriel: " + ex.Message;
      }
      finally
      {
        //Une fois le message envoyé, on vide le formulaire d'envoi du mail.
        lblContenu.Text = "";
        lblErreur.Text = "";
        lblSujet.Text = "";
      }
    }
}