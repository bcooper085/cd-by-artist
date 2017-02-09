using System;
using System.Collections.Generic;
using Nancy;
using CD_Organizer.Objects;

namespace CD_Organizer
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Post["/artist_add_form"] = _ =>{
        Artist newArtist = new Artist(Request.Form["new-artist-name"]);
        return View["artist-added.cshtml", newArtist];
      };
      Post["/{id}/artist_info"] = parameter => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameter.id);
        List<CD> artistCds = selectedArtist.GetCd();
        string cdTitle = Request.Form["new-cd-title"];
        CD newCd = new CD(cdTitle);
        artistCds.Add(newCd);
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCds);
        return View["artist_info.cshtml", model];
      };
      Post["/search_result"] = _ => {
        List<int> matchId = Artist.SearchArtist(Request.Form["artist-name"]);
        if (matchId.Any()) {
          foreach(int id in matchId){
          Dictionary<string, object> model = new Dictionary<string, object>();
          Artist selectedArtist = Artist.Find(id);
          List<CD> artistCds = selectedArtist.GetCd();
          model.Add("artist", selectedArtist);
          model.Add("cds", artistCds);
          model.Add("titleofcd", cd)
          return View["artist_info.cshtml", model];
        }else{
          return View["not-found.cshtml"];
        }
      };
    }
  }
}
