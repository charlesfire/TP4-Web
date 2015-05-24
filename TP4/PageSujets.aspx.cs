using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageSujets : System.Web.UI.Page
{
  Sujet sujet = new Sujet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ConstruireLiteralSujets(string requeteRecue)
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
          LtlSujets.Text = "";
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
            LtlSujets.Text += sujet.BuildLitteral();
          }
        }
        catch(Exception ex)
        {
          throw ex;
        }
        finally
        {
          connection.Close();
        }
      }
    }
    protected void PreRender(object sender, EventArgs e)
    {
      ConstruireLiteralSujets("SELECT Title, StartedBy, DatePosted, NbPosts, LastPoster, LastPostTime FROM Topics ORDER BY LastPostTime DESC;");
      User user = (User)Session["user"];
      if (user != null)
      {
        btnTopCreerSujet.Visible = true;
        btnBottomCreerSujet.Visible = true;
      }
    }
    protected void btnCreerSujet_Click(object sender, EventArgs e)
    {
      Server.Transfer("PageCréation.aspx");
    }
    protected void Unload(object sender, EventArgs e)
    {
      Session["lastPage"] = HttpContext.Current.Request.Url.AbsolutePath;
    }
}