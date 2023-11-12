namespace MediaPlayer.Core.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public interface IMediaPlayerRepo
{
  void GetAllMedia();
  void GetAllPeople();
  void Login(int id);
  void Logout();
  void AddAudio(string title, int duration, string artist);
  void AddVideo(string title, int duration);
  void RemoveMedia(int id);
  void UpdateAudio(int id, string title, string artist);
  void UpdateVideo(int id, string title);
}