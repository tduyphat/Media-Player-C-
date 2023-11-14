namespace MediaPlayer.Framework.src.Repositories;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class MediaFilesRepository : IMediaFilesRepo
{
  private Dictionary<int, Media> _mediaFiles;
  private Person? _currentPerson;

  public MediaFilesRepository(Database database)
  {
    _mediaFiles = database.MediaFiles;
    _currentPerson = database.CurrentPerson;
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
}