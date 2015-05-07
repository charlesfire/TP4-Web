using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageInscription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConfirmer_Click(object sender, EventArgs e)
    {
      ModifierBD("INSERT INTO User (Username, Password, PostCount, Email, Adresse) VALUES ('" + txtBUserName.Text + "','" + txtBPassword.Text + "'," + 0 + ",'" + txtBEmail.Text + "','" + txtBAdresse.Text + "');");
    }

    private void ModifierBD(string requeteSQL)
    {
      string yolo = "INSERT INTO User (Username, Password, PostCount, Email, Adresse) VALUES ('" + txtBUserName.Text + "', '" + txtBPassword.Text + "', " + 0 + ", '" + txtBEmail.Text + "', '" + txtBAdresse.Text + "');";
      Label2.Text = yolo;
      OleDbConnection maConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"Forum DB/Forum.accdb"));
      OleDbCommand maCommande = new OleDbCommand(requeteSQL, maConnection);
      bool connectionReussie = false;
      try
      {
        maConnection.Open();
        connectionReussie = true;
      }
      catch (Exception excep)
      {
        Label1.Text = "Erreur de connection: " + excep.Message;
      }

      if (connectionReussie)
      {
        try
        {
          maCommande.ExecuteNonQuery();
        }
        catch (Exception excep)
        {
          Label1.Text = "Erreur de requête: " + excep.Message;
        }
        finally
        {
          maConnection.Close();
        }
      }
    }
}