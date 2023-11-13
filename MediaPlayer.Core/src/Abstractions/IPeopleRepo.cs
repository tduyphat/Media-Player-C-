namespace MediaPlayer.Core.src.Abstractions;

public interface IPeopleRepo
{
  void GetAllPeople();
  void AddUser(string name);
  void AddAdmin(string name);
  void RemovePerson(int id);
  void UpdatePerson(int id, string name);
}