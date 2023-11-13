namespace MediaPlayer.Controller.src;

using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src.Abstractions;

public class PeopleController
{
  private IPeopleService _peopleService;

  public PeopleController(IPeopleService service)
  {
    _peopleService = service;
  }

  public void GetAllPeople()
  {
    _peopleService.GetAllPeople();
  }

  public void AddUser(object option)
  {
    try
    {
      string name = string.Format("{0}", option);
      _peopleService.AddUser(name);
    }
    catch
    {
      throw new ArgumentException("Name must be a string.");
    }
  }

  public void AddAdmin(object option)
  {
    try
    {
      string name = string.Format("{0}", option);
      _peopleService.AddAdmin(name);
    }
    catch
    {
      throw new ArgumentException("Name must be a string.");
    }
  }

  public void RemovePerson(object option)
  {
    try
    {
      int.TryParse(option.ToString(), out int id);
      _peopleService.RemovePerson(id);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer.");
    }
  }

  public void UpdatePerson(params object[] options)
  {
    try
    {
      int.TryParse(options[0].ToString(), out int id);
      string name = string.Format("{0}", options[1]);
      _peopleService.UpdatePerson(id, name);
    }
    catch
    {
      throw new ArgumentException("ID must be an integer, name must be a string.");
    }
  }
}