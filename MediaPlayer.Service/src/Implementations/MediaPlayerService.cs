namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;

public class MediaPlayerService: IMediaPlayerService
{
  private IMediaPlayerRepo _repo;

  public MediaPlayerService(IMediaPlayerRepo repo)
  {
    _repo = repo;
  }

  public void Login(int id)
  {
    _repo.Login(id);
  }

  public void Logout()
  {
    _repo.Logout();
  }

  public void GetAllPlaylists()
  {
    _repo.GetAllPlaylists();
  }

  public void GetAllMediaInPlaylist(int id)
  {
    _repo.GetAllMediaInPlaylist(id);
  }

  public void CreatePlaylist(string title)
  {
    _repo.CreatePlaylist(title);
  }

  public void RemovePlaylist(int id)
  {
    _repo.RemovePlaylist(id);
  }

  public void AddMediaToPlaylist(int mediaID, int playlistID)
  {
    _repo.AddMediaToPlaylist(mediaID, playlistID);
  }

  public void RemoveMediaFromPlaylist(int mediaID, int playlistID)
  {
    _repo.RemoveMediaFromPlaylist(mediaID, playlistID);
  }
}
