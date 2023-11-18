namespace MediaPlayer.Core.src.Entities.PlaylistEntities;

public class AudioInPlaylist : MediaInPlaylist
{
  private string _artist;
  private int _volume;

  private SoundEffect _soundEffect;

  public string Artist { get => _artist; set => _artist = value; }
  public int Volume { get => _volume; set => _volume = value; }

  public SoundEffect SoundEffect { get => _soundEffect; set => _soundEffect = value; }

  public AudioInPlaylist(string title, int duration, string artist) : base(title, duration)
  {
    _artist = artist;
    _volume = 100;
  }
}

public enum SoundEffect
{
  Flat,
  Bass,
  Treb,
  Mid,
}