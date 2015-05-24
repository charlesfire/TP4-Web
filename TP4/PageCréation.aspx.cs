using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class PageCréation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void PreRendre(object sender, EventArgs e)
    {
      User user = (User)Session["user"];
      if (user == null)
      {
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