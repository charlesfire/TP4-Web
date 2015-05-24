using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

public partial class PageÉvènement : System.Web.UI.Page
{
  /// <summary>
  /// Variable contenant une liste de nombres de plancher associées à des jeux
  /// </summary>
  private SortedDictionary<string, int> planchersParJeu = new SortedDictionary<string, int>();

  private User user = null;

  /// <summary>
  /// Fonction appelée lors du chargement/rechargement/postback de la page
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void Page_LoadComplete(object sender, EventArgs e)
  {
    user = (User)Session["user"];
    if (user == null)
    {
      Response.Redirect("tp4.aspx", false);
    }

    // Si le conteneur associatif des planchers/jeux est vide...
    if (planchersParJeu.Count == 0)
    {
      // On le remplit			
      planchersParJeu.Add("League of Legends : Summoner's Rift", 6);
      planchersParJeu.Add("League of Legends : Crystal Scar", 2);
      planchersParJeu.Add("League of Legends : Howling Abyss", 4);
      planchersParJeu.Add("Minecraft : Hunger Games", 3);
      planchersParJeu.Add("DOTA 2", 5);
      planchersParJeu.Add("Team Fortress 2", 4);
      planchersParJeu.Add("Counter-Strike", 3);
      planchersParJeu.Add("Quake III", 2);
      planchersParJeu.Add("Minecraft Artistic Challenge", 1);
    }

    // Si le contrôle permettant de sélectionner un jeu est vide...
    if (ddlJeu.Items.Count == 0)
    {
      // On le remplit de tous les jeux disponibles
      foreach (string jeu in planchersParJeu.Keys)
      {
        ddlJeu.Items.Add(jeu);
      }
    }

    // On génère les heures de matchs
    GenererHeuresDisponibles();

    // On met à jours les planchers disponibles
    MettreAJourPlancher();

    // Si le nombre d'inscription réel est différent de celui afficher...
    if (user.inscriptions.Count != cblInscriptions.Items.Count)
    {
      // On efface les inscriptions présentes
      cblInscriptions.Items.Clear();

      // On génère à nouveaux les inscription à afficher
      foreach (Inscription inscription in user.inscriptions)
      {
        cblInscriptions.Items.Add(inscription.ToString());
      }

      // On affiche les inscriptions
      pnlEditionInscription.Visible = true;
    }
  }

  /// <summary>
  /// Fonction appelée lors d'un clique sur le bouton modifier
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnModifier_Click(object sender, EventArgs e)
  {
    // On inverse la possibilité de cocher les cases à cocher
    cblInscriptions.Enabled = !cblInscriptions.Enabled;

    // On affiche ou on cache le bouton de supression
    btnSuprimerSelection.Visible = cblInscriptions.Enabled;

    // Si on est entrain de modifier les inscriptions...
    if (cblInscriptions.Enabled)
    {
      // On change le texte du bouton "Modifier"
      btnModifier.Text = "Annuler";
    }
    else
    {
      // On change le texte du bouton "Annuler"
      btnModifier.Text = "Modifier";
    }
  }

  /// <summary>
  /// Fonction appelée lors d'un clique sur le bouton suprimer
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnSuprimerSelection_Click(object sender, EventArgs e)
  {
    // Tant qu'il reste un élément coché...
    while (cblInscriptions.SelectedItem != null)
    {
      // On le suprime
      user.inscriptions.RemoveAt(cblInscriptions.SelectedIndex);

      // on suprime l'inscription correspondante
      cblInscriptions.Items.RemoveAt(cblInscriptions.SelectedIndex);
    }

    // On remmet le bouton "Modifier" à son état normal
    btnModifier.Text = "Modifier";

    // On désactive les cases à cocher
    cblInscriptions.Enabled = false;

    // On cache le bouton de suppression
    btnSuprimerSelection.Visible = false;

    // S'il ne reste plus aucune inscription...
    if (user.inscriptions.Count == 0)
    {
      // On cache l'espace des inscriptions
      pnlEditionInscription.Visible = false;
    }
  }

  /// <summary>
  /// Fonction appelée lorsque l'utilisateur sélectionne un jeu
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void ddlJeu_SelectedIndexChanged(object sender, EventArgs e)
  {
    // On met à jours les planchers disponibles
    MettreAJourPlancher();
  }

  /// <summary>
  /// Fonction appelée lorsque l'utilisateur clique sur le bouton "Ajouter"
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnAjouter_Click(object sender, EventArgs e)
  {
    // On vérifie que les entrés de l'utilisateur sont valides
    Page.Validate("validerAjoutInscription");

    // Si les entrés de l'utilisateur sont valide...
    if (Page.IsValid)
    {
      // On ajoute une nouvelle inscription
      Inscription nouvelleInscription = new Inscription();

      nouvelleInscription.SetJeu(ddlJeu.SelectedValue);
      nouvelleInscription.SetPlancher(int.Parse(ddlPlancher.SelectedValue));

      // On ajoute visuellement à la page l'inscription
      cblInscriptions.Items.Add(nouvelleInscription.ToString());

      // On ajout l'inscription à la liste des inscriptions
      user.inscriptions.Add(nouvelleInscription);

      // On rend les inscriptions visibles
      pnlEditionInscription.Visible = true;
    }
  }

  /// <summary>
  /// Fonction appelée lorsque l'utilisateur clique sur le bouton "Annuler"
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnAnnuler_Click(object sender, EventArgs e)
  {
    // On recharge la page pour effacer tout le reste
    Response.Redirect((string)Session["lastPage"], false);
  }

  /// <summary>
  /// Fonction appelée lorsque l'utilisateur clique sur le bouton "Comfirmer"
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnConfirmer_Click(object sender, EventArgs e)
  {
    // On vérifie que les entrés de l'utilisateur sont valides
    Page.Validate("validerDocument");

    // Si les entrés sont valide...
    if (Page.IsValid)
    {
      // On sauvegarde les informations pertinentes dans des variables de session
      Session["user"] = user;

      //ToDo : save in database

      // On charge la page de résumé
      Response.Redirect("Resume.aspx", false);
    }
  }

  /// <summary>
  /// Fonction appelée lors de la validation du nombre minimum d'inscription à des matchs
  /// </summary>
  /// <param name="source"></param>
  /// <param name="args"></param>
  protected void cvNbMinimumMatch_ServerValidate(object source, ServerValidateEventArgs args)
  {
    // Si l'utilisateur n'as pas sourcrit à au moins un match, il ne peut pas continuer
    args.IsValid = user.inscriptions.Count >= 1;
  }

  /// <summary>
  /// Fonction appelée lors de la validation vérifiant si l'utilisateur ne s'est pas inscrit
  ///    deux fois à la même heure le même jour
  /// </summary>
  /// <param name="source"></param>
  /// <param name="args"></param>
  protected void cvInscriptionsMemeHeure_ServerValidate(object source, ServerValidateEventArgs args)
  {
    // On considère à la base qu'il ne s'est pas inscrit deux fois à la même heure le même jour
    args.IsValid = true;

    // On récupère la date et l'heure à laquelle l'utilisateur souhaite ajouter un match
    DateTime heure = new DateTime();
    if (DateTime.TryParse(ddlHeure.SelectedValue, out heure))
    {
      // Pour chaque inscription...
      for (int i = 0; i < user.inscriptions.Count; i++)
      {
        // Si l'inscription est à la même date
        if (user.inscriptions[i].GetHeure() == heure)
        {
          // L'utilisateur ne peut pas s'inscrire (à moins qu'il puisse se diviser en deux XD)
          args.IsValid = false;
        }
      }
    }
  }

  /// <summary>
  /// Fonction appelée lors de la validation vérifiant si l'utilisateur s'est déjà inscrit à plus
  ///		de 3 match par plancher par jour
  /// </summary>
  /// <param name="source"></param>
  /// <param name="args"></param>
  protected void cvNbMaxInscriptionsParPlancher_ServerValidate(object source, ServerValidateEventArgs args)
  {
    // On considère à la base qu'il ne s'est pas inscrit à plus de 3 match par plancher par évènement
    args.IsValid = true;

    // On récupère le numéro du plancher sur lequel il souhaite s'inscrire
    int numeroPlancher = int.Parse(ddlPlancher.SelectedValue);

    // Le nombre d'incription qu'il as pour le plancher sur lequel il veut ajouter un match
    int nbInscription = 0;

    // Pour chaque inscription...
    for (int i = 0; i < user.inscriptions.Count; i++)
    {
      // Si elles sont le même jour et sur le même plancher...
      if (user.inscriptions[i].GetPlancher() == numeroPlancher)
      {
        // On augmente le nombre d'incription qu'il as pour le plancher sur lequel il veut ajouter un match
        nbInscription++;
      }
    }

    // S'il a déjà 3 inscriptions pour le plancher sur lequel il veut ajouter un match...
    if (nbInscription >= 3)
    {
      // Il ne peut pas s'inscrire
      args.IsValid = false;
    }
  }

  /// <summary>
  /// Met à jours le nombre de plancher disponible pour le jeu sélectionné
  /// </summary>
  private void MettreAJourPlancher()
  {
    // On efface le nombre de plancher disponible
    ddlPlancher.Items.Clear();

    // On récupère le nombre de plancher disponible
    int nombreDePlancher = 0;
    if (planchersParJeu.TryGetValue(ddlJeu.SelectedValue, out nombreDePlancher))
    {
      // Pour chaque plancher disponible...
      for (int i = 1; i <= nombreDePlancher; i++)
      {
        // On ajoute la posibilité de sélectionner ce plancher
        ddlPlancher.Items.Add(i.ToString());
      }
    }
  }

  /// <summary>
  /// Génère les heures disponibles
  /// </summary>
  private void GenererHeuresDisponibles()
  {
    // On efface les heures disponibles
    ddlHeure.Items.Clear();

    // On ajoute les heures disponibles
    DateTime heureDisponible = new DateTime(1, 1, 1, 13, 0, 0);
    heureDisponible.AddHours(13);
    for (int i = 0; i < 8; i++)
    {
      ddlHeure.Items.Add(heureDisponible.ToShortTimeString());
      heureDisponible = heureDisponible.AddHours(2);
    }
  }
}