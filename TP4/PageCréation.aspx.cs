using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageCréation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void PreRendre(object sender, EventArgs e)
    {
      User user = (User)Session["user"];
      if (user == null)
      {
        pnlCreation.Visible = false;
        pnlNestPasConnecte.Visible = true;
      }
    }
    protected void btnAnnuler_Click(object sender, EventArgs e)
    {
      Response.Redirect((string)Session["LastPage"]);
    }
}