using System;
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
  public int PostNumber
  {
    get;
    set;
  }

  public string BuildLitteral()
  {
    string litteral = "  <div id=\"pnlSujet\" style=\"border-style:Solid;\"><a id=\""+Title+"\" href=\"PageDiscussion.aspx\">"+Title+"</a>&nbsp&nbsp&nbsp;"+CreationDate+"&nbsp&nbsp&nbsp Créé par: "+Username+"<br /> &nbsp&nbsp&nbsp;Nb repliques: "+NbPosts+"&nbsp&nbsp&nbsp Derniere modification:"+LastPost+"&nbsp&nbsp&nbsp Par: "+LastPoster+"</div>";
    return litteral;
  }
}