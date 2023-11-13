namespace MediaPlayer.Core.src.Abstractions;

public interface IMediaPlayerRepo
{
  void Login(int id);
  void Logout();
  void GetAllPlaylists();
  void GetAllMediaInPlaylist(int id);
  void CreatePlaylist(string title);
  void RemovePlaylist(int id);
  void AddMediaToPlaylist(int mediaID, int playlistID);
  void RemoveMediaFromPlaylist(int mediaID, int playlistID);
}