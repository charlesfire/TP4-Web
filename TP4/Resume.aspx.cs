using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Resume : System.Web.UI.Page
{
  /// <summary>
  /// Événement produit lors du chargement de la page
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void Page_Load(object sender, EventArgs e)
  {
    User user = (User)Session["user"];
    if (user == null)
    {
      Response.Redirect("tp4.aspx");
    }

    // On affiche le nom/prénom/numéro de participant du membre ayant souscrit à des matchs
    lblPrenom.Text = user.Name;

    // On affiche la date et l'heure actuelle
    lblDate.Text = DateTime.Now.ToLongDateString() + " à " + DateTime.Now.ToShortTimeString();

    // Si les incriptions existent...
    if (user.inscriptions != null)
    {
      // on parcours les user.inscriptions
      foreach (Inscription inscription in user.inscriptions)
      {
        // On ajoute une ligne au tableau
        TableRow nouvelleLigne = new TableRow();

        // On ajoute la cellule de l'évènement
        TableCell nouvelleCellule = new TableCell();

        // On ajoute la cellule du jeu
        nouvelleCellule = new TableCell();
        nouvelleCellule.Text = inscription.GetJeu();
        nouvelleLigne.Cells.Add(nouvelleCellule);

        // On ajoute la cellule du plancher
        nouvelleCellule = new TableCell();
        nouvelleCellule.Text = "#" + inscription.GetPlancher();
        nouvelleLigne.Cells.Add(nouvelleCellule);

        // On ajoute la cellule de l'heure
        nouvelleCellule = new TableCell();
        nouvelleCellule.Text = inscription.GetHeure().ToShortTimeString();
        nouvelleLigne.Cells.Add(nouvelleCellule);

        // On ajoute au tableau la nouvelle ligne
        tbInscriptions.Rows.Add(nouvelleLigne);
      }
    }
  }

  /// <summary>
  /// Événement produit lors d'un clique sur le boutton "Retour"
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnRetour_Click(object sender, EventArgs e)
  {
    // On retourne à la page principale
    Response.Redirect("tp4.aspx");
  }
}