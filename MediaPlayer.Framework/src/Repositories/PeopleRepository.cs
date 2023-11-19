namespace MediaPlayer.Framework.src.Repositories;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;
using MediaPlayer.Service.src.DTO;

public class PeopleRepository : IPeopleRepo
{
  private Dictionary<int, Person> _people;
  private Person? _currentPerson;

  public PeopleRepository(Database database)
  {
    _people = database.People;
    _currentPerson = null;
  }

  public List<Person> GetAllPeople()
  {
    return _people.Values.ToList();
  }

  public Person GetPersonByID(int id)
  {
    if (_people.TryGetValue(id, out Person? foundPersonWithID))
    {
      return foundPersonWithID;
    }
    else
    {
      throw new Exception("ID does not exist");
    }
  }

  public bool AddUser(string name)
  {
    // if (_currentPerson is Admin)
    // {
    User newUser = new(name);
    _people.Add(newUser.ID, newUser);
    return true;
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to create new user.");
    // }
  }

  public bool AddAdmin(string name)
  {
    // if (_currentPerson is Admin)
    // {
    Admin newAdmin = new(name);
    _people.Add(newAdmin.ID, newAdmin);
    return true;
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to create new admin.");
    // }
  }

  public bool RemovePerson(int id)
  {
    // if (_currentPerson is Admin)
    // {
    if (_people.TryGetValue(id, out Person? foundPersonWithID))
    {
      _people.Remove(foundPersonWithID.ID);
      return true;
    }
    else
    {
      return false;
    }
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to remove people.");
    // }
  }

  public bool UpdatePerson(int id, string name)
  {
    // if (_currentPerson is Admin)
    // {
    if (_people.TryGetValue(id, out Person? foundPersonWithID))
    {
      foundPersonWithID.Name = name;
      return true;
    }
    else
    {
      return false;
    }
    // }
    // // else
    // // {
    // //   Console.WriteLine("You do not have the permission to update people.");
    // // }
  }
}