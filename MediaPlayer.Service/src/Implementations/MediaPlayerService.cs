namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;

public class MediaPlayerService: IMediaPlayerService
{
  private IMediaPlayerRepo _repo;

  public MediaPlayerService(IMediaPlayerRepo repo)
  {
    _repo = repo;
  }

  public Dictionary<int, Media> GetAllMedia()
  {
    return _repo.GetAllMedia();
  }

  public Dictionary<int, Person> GetAllPeople()
  {
    return _repo.GetAllPeople();
  }
}
