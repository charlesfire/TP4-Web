using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageModification : System.Web.UI.Page
{
  protected void Page_LoadComplete(object sender, EventArgs e)
  {
    if ((User)Session["user"] == null)
    {
      Response.Redirect("tp4.aspx");
    }
  }

  protected void btnConfirmer_Click(object sender, EventArgs e)
  {
    User user = (User)Session["user"];
    if (user != null)
    {
      if (txtBPassword.Text != "")
        ModifierBD("UPDATE users SET Password = '" + txtBPassword.Text + "WHERE Username = '" + user.Name + "'");
      int MaxWidth = 200;
      int MaxHeight = 200;
      if (txtBSignature.Text != "")
        ModifierBD("UPDATE users SET Signature = '" + txtBSignature.Text + "' WHERE Username = '" + user.Name + "';");
      if (txtBAdresse.Text != "")
        ModifierBD("UPDATE users SET Adresse = '" + txtBAdresse.Text + "' WHERE Username = '" + user.Name + "';");
      if (txtBEmail.Text != "")
        ModifierBD("UPDATE users SET Email = '" + txtBEmail.Text + "' WHERE Username = '" + user.Name + "';");
      if (!fileUAvatar.HasFile)
      ModifierBD("UPDATE users SET Avatar = 'default.png' WHERE Username = '" + user.Name + "';");
      else
      {
        try
        {
          string type = fileUAvatar.PostedFile.ContentType.Substring(0, 5);

          if (type == "image")
          {
            if (TesterTailleImage(MaxWidth, MaxHeight))
            {
              System.IO.File.Delete(Server.MapPath("~/Images/") + user.Avatar);
              string filename = fileUAvatar.FileName;
              string[] getExtension = fileUAvatar.FileName.Split('.');
              filename = user.Name + "." + getExtension[getExtension.Length - 1];
              string path = Server.MapPath("~/Images/") + filename;
              fileUAvatar.SaveAs(path);
              ModifierBD("UPDATE users SET Avatar = '" + filename + "' WHERE Username = '" + user.Name + "';");
              Session["texteConfirmation"] = "Votre modification a été effectuée avec succès.";
              Server.Transfer("PageConfirmation.aspx");
            }
            else
            {
              lblAvatar2.Text = string.Format("Attention: l'image doit faire au maximum {0} pixels de largeur pour {1} pixels de hauteur.", MaxWidth, MaxHeight);
            }
          }
          else
          {
            lblAvatar2.Text = "Seules les fichiers d'image sont acceptés.";
          }
        }
        catch
        {
          lblAvatar2.Text = "Le fichier ne peut être chargé";
        }
      }
    }
  }

  private void ModifierBD(string requeteSQL)
  {
    OleDbConnection maConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"Forum DB/Forum.accdb"));
    OleDbCommand maCommande = new OleDbCommand(requeteSQL, maConnection);
    bool connectionReussie = false;
    try
    {
      maConnection.Open();
      connectionReussie = true;
    }
    catch
    {
      lblAvatar.Text = "Erreur de connection, veuillez réessayer plus tard";
    }

    if (connectionReussie)
    {
      try
      {
        maCommande.ExecuteReader();
      }
      catch
      {

      }
      finally
      {
        maConnection.Close();
      }
    }
  }

  public bool TesterTailleImage(int MaxWidth, int MaxHeight)
  {
    System.Drawing.Image myImage;
    try
    {
      myImage = System.Drawing.Image.FromStream(fileUAvatar.PostedFile.InputStream);
    }
    catch
    {
      return false;
    }

    return (myImage.Width <= MaxWidth && myImage.Height <= MaxHeight);
  }

  protected void btnAnnuler_Click(object sender, EventArgs e)
  {
    if (Session["LastPage"] != null)
      Response.Redirect((string)Session["LastPage"]);
    else
      Response.Redirect("tp4.aspx");
  }

  protected void PreRender(object sender, EventArgs e)
  {
    User user = (User)Session["user"];

    //On ne peut pas tester à partir de la page modification elle même. Il faut se connecter au site avant.
    if (user != null)
    {
      string password = user.Password;
      string hiddenPassword = "";
      for (int i = 0; i != password.Length; i++)
      {
        hiddenPassword+="*";
      }
      lblCurrentPassword.Text = hiddenPassword;
      lblCurrentAdress.Text = user.Adresse;
      lblCurrentEmail.Text = user.Email;
    }
  }
}