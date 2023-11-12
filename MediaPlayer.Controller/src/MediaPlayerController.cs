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

  public void GetAllMedia()
  {
    _mediaPlayerService.GetAllMedia();
  }

  public void GetAllPeople()
  {
    _mediaPlayerService.GetAllPeople();
  }

  public void Login(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      _mediaPlayerService.Login(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public void Logout()
  {
    _mediaPlayerService.Logout();
  }

  public void AddAudio(params object[] options)
  {
    try
    {
      string title = string.Format("{0}", options[0]);
      int.TryParse(options[1].ToString(), out int duration);
      string artist = string.Format("{0}", options[2]);
      _mediaPlayerService.AddAudio(title, duration, artist);
    }
    catch
    {
      throw new ArgumentException("Title must be a string and duration must be an integer.");
    }
  }

  public void AddVideo(params object[] options)
  {
    try
    {
      string title = string.Format("{0}", options[0]);
      int.TryParse(options[1].ToString(), out int duration);
      _mediaPlayerService.AddVideo(title, duration);
    }
    catch
    {
      throw new ArgumentException("Title must be a string and duration must be an integer.");
    }
  }

  public void RemoveMedia(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      _mediaPlayerService.RemoveMedia(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }
}
