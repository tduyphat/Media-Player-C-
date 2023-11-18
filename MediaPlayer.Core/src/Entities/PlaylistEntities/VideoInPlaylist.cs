namespace MediaPlayer.Core.src.Entities.PlaylistEntities;

public class VideoInPlaylist : MediaInPlaylist
{
  private int _brightness;

  public int Brightness { get => _brightness; set => _brightness = value; }
  public VideoInPlaylist(string title, int duration) : base(title, duration)
  {
    _brightness = 100;
  }
}