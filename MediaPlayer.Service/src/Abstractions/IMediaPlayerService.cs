namespace MediaPlayer.Service.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public interface IMediaPlayerService
{
  Dictionary<int, Media> GetAllMedia();
  Dictionary<int, Person> GetAllPeople();
}