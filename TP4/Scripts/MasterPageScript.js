function onConnectClick ()
{
  document.getElementById("divConnexion").style.display = "block";
}

function onMasterLoad()
{
  if (document.getElementById("lblErreurConnexion").innerHTML != "")
  {
    document.getElementById("divConnexion").style.display = "block";
  }

  setTimeout(function ()
  {
    document.getElementById("pnlConnexionReussie").style.opacity = 0;
  }, 3000);
}
