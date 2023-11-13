namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;

public class PeopleService: IPeopleService
{
  private IPeopleRepo _repo;

  public PeopleService(IPeopleRepo repo)
  {
    _repo = repo;
  }

  public void GetAllPeople()
  {
    _repo.GetAllPeople();
  }

  public void AddUser(string name)
  {
    _repo.AddUser(name);
  }

  public void AddAdmin(string name)
  {
    _repo.AddUser(name);
  }

  public void RemovePerson(int id)
  {
    _repo.RemovePerson(id);
  }

  public void UpdatePerson(int id, string name)
  {
    _repo.UpdatePerson(id, name);
  }
}