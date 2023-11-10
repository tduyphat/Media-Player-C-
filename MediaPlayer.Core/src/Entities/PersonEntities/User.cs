namespace MediaPlayer.Core.src.Entities.PersonEntities;

using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class User : Person
{
  private Dictionary<int, Playlist> _playlists;

  public Dictionary<int, Playlist> Playlists { get => _playlists; set => _playlists = value; }

  public User(string name) : base(name)
  {
    _playlists = new Dictionary<int, Playlist>();
  }
}