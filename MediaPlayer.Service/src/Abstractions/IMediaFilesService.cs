namespace MediaPlayer.Service.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.DTO;

public interface IMediaFilesService
{
  List<MediaReadDTO> GetAllMedia();
  MediaReadDTO GetMediaByID(int id);
  bool AddAudio(string title, int duration, string artist);
  bool AddVideo(string title, int duration);
  bool RemoveMedia(int id);
  bool UpdateAudio(int id, string title, string artist);
  bool UpdateVideo(int id, string title);
}