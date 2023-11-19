namespace MediaPlayer.Service.src.DTO;

using MediaPlayer.Core.src.Entities.MediaEntities;

public class MediaReadDTO
{
  public readonly string Title;
  public readonly int ID;

  public MediaReadDTO(Media media)
  {
    Title = media.Title;
    ID = media.ID;
  }

  public override string ToString()
  {
    return $"Title: {Title}, ID: {ID}";
  }
}