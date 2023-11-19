using MediaPlayer.Core.src.Entities.PersonEntities;

namespace MediaPlayer.Core.src.Abstractions;

public interface IPeopleRepo
{
  List<Person> GetAllPeople();
  Person GetPersonByID(int id);
  bool AddUser(string name);
  bool AddAdmin(string name);
  bool RemovePerson(int id);
  bool UpdatePerson(int id, string name);
}