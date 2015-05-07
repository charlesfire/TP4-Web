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
      ModifierBD("INSERT INTO Users (Username, [Password], PostCount, Email, Adresse) VALUES ('" + txtBUserName.Text + "','" + txtBPassword.Text + "'," + 0 + ",'" + txtBEmail.Text + "','" + txtBAdresse.Text + "');");
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
        Label1.Text = "Erreur de connection, veuillez réessayer plus tard";
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
}