namespace MediaPlayer.Controller.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

public class MediaPlayerController
{
  private IMediaPlayerService _mediaPlayerService;

  public MediaPlayerController(IMediaPlayerService service)
  {
    _mediaPlayerService = service;
  }

  public bool Login(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _mediaPlayerService.Login(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool Logout()
  {
    return _mediaPlayerService.Logout();
  }

  public List<PlaylistReadDTO> GetAllPlaylists()
  {
    return _mediaPlayerService.GetAllPlaylists();
  }

  public List<MediaInPlaylistReadDTO> GetAllMediaInPlaylist(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _mediaPlayerService.GetAllMediaInPlaylist(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool CreatePlaylist(object option)
  {
    try
    {
      string title = string.Format("{0}", option);
      return _mediaPlayerService.CreatePlaylist(title);
    }
    catch
    {
      throw new ArgumentException("Title must be a string.");
    }
  }

  public bool RemovePlaylist(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _mediaPlayerService.RemovePlaylist(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool AddMediaToPlaylist(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int mediaID);
      int.TryParse(options[1].ToString(), out int playlistID);
      return _mediaPlayerService.AddMediaToPlaylist(mediaID, playlistID);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool RemoveMediaFromPlaylist(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int mediaID);
      int.TryParse(options[1].ToString(), out int playlistID);
      return _mediaPlayerService.RemoveMediaFromPlaylist(mediaID, playlistID);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }
}
