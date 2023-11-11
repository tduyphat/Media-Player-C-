namespace MediaPlayer.Core.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public interface IMediaPlayerRepo
{
  Dictionary<int, Media> GetAllMedia();
  Dictionary<int, Person> GetAllPeople();
}