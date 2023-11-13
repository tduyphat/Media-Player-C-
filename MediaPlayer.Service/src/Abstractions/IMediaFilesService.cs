namespace MediaPlayer.Service.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public interface IMediaFilesService
{
  void GetAllMedia();
  void AddAudio(string title, int duration, string artist);
  void AddVideo(string title, int duration);
  void RemoveMedia(int id);
  void UpdateAudio(int id, string title, string artist);
  void UpdateVideo(int id, string title);
}