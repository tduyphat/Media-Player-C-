namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;

public class MediaFilesService: IMediaFilesService
{
  private IMediaFilesRepo _repo;

  public MediaFilesService(IMediaFilesRepo repo)
  {
    _repo = repo;
  }

  public void GetAllMedia()
  {
    _repo.GetAllMedia();
  }
  public void AddAudio(string title, int duration, string artist)
  {
    _repo.AddAudio(title, duration, artist);
  }
  public void AddVideo(string title, int duration)
  {
    _repo.AddVideo(title, duration);
  }
  public void RemoveMedia(int id)
  {
    _repo.RemoveMedia(id);
  }

  public void UpdateAudio(int id, string title, string artist)
  {
    _repo.UpdateAudio(id, title, artist);
  }

  public void UpdateVideo(int id, string title)
  {
    _repo.UpdateVideo(id, title);
  }
}