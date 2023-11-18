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

  public void Login(int id)
  {
    if (_people.TryGetValue(id, out Person? foundPersonWithId))
    {
      _currentPerson = foundPersonWithId;
      Console.WriteLine($"{_currentPerson.Name} is logged in.");
    }
    else
    {
      Console.WriteLine("No user with this ID exists.");
    }
  }

  public void Logout()
  {
    if (_currentPerson is null)
    {
      Console.WriteLine("No user is logged in.");
    }
    else
    {
      _currentPerson = null;
      _currentPlaylist = null;
    }
  }

  public void GetAllPlaylists()
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.Count > 0)
      {
        Console.WriteLine($"{user.Name}'s PLAYLISTS:");
        foreach (var playlist in user.Playlists.Values)
        {
          Console.WriteLine($"Playlist Title: {playlist.Title}, Media: {playlist.MediaFiles.Count} tracks");
        }
      }
    }
    else
    {
      Console.WriteLine("You have to logged in as user to get all playlists.");
    }
  }

  public void GetAllMediaInPlaylist(int id)
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.TryGetValue(id, out Playlist? foundPlaylistWithID))
      {
        Console.WriteLine($"MEDIA IN {foundPlaylistWithID.Title}");
        foreach (var media in foundPlaylistWithID.MediaFiles.Values)
        {
          Console.WriteLine($"Media Title: {media.Title}, Duration: {media.Duration}s");
        }
      }
    }
    else
    {
      Console.WriteLine("You have to logged in as user to read the playlist.");
    }
  }

  public void CreatePlaylist(string title)
  {
    if (_currentPerson is User user)
    {
      Playlist newPlaylist = new(title);
      user.Playlists.Add(newPlaylist.ID, newPlaylist);
    }
    else
    {
      Console.WriteLine("You have to logged in as user to create new playlist.");
    }
  }

  public void RemovePlaylist(int id)
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.TryGetValue(id, out Playlist? foundPlaylistWithID))
      {
        user.Playlists.Remove(foundPlaylistWithID.ID);
      }
    }
    else
    {
      Console.WriteLine("You have to logged in as user to delete playlist.");
    }
  }

  public void AddMediaToPlaylist(int mediaID, int playlistID)
  {
    if (_currentPerson is User user)
    {
      if (_mediaFiles.TryGetValue(mediaID, out Media? foundMediaWithID) && user.Playlists.TryGetValue(playlistID, out Playlist? foundPlaylistWithID))
      {
        if (foundMediaWithID is Audio foundAudioWithID)
        {
          AudioInPlaylist newAudioInPlaylist = new(foundAudioWithID.Title, foundAudioWithID.Duration, foundAudioWithID.Artist);
          foundPlaylistWithID.MediaFiles.Add(newAudioInPlaylist.ID, newAudioInPlaylist);
        }
        if (foundMediaWithID is Video foundVideoWithID)
        {
          VideoInPlaylist newVideoInPlaylist = new(foundVideoWithID.Title, foundVideoWithID.Duration);
          foundPlaylistWithID.MediaFiles.Add(newVideoInPlaylist.ID, newVideoInPlaylist);
        }
      }
      else
      {
        Console.WriteLine("Playlist or media does not exist.");
      }
    }
    else
    {
      Console.WriteLine("You have to logged in as user to delete playlist.");
    }
  }

  public void RemoveMediaFromPlaylist(int mediaID, int playlistID)
  {
    if (_currentPerson is User user)
    {
      if (user.Playlists.TryGetValue(playlistID, out Playlist? foundPlaylistWithID) && foundPlaylistWithID.MediaFiles.TryGetValue(mediaID, out MediaInPlaylist? foundMediaInPlayListWithID))
      {
        foundPlaylistWithID.MediaFiles.Remove(foundMediaInPlayListWithID.ID);
      }
      else
      {
        Console.WriteLine("Playlist or media does not exist.");
      }
    }
    else
    {
      Console.WriteLine("You have to logged in as user to delete playlist.");
    }
  }
}