namespace MediaPlayer.Controller.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

public class MediaFilesController
{
  private IMediaFilesService _mediaFilesService;

  public MediaFilesController(IMediaFilesService service)
  {
    _mediaFilesService = service;
  }

  public List<MediaReadDTO> GetAllMedia()
  {
    return _mediaFilesService.GetAllMedia();
  }

  public MediaReadDTO GetMediaByID(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _mediaFilesService.GetMediaByID(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool AddAudio(params object[] options)
  {
    try
    {
      string title = string.Format("{0}", options[0]);
      int.TryParse(options[1].ToString(), out int duration);
      string artist = string.Format("{0}", options[2]);
      return _mediaFilesService.AddAudio(title, duration, artist);
    }
    catch
    {
      throw new ArgumentException("Title must be a string, duration must be an integer and artist must be a string.");
    }
  }

  public bool AddVideo(params object[] options)
  {
    try
    {
      string title = string.Format("{0}", options[0]);
      int.TryParse(options[1].ToString(), out int duration);
      return _mediaFilesService.AddVideo(title, duration);
    }
    catch
    {
      throw new ArgumentException("Title must be a string and duration must be an integer.");
    }
  }

  public bool RemoveMedia(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _mediaFilesService.RemoveMedia(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool UpdateAudio(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string title = string.Format("{0}", options[1]);
      string artist = string.Format("{0}", options[2]);
      return _mediaFilesService.UpdateAudio(id, title, artist);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, title must be a string and artist must be a string.");
    }
  }

  public bool UpdateVideo(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string title = string.Format("{0}", options[1]);
      return _mediaFilesService.UpdateVideo(id, title);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, title must be a string.");
    }
  }
}