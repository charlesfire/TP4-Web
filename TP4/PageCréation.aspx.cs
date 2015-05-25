using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageCréation : System.Web.UI.Page
{
  int topicNumber = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void PreRendre(object sender, EventArgs e)
    {
      User user = (User)Session["user"];
      if (user == null)
      {
        //Si l'utilisateur n'est pas connecté il ne doit pas être capable d'utiliser la page
        pnlCreation.Visible = false;
        pnlNestPasConnecte.Visible = true;
      }
    }
    protected void btnAnnuler_Click(object sender, EventArgs e)
    {
      Response.Redirect((string)Session["LastPage"]);
    }
    protected void btnSoumettre_Click(object sender, EventArgs e)
    {
      User user = (User)Session["user"];
      DataBaseHelper.ModifierBD("INSERT INTO Topics (Title,LastPostTime,StartedBy,DatePosted,LastPoster,NbPosts) VALUES ('" + txtbSujet.Text+"',#" + DateTime.Now + "#,'" + user.Name + "',#" +DateTime.Now+"#,'"+user.Name+ "'," + 0 + ");",Server);
      SelectionBD("Select TopicNumber FROM Topics WHERE (Title = '" + txtbSujet.Text + "'AND DatePosted =#"+DateTime.Now+"#);");
      DataBaseHelper.ModifierBD("INSERT INTO Posts (TopicNumber,UserName,Body,DatePosted) VALUES ("+topicNumber+",'"+user.Name+"','"+txtbContenu.Text+"',#"+DateTime.Now+"#);",Server);
      if (Session["LastPage"] == null)
        Response.Redirect("PageSujets.aspx");
      else
        Response.Redirect((string)Session["LastPage"]);
    }
    public void SelectionBD(string requeteRecue)
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
          while (monDataReader.Read())
          {
            topicNumber = (int)monDataReader[0];
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
}