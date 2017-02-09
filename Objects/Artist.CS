using System;
using System.Collections.Generic;

namespace CD_Organizer.Objects
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    private string _name;
    private int _id;
    private List<CD> _cd;

    public Artist(string artistName)
    {
      _name = artistName;
      _instances.Add(this);
      _id = _instances.Count;
      _cd = new List<CD>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public List<CD> GetCd()
    {
      return _cd;
    }

    public void AddCd(CD newCd)
    {
      _cd.Add(newCd);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void Clear()
    {
      _instances.Clear();
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId -1];
    }
  }
}