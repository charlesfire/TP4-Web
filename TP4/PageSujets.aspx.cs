using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageSujets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SelectionBD(string requeteRecue)
    {
      OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"StockHockey.accdb"));
      OleDbCommand commande = new OleDbCommand(requeteRecue, connection);
      bool connectionReussie = false;
      try
      {
        connection.Open();
        connectionReussie = true;
      }
      catch 
      {

      }
      if (connectionReussie)
      {
        try
        {
          OleDbDataReader monDataReader = commande.ExecuteReader();
          int nbrChamps = monDataReader.FieldCount;
          while (monDataReader.Read())
          {

          }
        }
        catch 
        {

        }
        finally
        {
          connection.Close();
        }
      }
    }
    protected void PreRender(object sender, EventArgs e)
    {
      //NOTE: Les lignes suivantes sont des tests et peuvent être supprimés. À la place, on pourrait faire un for qui cycle au travers de tout les éléments du tableau post dans la base de donnée (trié en ordre décroissant de date de derniere modification).
      Sujet sujet = new Sujet();
      sujet.LastPost = DateTime.Now;
      sujet.LastPoster = "Jojmaster";
      sujet.NbPosts = 0;
      sujet.Title = "Déclaration";
      sujet.CreationDate = DateTime.Now;
      sujet.Username = "Jojmaster";
      LtlSujets.Text += sujet.BuildLitteral(1);
      LtlSujets.Text += sujet.BuildLitteral(2);
      LtlSujets.Text += sujet.BuildLitteral(3);
    }
}