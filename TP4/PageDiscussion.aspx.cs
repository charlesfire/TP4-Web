using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageDiscussion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string topicNumber = Request.QueryString["topicNumber"];
      OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(@"Forum DB/Forum.accdb"));
      OleDbCommand topicCommand = new OleDbCommand("SELECT Topics.Title, Posts.Body, Posts.DatePosted, Users.Signature, Users.Avatar, Users.Username," +
                                                              " Users.PostCount FROM Users INNER JOIN (Topics INNER JOIN Posts ON Topics.TopicNumber = Posts.TopicNumber) ON " +
                                                              "(Users.Username = Topics.StartedBy) AND (Users.Username = Posts.Username) WHERE Topics.TopicNumber =" + topicNumber + ";", myConnection);
      try
      {
        myConnection.Open();
        OleDbDataReader myReader = topicCommand.ExecuteReader();

        while (myReader.Read())
        {
          TableRow row = new TableRow();

          TableCell cell = new TableCell();

          cell.Text = "<img src='Images/" + myReader["Avatar"] + "'></img><br/>";
          cell.Text += myReader["Username"] + "<br/>" + myReader["PostCount"] + "<br/>" + myReader["DatePosted"];

          row.Cells.Add(cell);

          cell = new TableCell();

          cell.Text = (string)myReader["Body"];
          cell.Text += "<hr/>" + myReader["Signature"];

          row.Cells.Add(cell);

          Table1.Rows.Add(row);
        }
      }
      finally
      {
        myConnection.Close();
      }
    }
}