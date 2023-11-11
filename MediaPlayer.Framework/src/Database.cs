namespace MediaPlayer.Framework.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public class Database
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;

  public Dictionary<int, Media> MediaFiles { get => _mediaFiles; set => _mediaFiles = value; }
  public Dictionary<int, Person> People { get => _people; set => _people = value; }

  public Database()
  {
    _mediaFiles = new Dictionary<int, Media>();
    _people = new Dictionary<int, Person>();
  }
}