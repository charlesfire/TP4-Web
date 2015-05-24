﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Sujet
/// </summary>
public class Sujet
{
	public Sujet()
	{

	}
  public string Title
  {
    get;
    set;
  }
  public DateTime LastPost
  {
    get;
    set;
  }
  public DateTime CreationDate
  {
    get;
    set;
  }
  public string Username
  {
    get;
    set;
  }
  public int NbPosts
  {
    get;
    set;
  }
  public string LastPoster
  {
    get;
    set;
  }

  public string BuildLitteral(int nbSujet)
  {
    //string litteral = "<asp:Panel ID=\"pnlSujet" +nbSujet+ "\" runat=\"se <asp:HyperLink ID=\""+Title+"\" runat=\"server\" NavigateUrl=\"~/PageDiscussion.aspx\">"+Title+"</asp:HyperLink>&nbsp;"+CreationDate+" Créé par: "+Username+"<br /> &nbsp;Nb repliques: "+NbPosts+" Derniere modification: "+LastPost+" Par: "+LastPoster+"</asp:Panel>";
    string litteral = "  <div id=\"pnlSujet\" style=\"border-style:Solid;\"><a id=\""+Title+"\" href=\"PageDiscussion.aspx\">"+Title+"</a>&nbsp;"+CreationDate+" Créé par: "+Username+"<br /> &nbsp;Nb repliques: "+NbPosts+" Derniere modification: LastPost Par: "+LastPoster+"</div>";
    return litteral;
  }
}