namespace MediaPlayer.Service.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.DTO;

public interface IMediaPlayerService
{
  bool Login(int id);
  bool Logout();
  List<PlaylistReadDTO> GetAllPlaylists();
  List<MediaInPlaylistReadDTO> GetAllMediaInPlaylist(int id);
  bool CreatePlaylist(string title);
  bool RemovePlaylist(int id);
  bool AddMediaToPlaylist(int mediaID, int playlistID);
  bool RemoveMediaFromPlaylist(int mediaID, int playlistID);
}