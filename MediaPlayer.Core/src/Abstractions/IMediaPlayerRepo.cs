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
  void AddUser(string name);
  void AddAdmin(string name);
  void RemovePerson(int id);
  void UpdatePerson(int id, string name);
  void GetAllPlaylists();
  void GetAllMediaInPlaylist(int id);
  void CreatePlaylist(string title);
  void RemovePlaylist(int id);
  void AddMediaToPlaylist(int mediaID, int playlistID);
  void RemoveMediaFromPlaylist(int mediaID, int playlistID);
}