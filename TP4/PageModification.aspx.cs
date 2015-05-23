using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageModification : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

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
              string filename = fileUAvatar.FileName;
              string[] getExtension = fileUAvatar.FileName.Split('.');
              filename = user.Name + "." + getExtension[getExtension.Length - 1];
              string path = Server.MapPath("~\\Images\\") + filename;
              fileUAvatar.SaveAs(path);
              Session["imageURL"] = "~/Images/" + filename;
              ModifierBD("UPDATE users SET Avatar = '" + filename + "' WHERE Username = '" + user.Name + "';");
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
        catch (Exception ex)
        {
          lblAvatar2.Text = "Le fichier ne peut être chargé";
        }
      }
    }
    Server.Transfer("PageConfirmation.aspx");
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

    //Si le fichier n'est pas une image, on retourne faux, peu importe ce qui arrive.  
    //Il faut le faire même si on vérifie le type mime du fichier avant.  Un type mime, ça peut se hacker.
    //La sécurité informqatique, c'est ne jamais prendre de chances.
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
}