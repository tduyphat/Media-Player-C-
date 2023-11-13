namespace MediaPlayer.Service.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;

public interface IPeopleService
{
  void GetAllPeople();
  void AddUser(string name);
  void AddAdmin(string name);
  void RemovePerson(int id);
  void UpdatePerson(int id, string name);
}