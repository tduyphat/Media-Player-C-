namespace MediaPlayer.Controller.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;
using MediaPlayer.Service.src.DTO;

public class PeopleController
{
  private IPeopleService _peopleService;

  public PeopleController(IPeopleService service)
  {
    _peopleService = service;
  }

  public List<PersonReadDTO> GetAllPeople()
  {
    return _peopleService.GetAllPeople();
  }

  public PersonReadDTO GetPersonByID(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _peopleService.GetPersonByID(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool AddUser(object option)
  {
    try
    {
      string name = string.Format("{0}", option);
      return _peopleService.AddUser(name);
    }
    catch
    {
      throw new ArgumentException("Name must be a string.");
    }
  }

  public bool AddAdmin(object option)
  {
    try
    {
      string name = string.Format("{0}", option);
      return _peopleService.AddAdmin(name);
    }
    catch
    {
      throw new ArgumentException("Name must be a string.");
    }
  }

  public bool RemovePerson(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      return _peopleService.RemovePerson(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public bool UpdatePerson(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string name = string.Format("{0}", options[1]);
      return _peopleService.UpdatePerson(id, name);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, name must be a string.");
    }
  }
}