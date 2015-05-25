using System.Data.OleDb;
using System.Web;

/// <summary>
/// Description résumée de DataBaseHelper
/// </summary>
public static class DataBaseHelper
{
  public static void ModifierBD(string requeteSQL, HttpServerUtility server)
  {
    OleDbConnection maConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + server.MapPath(@"Forum DB/Forum.accdb"));
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
        if (true) { }
      }
      finally
      {
        maConnection.Close();
      }
    }
  }
}