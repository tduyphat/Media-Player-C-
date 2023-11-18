namespace MediaPlayer.Framework.src.Repositories;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Core.src.Entities.PlaylistEntities;

public class PeopleRepository : IPeopleRepo
{
  private Dictionary<int, Person> _people;
  private Person? _currentPerson;

  public PeopleRepository(Database database)
  {
    _people = database.People;
    _currentPerson = null;
  }

  public void GetAllPeople()
  {
    if (_people.Count > 0)
    {
      Console.WriteLine("ALL PEOPLE:");
      foreach (var person in _people.Values)
      {
        Console.WriteLine($"ID: {person.ID}, Person Name: {person.Name}");
      }
    }
  }

  public void AddUser(string name)
  {
    // if (_currentPerson is Admin)
    // {
    User newUser = new(name);
    _people.Add(newUser.ID, newUser);
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to create new user.");
    // }
  }

  public void AddAdmin(string name)
  {
    // if (_currentPerson is Admin)
    // {
    Admin newAdmin = new(name);
    _people.Add(newAdmin.ID, newAdmin);
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to create new admin.");
    // }
  }

  public void RemovePerson(int id)
  {
    // if (_currentPerson is Admin)
    // {
    if (_people.TryGetValue(id, out Person? foundPersonWithID))
    {
      _people.Remove(foundPersonWithID.ID);
    }
    else
    {
      Console.WriteLine("ID is not found.");
    }
    // }
    // else
    // {
    //   Console.WriteLine("You do not have the permission to remove people.");
    // }
  }

  public void UpdatePerson(int id, string name)
  {
    // if (_currentPerson is Admin)
    // {
    if (_people.TryGetValue(id, out Person? foundPersonWithID))
    {
      foundPersonWithID.Name = name;
    }
    else
    {
      Console.WriteLine("ID is not found.");
    }
    // }
    // // else
    // // {
    // //   Console.WriteLine("You do not have the permission to update people.");
    // // }
  }
}