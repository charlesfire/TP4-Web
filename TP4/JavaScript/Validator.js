/// <summary>
/// Fonction appelée lors de la validation du numéro du membre
/// </summary>
/// <param name="source"></param>
/// <param name="args"></param>
function validerNumeroMembre(source, args)
{
	// On récupère le prénom et le nom entré
	var prenom = document.getElementById("txtbPrenom").value;
	var nom = document.getElementById("txtbNom").value;

	// On considère que le numéro de membre n'est pas valide à la base
	args.IsValid = false;

	// Si l'utilisateur a rentré un nom et un prénom et que le numéro de membre est de la bonne longeur...
	if (prenom.length > 0 && nom.length > 0 && args.Value.length == 10)
	{
		// On génère une expression régulière pour vérifier si le numéro est valide
		var regexp = new RegExp(prenom[0] + nom[0] + "\\d{8}", "i");

		// Si le numéro est valide...
		if (args.Value.search(regexp) != -1)
		{
			args.IsValid = true;
		}
	}
}

/// <summary>
/// Fonction appelée lors de la validation du nombre maximal d'inscription par évènement
/// </summary>
/// <param name="source"></param>
/// <param name="args"></param>
function validerNbMaxIncriptionsParEvenement(source, args)
{
	// On considère qu'il n'y a pas plus de 6 match par évènement à la base
	args.IsValid = true;

	// On récupère l'élément contenant les inscriptions
	var cblInscriptions = document.getElementById("cblInscriptions");

	// Si l'élément qui contient les inscriptions existe...
	if (cblInscriptions)
	{
		// On récupère les inscriptions
		var inscriptions = cblInscriptions.getElementsByTagName("LABEL");

		// On récupère l'évènement sélectionné
		var evenementSelectionne = document.getElementById("lblEvenement");

		// Variable contenant l'ensemble des évènements sous forme de chaine de caractère
		var evenements = "";

		// On remplit la variable avec le nom de tous les évènements aux quels l'utilisateur a souscrit
		for (var i = 0; i < inscriptions.length; i++)
		{
			evenements += inscriptions[i].innerHTML.split(" | ")[0];
		}

		// Si l'utilisateur a déjà souscrit à 6 matchs pour cet évènement...
		if (evenements.match(new RegExp(evenementSelectionne.innerHTML, "g")).length >= 6)
		{
			// Il ne peut pas s'inscrire à un match de plus pour cet évènement
			args.IsValid = false;
		}
	}
}

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
		// on récupère la date et l'heure du match que l'utilisateur veut ajouter
		var date = $("#calendrierEvenement > tbody > tr:nth-child(1) > td > table > tbody > tr > td")[0].innerHTML;
		date = $("#calendrierEvenement a[style*='color:White']")[0].innerHTML + " " + date;
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
		if (chaineInscriptions.match(new RegExp("Date : " + date + " \\| Heure : " + heure)))
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
function validerNbMaxInscriptionsParPlancherParJour(source, args)
{
	// On considère à la base qu'il ne s'est pas inscrit à plus de 3 match par plancher par évènement
	args.IsValid = true;

	// On récupère l'élément contenant les inscriptions
	var cblInscriptions = document.getElementById("cblInscriptions");

	// Si l'élément qui contient les inscriptions existe...
	if (cblInscriptions)
	{
		// on récupère la date et le plancher du match que l'utilisateur veut ajouter
		var date = $("#calendrierEvenement > tbody > tr:nth-child(1) > td > table > tbody > tr > td")[0].innerHTML;
		date = "Date : " + $("#calendrierEvenement a[style*='color:White']")[0].innerHTML + " " + date;
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
		if (chaineInscriptions.match(new RegExp(plancher + " \\| " + date, "g")).length >= 3)
		{
			// Il ne peut pas s'inscrire
			args.IsValid = false;
		}
	}
}