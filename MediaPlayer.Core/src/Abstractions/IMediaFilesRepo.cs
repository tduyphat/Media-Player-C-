using MediaPlayer.Core.src.Entities.MediaEntities;

namespace MediaPlayer.Core.src.Abstractions;

public interface IMediaFilesRepo
{
  List<Media> GetAllMedia();
  Media GetMediaByID(int id);
  bool AddAudio(string title, int duration, string artist);
  bool AddVideo(string title, int duration);
  bool RemoveMedia(int id);
  bool UpdateAudio(int id, string title, string artist);
  bool UpdateVideo(int id, string title);
}