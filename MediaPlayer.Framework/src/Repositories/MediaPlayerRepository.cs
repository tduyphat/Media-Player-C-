using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

namespace MediaPlayer.Framework.src.Repositories;

public class MediaPlayerRepository : IMediaPlayerRepo
{
  private Dictionary<int, Media> _mediaFiles;
  private Dictionary<int, Person> _people;

  private Person? _currentPerson;

  public MediaPlayerRepository(Database database)
  {
    _mediaFiles = database.MediaFiles;
    _people = database.People;
  }

  public void GetAllMedia()
  {
    foreach (var mediaFiles in _mediaFiles.Values)
    {
      Console.WriteLine(mediaFiles.Title);
    }
  }

  public void GetAllPeople()
  {
    foreach (var person in _people.Values)
    {
      Console.WriteLine(person.Name);
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
    if (_mediaFiles.TryGetValue(id, out Media? foundMediaWithID))
    {
      _mediaFiles.Remove(foundMediaWithID.ID);
    }
    else
    {
      Console.WriteLine("ID is not found.");
    }
  }
}