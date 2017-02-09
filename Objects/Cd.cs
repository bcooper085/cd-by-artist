using System;
using System.Collections.Generic;

namespace CD_Organizer.Objects
{
  public class CD
  {
    private string _title;

    public CD (string title)
    {
      _title = title;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }
  }
}
