namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

public class MediaFilesService : IMediaFilesService
{
  private IMediaFilesRepo _repo;

  public MediaFilesService(IMediaFilesRepo repo)
  {
    _repo = repo;
  }

  public List<MediaReadDTO> GetAllMedia()
  {
    var allMedia = _repo.GetAllMedia();
    return allMedia.Select(media => new MediaReadDTO(media)).ToList();
  }
  public MediaReadDTO GetMediaByID(int id)
  {
    var media = _repo.GetMediaByID(id);
    return new MediaReadDTO(media);
  }
  public bool AddAudio(string title, int duration, string artist)
  {
    if (duration < 0)
    {
      throw new ArgumentException("Duration should not be negative.");
    }
    else
    {
      return _repo.AddAudio(title, duration, artist);
    }
  }
  public bool AddVideo(string title, int duration)
  {
    if (duration < 0)
    {
      throw new ArgumentException("Duration should not be negative.");
    }
    else
    {
      return _repo.AddVideo(title, duration);
    }
  }
  public bool RemoveMedia(int id)
  {
    return _repo.RemoveMedia(id);
  }

  public bool UpdateAudio(int id, string title, string artist)
  {
    return _repo.UpdateAudio(id, title, artist);
  }

  public bool UpdateVideo(int id, string title)
  {
    return _repo.UpdateVideo(id, title);
  }
}