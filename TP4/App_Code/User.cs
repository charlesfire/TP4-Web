using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de User
/// </summary>
public class User
{
  public string Name
  {
    get;
    set;
  }

  public string Password
  {
    get;
    set;
  }

  public int PostCount
  {
    get
    {
      return PostCount;
    }

    set
    {
      if (value < 0)
        throw new ArgumentException("Post count can't be lesser than 0.");
      //PostCount = value;
    }
  }

  public bool IsAdmin
  {
    get;
    set;
  }

  public string Email
  {
    get;
    set;
  }

  public string Avatar
  {
    get;
    set;
  }

  public string Adresse
  {
    get;
    set;
  }

	public User()
	{

	}
}