using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      if (Session["LastPage"] != null)
        Response.Redirect((string)Session["LastPage"]);
      else
        Response.Redirect("tp4.aspx");
    }
}