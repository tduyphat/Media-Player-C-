namespace MediaPlayer.Framework.src.Repositories;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class MediaPlayerRepository : IMediaPlayerRepo, IMediaFilesRepo, IPeopleRepo
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;
  private Person? _currentPerson;
  private Playlist? _currentPlaylist;

  public MediaPlayerRepository(Database database)
  {
    _mediaFiles = database.MediaFiles;
    _people = database.People;
  }

  public void GetAllMedia()
  {
    if (_mediaFiles.Count > 0)
    {
      Console.WriteLine("ALL MEDIA:");
      foreach (var mediaFile in _mediaFiles.Values)
      {
        Console.WriteLine($"Media Title: {mediaFile.Title}, Duration: {mediaFile.Duration}s");
      }
    }
  }

  public void GetAllPeople()
  {
    if (_people.Count > 0)
    {
      Console.WriteLine("ALL PEOPLE:");
      foreach (var person in _people.Values)
      {
        Console.WriteLine($"Person Name: {person.Name}");
      }
    }
  }

  public void Login(int id)
  {
    if (_people.TryGetValue(id, out Person? foundPersonWithId))
    {
      _currentPerson = foundPersonWithId;
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

  public void AddAudio(string title, int duration, string artist)
  {
    if (_currentPerson is Admin)
    {
      Audio newAudio = new(title, duration, artist);
      _mediaFiles.Add(newAudio.ID, newAudio);
    }
    else
    {
      Console.WriteLine("You do not have the permission to add audio.");
    }
  }

  public void AddVideo(string title, int duration)
  {
    if (_currentPerson is Admin)
    {
      Video newVideo = new(title, duration);
      _mediaFiles.Add(newVideo.ID, newVideo);
    }
    else
    {
      Console.WriteLine("You do not have the permission to add video.");
    }
  }

  public void RemoveMedia(int id)
  {
    if (_currentPerson is Admin)
    {
      if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID))
      {
        _mediaFiles.Remove(foundMediaWithID.ID);
      }
      else
      {
        Console.WriteLine("ID is not found.");
      }
    }
    else
    {
      Console.WriteLine("You do not have the permission to remove media.");
    }
  }

  public void UpdateAudio(int id, string title, string artist)
  {
    if (_currentPerson is Admin)
    {
      if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID) && foundMediaWithID is Audio audio)
      {
        audio.Title = title;
        audio.Artist = artist;
      }
      else
      {
        Console.WriteLine("ID is not found.");
      }
    }
    else
    {
      Console.WriteLine("You do not have the permission to update audio.");
    }
  }

  public void UpdateVideo(int id, string title)
  {
    if (_currentPerson is Admin)
    {
      if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID) && foundMediaWithID is Video video)
      {
        video.Title = title;
      }
      else
      {
        Console.WriteLine("ID is not found.");
      }
    }
    else
    {
      Console.WriteLine("You do not have the permission to update video.");
    }
  }

  public void AddUser(string name)
  {
    if (_currentPerson is Admin)
    {
      User newUser = new(name);
      _people.Add(newUser.ID, newUser);
    }
    else
    {
      Console.WriteLine("You do not have the permission to create new user.");
    }
  }

  public void AddAdmin(string name)
  {
    if (_currentPerson is Admin)
    {
      Admin newAdmin = new(name);
      _people.Add(newAdmin.ID, newAdmin);
    }
    else
    {
      Console.WriteLine("You do not have the permission to create new admin.");
    }
  }

  public void RemovePerson(int id)
  {
    if (_currentPerson is Admin)
    {
      if (_people.TryGetValue(id, out Person? foundPersonWithID))
      {
        _people.Remove(foundPersonWithID.ID);
      }
      else
      {
        Console.WriteLine("ID is not found.");
      }
    }
    else
    {
      Console.WriteLine("You do not have the permission to remove people.");
    }
  }

  public void UpdatePerson(int id, string name)
  {
    if (_currentPerson is Admin)
    {
      if (_people.TryGetValue(id, out Person? foundPersonWithID))
      {
        foundPersonWithID.Name = name;
      }
      else
      {
        Console.WriteLine("ID is not found.");
      }
    }
    else
    {
      Console.WriteLine("You do not have the permission to update people.");
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