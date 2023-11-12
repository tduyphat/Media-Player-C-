namespace MediaPlayer.Framework.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class Database
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;
  private Person? _currentPerson;
  private Playlist? _currentPlaylist;

  public Dictionary<int, Media> MediaFiles { get => _mediaFiles; set => _mediaFiles = value; }
  public Dictionary<int, Person> People { get => _people; set => _people = value; }
  public Person? CurrentPerson { get => _currentPerson; set => _currentPerson = value; }
  public Playlist? CurrentPlaylist { get => _currentPlaylist; set => _currentPlaylist = value; }

  public Database()
  {
    _mediaFiles = new Dictionary<int, Media>();
    _people = new Dictionary<int, Person>();
    _currentPerson = null;
    _currentPlaylist = null;
  }
}