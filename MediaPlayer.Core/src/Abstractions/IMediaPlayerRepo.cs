using MediaPlayer.Core.src.Entities.PlaylistEntities;

namespace MediaPlayer.Core.src.Abstractions;

public interface IMediaPlayerRepo
{
  bool Login(int id);
  bool Logout();
  List<Playlist> GetAllPlaylists();
  Playlist GetPlaylistByID(int id);
  List<MediaInPlaylist> GetAllMediaInPlaylist(int id);
  bool CreatePlaylist(string title);
  bool RemovePlaylist(int id);
  bool AddMediaToPlaylist(int mediaID, int playlistID);
  bool RemoveMediaFromPlaylist(int mediaID, int playlistID);
}