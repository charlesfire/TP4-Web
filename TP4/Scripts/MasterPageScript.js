function onConnectClick ()
{
  document.getElementById("divConnexion").style.display = "block";
}

function onBtnFermerConnexionReussieClick()
{
  document.getElementById("pnlConnexionReussie").style.display = "none";
}

function onMasterLoad()
{
  if (document.getElementById("lblErreurConnexion").innerHTML != "")
    document.getElementById("divConnexion").style.display = "block";
}
