using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de DataBaseHelper
/// </summary>
public static class DataBaseHelper
{
  public static void ModifierBD(string requeteSQL)
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
      lblAvatar.Text = "Erreur de connection, veuillez réessayer plus tard";
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