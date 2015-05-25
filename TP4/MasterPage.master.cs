﻿using System;
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
      User user = (User)Session["user"];
      if (user != null)
      {
        pnlConnected.Visible = true;
        pnlConnexion.Visible = false;
        imgbtnProfil.ImageUrl = "Images/" + user.Avatar;
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
      OleDbCommand userConnectCommand = new OleDbCommand("SELECT [Password], IsBanned, PostCount, IsAdmin, Email, Avatar, Adresse,Signature FROM Users WHERE Username = '" + txtbPseudo.Text + "';", myConnection);
      OleDbCommand eventInscriptionCommand = new OleDbCommand("SELECT Event, EventDate, Game, Floor, EventHour FROM Inscriptions WHERE '" + txtbPseudo.Text + "';", myConnection);

      try
      {
        myConnection.Open();
        OleDbDataReader myReader = userConnectCommand.ExecuteReader();
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
            user.Signature = (string)myReader["Signature"];
            myReader = eventInscriptionCommand.ExecuteReader();
            while (myReader.Read())
            {
              Inscription inscription = new Inscription();

              inscription.SetHeure((DateTime)myReader["EventHour"]);
              inscription.SetJeu((string)myReader["Game"]);
              inscription.SetPlancher((byte)myReader["Floor"]);

              user.inscriptions.Add(inscription);
            }

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
        lblErreurConnexion.Text = ex.Message;
      }
      finally
      {
        myConnection.Close();
        User userConnectedTest = (User)Session["user"];
        if (userConnectedTest != null)
        {
          Server.Transfer(HttpContext.Current.Request.Url.AbsolutePath);
        }
      }
    }

    protected void btnDeconnexion_Click(object sender, EventArgs e)
    {
      Session["user"] = null;
      Server.Transfer(HttpContext.Current.Request.Url.AbsolutePath);
    }

    protected void btnInscription_Click(object sender, EventArgs e)
    {
      Session["lastPage"] = HttpContext.Current.Request.Url.AbsolutePath;
    }
    protected void btnModifier_Click(object sender, EventArgs e)
    {
      Session["lastPage"] = HttpContext.Current.Request.Url.AbsolutePath;
      Server.Transfer("PageModification.aspx");
    }
}
