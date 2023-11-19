namespace MediaPlayer.Framework.src.Repositories;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class MediaPlayerRepository : IMediaPlayerRepo
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;
  private Person? _currentPerson;
  private Playlist? _currentPlaylist;

  public MediaPlayerRepository(Database database)
  {
    _mediaFiles = database.MediaFiles;
    _people = database.People;
    _currentPerson = null;
    _currentPlaylist = null;
  }

  public bool Login(int id)
  {
    if (_people.TryGetValue(id, out Person? foundPersonWithId))
    {
      _currentPerson = foundPersonWithId;
      return true;
    }
    else
    {
      return false;
    }
  }

  public bool Logout()
  {
    if (_currentPerson is null)
    {
      return false;
    }
    else
    {
      _currentPerson = null;
      _currentPlaylist = null;
      return true;
    }
  }

  public List<Playlist> GetAllPlaylists()
  {
    if (_currentPerson is User user)
    {
      return user.Playlists.Values.ToList();
    }
    else
    {
      throw new Exception("You have to logged in as user to get all the playlists.");
    }
  }

  public Playlist GetPlaylistByID(int id)
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.TryGetValue(id, out Playlist? foundPlaylistWithID))
      {
        return foundPlaylistWithID;
      }
      else
      {
        throw new Exception("Playlist ID does not exist");
      }
    }
    else
    {
      throw new Exception("You have to logged in as user to read the playlist.");
    }
  }

  public List<MediaInPlaylist> GetAllMediaInPlaylist(int id)
  {
    var foundPlaylistWithID = GetPlaylistByID(id);
    if (foundPlaylistWithID is not null)
    {
      return foundPlaylistWithID.MediaFiles.Values.ToList();
    }
    else
    {
      throw new Exception("Can't get media in playlist.");
    }
  }

  public bool CreatePlaylist(string title)
  {
    if (_currentPerson is User user)
    {
      Playlist newPlaylist = new(title);
      user.Playlists.Add(newPlaylist.ID, newPlaylist);
      return true;
    }
    else
    {
      return false;
    }
  }

  public bool RemovePlaylist(int id)
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.TryGetValue(id, out Playlist? foundPlaylistWithID))
      {
        user.Playlists.Remove(foundPlaylistWithID.ID);
        return true;
      }
      else
      {
        return false;
      }
    }
    else
    {
      return false;
    }
  }

  public bool AddMediaToPlaylist(int mediaID, int playlistID)
  {
    if (_currentPerson is User user)
    {
      if (_mediaFiles.TryGetValue(mediaID, out Media? foundMediaWithID) && user.Playlists.TryGetValue(playlistID, out Playlist? foundPlaylistWithID))
      {
        if (foundMediaWithID is Audio foundAudioWithID)
        {
          AudioInPlaylist newAudioInPlaylist = new(foundAudioWithID.Title, foundAudioWithID.Duration, foundAudioWithID.Artist);
          foundPlaylistWithID.MediaFiles.Add(newAudioInPlaylist.ID, newAudioInPlaylist);
          return true;
        }
        if (foundMediaWithID is Video foundVideoWithID)
        {
          VideoInPlaylist newVideoInPlaylist = new(foundVideoWithID.Title, foundVideoWithID.Duration);
          foundPlaylistWithID.MediaFiles.Add(newVideoInPlaylist.ID, newVideoInPlaylist);
          return false;
        }
        else
        {
          return false;
        }
      }
      else
      {
        Console.WriteLine("Playlist or media does not exist.");
        return false;
      }
    }
    else
    {
      Console.WriteLine("You have to logged in as user to delete playlist.");
      return false;
    }
  }

  public bool RemoveMediaFromPlaylist(int mediaID, int playlistID)
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.TryGetValue(playlistID, out Playlist? foundPlaylistWithID) && foundPlaylistWithID.MediaFiles.TryGetValue(mediaID, out MediaInPlaylist? foundMediaInPlayListWithID))
      {
        foundPlaylistWithID.MediaFiles.Remove(foundMediaInPlayListWithID.ID);
        return true;
      }
      else
      {
        return false;
      }
    }
    else
    {
      return false;
    }
  }
}