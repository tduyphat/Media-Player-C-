namespace MediaPlayer.Core.src.Entities.PlaylistEntities;

using MediaPlayer.Core.src.Entities.MediaEntities;

public class MediaInPlaylist : Media
{
  protected int _currentPosition;

  protected bool _isPlaying;

  public int CurrentPosition { get => _currentPosition; set => _currentPosition = value; }
  public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }

  public MediaInPlaylist(string title, int duration) : base(title, duration)
  {
    _currentPosition = 0;
    _isPlaying = false;
  }
}