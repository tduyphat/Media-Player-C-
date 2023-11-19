namespace MediaPlayer.Framework.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public class Database
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;

  public Dictionary<int, Media> MediaFiles { get => _mediaFiles; set => _mediaFiles = value; }
  public Dictionary<int, Person> People { get => _people; set => _people = value; }

  private static readonly Lazy<Database> lazyInstance = new Lazy<Database>(() => new Database());
  public static Database Instance => lazyInstance.Value;

  public Database()
  {
    _mediaFiles = new Dictionary<int, Media>
    {
      {1, new Audio("sandstorm", 300, "darude")},
      {2, new Audio("dywc", 400, "shm")},
      {3, new Video("se7en", 700)},
      {4, new Video("gta6trailer", 600)},
    };
    _people = new Dictionary<int, Person>
    {
      { 1, new Admin("admin1") },
      { 2, new User("user1") },
      { 3, new User("user3") },
    };
  }
}