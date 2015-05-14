using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      lblErreurConnexion.Text = "";
    }

    protected void Page_PreRender()
    {
      if (Session["user"] != null)
      {
        pnlConnected.Visible = true;
        pnlConnexion.Visible = false;
      }
      else
      {
        pnlConnected.Visible = false;
        pnlConnexion.Visible = true;
      }
    }

    protected void btnSeConnecter_Click(object sender, EventArgs e)
    {
      OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"Forum DB/Forum.accdb"));
      OleDbCommand myAccessCommand = new OleDbCommand("SELECT [Password], IsBanned, PostCount, IsAdmin, Email, Avatar, Adresse FROM Users WHERE Username = '" + txtbPseudo.Text + "';", myConnection);

      try
      {
        myConnection.Open();
        OleDbDataReader myReader = myAccessCommand.ExecuteReader();
        if (myReader.Read() && (string)myReader["Password"] == txtbPassword.Text)
        {
          if ((bool)myReader["IsBanned"])
          {
            lblErreurConnexion.Text = "Vous avez été banni.";
          }
          else
          {
            User user = new User();
            user.Name = txtbPseudo.Text;
            user.Password = txtbPassword.Text;
            user.PostCount = int.Parse(myReader["PostCount"].ToString());
            user.IsAdmin = (bool)myReader["IsAdmin"];
            user.Email = (string)myReader["Email"];
            user.Avatar = (string)myReader["Avatar"];
            user.Adresse = (string)myReader["Adresse"];
            Session["user"] = user;

            imgbtnProfil.ImageUrl = "Images/" + user.Avatar;
            pnlConnexionReussie.Visible = true;
          }
        }
        else
        {
          lblErreurConnexion.Text = "La combinaison pseudo/mot de passe est invalide.";
        }
      }
      catch (Exception ex)
      {
        lblErreurConnexion.Text = "Erreur: " + ex.Message;
      }
      finally
      {
        myConnection.Close();
      }
    }

    protected void btnDeconnexion_Click(object sender, EventArgs e)
    {
      Session["user"] = null;
    }

    protected void btnInscription_Click(object sender, EventArgs e)
    {
      Session["lastPage"] = HttpContext.Current.Request.Url.AbsolutePath;
    }
}
