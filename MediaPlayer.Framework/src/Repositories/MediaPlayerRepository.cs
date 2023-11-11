using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

namespace MediaPlayer.Framework.src.Repositories;

public class MediaPlayerRepository: IMediaPlayerRepo
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;

  public MediaPlayerRepository(Database database)
  {
    _mediaFiles = database.MediaFiles;
    _people = database.People;
  }

  public Dictionary<int, Media> GetAllMedia()
  {
    return _mediaFiles;
  }

  public Dictionary<int, Person> GetAllPeople()
  {
    return _people;
  }
}