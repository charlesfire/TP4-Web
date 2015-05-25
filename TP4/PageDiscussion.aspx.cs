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
      lblTitre.Text = sujet.Title;
      if ((Sujet)Session["sujet"] != null)
      {
        lblTitre.Text = sujet.Title;
      }
      else
      {
        ObtenirSujet("SELECT Title, StartedBy, DatePosted, NbPosts, LastPoster, LastPostTime, TopicNumber FROM Topics WHERE TopicNumber=" + Request.QueryString["topicNumber"]);
      }
    }
    protected void pnlMessage_PreRender(object sender, EventArgs e)
    {
      if ((User)Session["user"] == null)
      {
        pnlMessage.Visible = false;
      }
      else
      {
        pnlMessage.Visible = true;
      }
    }
    protected void lblTitre_Unload(object sender, EventArgs e)
    {
      Session["sujet"] = sujet;
    }
    protected void btnSoumettre_Click(object sender, EventArgs e)
    {
      User user = (User)Session["user"];
      sujet = (Sujet)Session["sujet"];
      DataBaseHelper.ModifierBD("INSERT INTO Posts (TopicNumber,UserName,Body,DatePosted) VALUES (" + sujet.PostNumber + ",'" + user.Name + "','" + txtbMessage.Text + "',#" + DateTime.Now + "#);",Server);
      user.PostCount++;
      DataBaseHelper.ModifierBD("UPDATE Users SET PostCount="+user.PostCount+";",Server);
      Session["user"] = user;
    }
}