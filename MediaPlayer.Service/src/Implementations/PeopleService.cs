namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

public class PeopleService: IPeopleService
{
  private IPeopleRepo _repo;

  public PeopleService(IPeopleRepo repo)
  {
    _repo = repo;
  }

  public List<PersonReadDTO> GetAllPeople()
  {
    var allPeople = _repo.GetAllPeople();
    return allPeople.Select((person) => new PersonReadDTO(person)).ToList();
  }

  public PersonReadDTO GetPersonByID(int id)
  {
    var person = _repo.GetPersonByID(id);
    return new PersonReadDTO(person);
  }

  public bool AddUser(string name)
  {
    return _repo.AddUser(name);
  }

  public bool AddAdmin(string name)
  {
    return _repo.AddAdmin(name);
  }

  public bool RemovePerson(int id)
  {
    return _repo.RemovePerson(id);
  }

  public bool UpdatePerson(int id, string name)
  {
    return _repo.UpdatePerson(id, name);
  }
}