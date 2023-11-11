namespace MediaPlayer.Controller.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;

public class MediaPlayerController
{
  private IMediaPlayerService _mediaPlayerService;

  public MediaPlayerController(IMediaPlayerService service)
  {
    _mediaPlayerService = service;
  }

  public Dictionary<int, Media> GetAllMedia()
  {
    return _mediaPlayerService.GetAllMedia();
  }

  public Dictionary<int, Person> GetAllPeople()
  {
    return _mediaPlayerService.GetAllPeople();
  }
}
