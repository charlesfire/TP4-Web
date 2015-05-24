/// <summary>
/// Fonction appelée lors de la validation du nombre minimum d'inscription à des matchs
/// </summary>
/// <param name="source"></param>
/// <param name="args"></param>
function validerNbMinInscription(source, args)
{
	// on considère qu'il n'y à pas d'inscriptions à la base
	args.IsValid = false;

	// On récupère l'élément contenant les inscriptions
	var cblInscriptions = document.getElementById("cblInscriptions");
	
	// Si l'élément qui contient les inscriptions existe...
	if (cblInscriptions)
	{
		// L'utilisateur a souscrit à au moins un match
		args.IsValid = true;
	}
}

/// <summary>
/// Fonction appelée lors de la validation vérifiant si l'utilisateur ne s'est pas inscrit
///    deux fois à la même heure le même jour
/// </summary>
/// <param name="source"></param>
/// <param name="args"></param>
function validerInscriptionsMemeHeure(source, args)
{
	// On considère à la base qu'il ne s'est pas inscrit deux fois à la même heure le même jour
	args.IsValid = true;

	// On récupère l'élément contenant les inscriptions
	var cblInscriptions = document.getElementById("cblInscriptions");

	// Si l'élément qui contient les inscriptions existe...
	if (cblInscriptions)
	{
		// on récupère l'heure du match que l'utilisateur veut ajouter
		var heure = document.getElementById("ddlHeure").value;

		// On récupère les inscriptions
		var inscriptions = cblInscriptions.getElementsByTagName("LABEL");

		// Variable contenant l'ensemble des inscriptions sous forme de chaine de caractère
		var chaineInscriptions = "";

		// On remplit la variable avec le nom de tous les matchs aux quels l'utilisateur a souscrit
		for (var i = 0; i < inscriptions.length; i++)
		{
			chaineInscriptions += inscriptions[i].innerHTML;
		}

		// Si l'utilisateur s'est déjà inscrit à un match la même date et la même heure...
		if (chaineInscriptions.match(new RegExp("Heure : " + heure)))
		{
			// Il ne peut pas s'inscrire
			args.IsValid = false;
		}
	}
}

/// <summary>
/// Fonction appelée lors de la validation vérifiant si l'utilisateur s'est déjà inscrit à plus
///		de 3 match par plancher par jour
/// </summary>
/// <param name="source"></param>
/// <param name="args"></param>
function validerNbMaxInscriptionsParPlancher(source, args)
{
	// On considère à la base qu'il ne s'est pas inscrit à plus de 3 match par plancher par évènement
	args.IsValid = true;

	// On récupère l'élément contenant les inscriptions
	var cblInscriptions = document.getElementById("cblInscriptions");

	// Si l'élément qui contient les inscriptions existe...
	if (cblInscriptions)
	{
		// on récupère le plancher du match que l'utilisateur veut ajouter
		var plancher = "Plancher #" + document.getElementById("ddlPlancher").value;

		// On récupère les inscriptions
		var inscriptions = cblInscriptions.getElementsByTagName("LABEL");

		// Variable contenant l'ensemble des inscriptions sous forme de chaine de caractère
		var chaineInscriptions = "";

		// On remplit la variable avec le nom de tous les matchs aux quels l'utilisateur a souscrit
		for (var i = 0; i < inscriptions.length; i++)
		{
			chaineInscriptions += inscriptions[i].innerHTML;
		}

		// S'il a déjà 3 inscriptions pour le plancher sur lequel il veut ajouter un match...
		if (chaineInscriptions.match(new RegExp(plancher, "g")).length >= 3)
		{
			// Il ne peut pas s'inscrire
			args.IsValid = false;
		}
	}
}