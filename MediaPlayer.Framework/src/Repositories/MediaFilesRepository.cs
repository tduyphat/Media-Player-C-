namespace MediaPlayer.Framework.src.Repositories;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class MediaFilesRepository : IMediaFilesRepo
{
  private Dictionary<int, Media> _mediaFiles;
  // private Person? _currentPerson;

  public MediaFilesRepository(Database database)
  {
    _mediaFiles = database.MediaFiles;
    // _currentPerson = null;
  }

  public List<Media> GetAllMedia()
  {
    return _mediaFiles.Values.ToList();
  }

  public Media GetMediaByID(int id)
  {
    if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID))
    {
      return foundMediaWithID;
    }
    else
    {
      throw new Exception("ID does not exist");
    }
  }

  public bool AddAudio(string title, int duration, string artist)
  {
    // if (_currentPerson is Admin)
    // {
    Audio newAudio = new(title, duration, artist);
    _mediaFiles.Add(newAudio.ID, newAudio);
    return true;
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to add audio.");
    // }
  }

  public bool AddVideo(string title, int duration)
  {
    // if (_currentPerson is Admin)
    // {
    Video newVideo = new(title, duration);
    _mediaFiles.Add(newVideo.ID, newVideo);
    return true;
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to add video.");
    // }
  }

  public bool RemoveMedia(int id)
  {
    // if (_currentPerson is Admin)
    // {
    if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID))
    {
      _mediaFiles.Remove(foundMediaWithID.ID);
      return true;
    }
    else
    {
      return false;
    }
    // }
    // // else
    // // {
    // //   Console.WriteLine("You do not have the permission to remove media.");
    // // }
  }

  public bool UpdateAudio(int id, string title, string artist)
  {
    // if (_currentPerson is Admin)
    // {
    if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID) && foundMediaWithID is Audio audio)
    {
      audio.Title = title;
      audio.Artist = artist;
      return true;
    }
    else
    {
      return false;
    }
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to update audio.");
    // }
  }

  public bool UpdateVideo(int id, string title)
  {
    // if (_currentPerson is Admin)
    // {
    if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID) && foundMediaWithID is Video video)
    {
      video.Title = title;
      return true;
    }
    else
    {
      return false;
    }
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to update video.");
    // }
  }
}