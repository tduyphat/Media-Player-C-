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
