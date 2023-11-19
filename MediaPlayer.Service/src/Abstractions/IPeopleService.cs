namespace MediaPlayer.Service.src.Abstractions;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.DTO;

public interface IPeopleService
{
  List<PersonReadDTO> GetAllPeople();
  PersonReadDTO GetPersonByID(int id);
  bool AddUser(string name);
  bool AddAdmin(string name);
  bool RemovePerson(int id);
  bool UpdatePerson(int id, string name);
}