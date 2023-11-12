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
      throw new ArgumentException("Title must be a string, duration must be an integer and artist must be a string.");
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

  public void UpdateAudio(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string title = string.Format("{0}", options[1]);
      string artist = string.Format("{0}", options[2]);
      _mediaPlayerService.UpdateAudio(id, title, artist);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, title must be a string and artist must be a string.");
    }
  }

  public void UpdateVideo(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string title = string.Format("{0}", options[1]);
      _mediaPlayerService.UpdateVideo(id, title);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, title must be a string.");
    }
  }

  public void AddUser(object option)
  {
    try
    {
      string name = string.Format("{0}", option);
      _mediaPlayerService.AddUser(name);
    }
    catch
    {
      throw new ArgumentException("Name must be a string.");
    }
  }

  public void AddAdmin(object option)
  {
    try
    {
      string name = string.Format("{0}", option);
      _mediaPlayerService.AddAdmin(name);
    }
    catch
    {
      throw new ArgumentException("Name must be a string.");
    }
  }

  public void RemovePerson(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      _mediaPlayerService.RemovePerson(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public void UpdatePerson(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string name = string.Format("{0}", options[1]);
      _mediaPlayerService.UpdatePerson(id, name);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, name must be a string.");
    }
  }

  public void GetAllPlaylists()
  {
    _mediaPlayerService.GetAllPlaylists();
  }

  public void GetAllMediaInPlaylist(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      _mediaPlayerService.GetAllMediaInPlaylist(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public void CreatePlaylist(object option)
  {
    try
    {
      string title = string.Format("{0}", option);
      _mediaPlayerService.CreatePlaylist(title);
    }
    catch
    {
      throw new ArgumentException("Title must be a string.");
    }
  }

  public void RemovePlaylist(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      _mediaPlayerService.RemovePlaylist(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public void AddMediaToPlaylist(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int mediaID);
      int.TryParse(options[1].ToString(), out int playlistID);
      _mediaPlayerService.AddMediaToPlaylist(mediaID, playlistID);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public void RemoveMediaFromPlaylist(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int mediaID);
      int.TryParse(options[1].ToString(), out int playlistID);
      _mediaPlayerService.RemoveMediaFromPlaylist(mediaID, playlistID);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }
}
