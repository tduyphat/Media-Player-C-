namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

public class MediaPlayerService : IMediaPlayerService
{
  private IMediaPlayerRepo _repo;

  public MediaPlayerService(IMediaPlayerRepo repo)
  {
    _repo = repo;
  }

  public bool Login(int id)
  {
    return _repo.Login(id);
  }

  public bool Logout()
  {
    return _repo.Logout();
  }

  public List<PlaylistReadDTO> GetAllPlaylists()
  {
    var allPlaylists = _repo.GetAllPlaylists();
    return allPlaylists.Select((playlist) => new PlaylistReadDTO(playlist)).ToList();
  }

  public List<MediaInPlaylistReadDTO> GetAllMediaInPlaylist(int id)
  {
    var allMediaInPlaylist = _repo.GetAllMediaInPlaylist(id);
    return allMediaInPlaylist.Select((mediaInPlaylist) => new MediaInPlaylistReadDTO(mediaInPlaylist)).ToList();
  }

  public bool CreatePlaylist(string title)
  {
    return _repo.CreatePlaylist(title);
  }

  public bool RemovePlaylist(int id)
  {
    return _repo.RemovePlaylist(id);
  }

  public bool AddMediaToPlaylist(int mediaID, int playlistID)
  {
    return _repo.AddMediaToPlaylist(mediaID, playlistID);
  }

  public bool RemoveMediaFromPlaylist(int mediaID, int playlistID)
  {
    return _repo.RemoveMediaFromPlaylist(mediaID, playlistID);
  }
}
