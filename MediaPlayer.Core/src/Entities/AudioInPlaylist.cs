namespace MediaPlayer.Core.src.Entities;

public class AudioInPlaylist : MediaInPlaylist
{
  private string _artist;

  public string Artist { get => _artist; set => _artist = value; }

  public AudioInPlaylist(string title, int duration, string artist) : base(title, duration)
  {
    _artist = artist;
  }
}