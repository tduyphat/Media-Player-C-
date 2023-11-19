namespace MediaPlayer.Service.src.DTO;

using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class PlaylistReadDTO
{
  public readonly string Title;
  public readonly int ID;

  public PlaylistReadDTO(Playlist playlist)
  {
    Title = playlist.Title;
    ID = playlist.ID;
  }
}