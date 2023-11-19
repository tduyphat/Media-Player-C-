namespace MediaPlayer.Service.src.DTO;

using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class MediaInPlaylistReadDTO
{
  public readonly string Title;
  public readonly int ID;

  public MediaInPlaylistReadDTO(MediaInPlaylist mediaInPlaylist)
  {
    Title = mediaInPlaylist.Title;
    ID = mediaInPlaylist.ID;
  }

  public override string ToString()
  {
    return $"Title: {Title}, ID: {ID}";
  }
}