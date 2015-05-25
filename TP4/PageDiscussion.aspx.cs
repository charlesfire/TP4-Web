using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageDiscussion : System.Web.UI.Page
{
  Sujet sujet = new Sujet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void ObtenirSujet(string requeteRecue)
    {
      OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"Forum DB/Forum.accdb"));
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
            sujet.Title = monDataReader[0].ToString();
            sujet.Username = monDataReader[1].ToString();
            sujet.CreationDate = (DateTime)monDataReader[2];
            sujet.NbPosts = (short)monDataReader[3];
            sujet.LastPoster = monDataReader[4].ToString();
            sujet.LastPost = (DateTime)monDataReader[5];
            sujet.PostNumber = (int)monDataReader[6];
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
    protected void lblTitre_PreRender(object sender, EventArgs e)
    {
      ObtenirSujet("SELECT Title, StartedBy, DatePosted, NbPosts, LastPoster, LastPostTime, TopicNumber FROM Topics WHERE TopicNumber="+Request.QueryString["topicNumber"]);
      lblTitre.Text = sujet.Title;
    }
}