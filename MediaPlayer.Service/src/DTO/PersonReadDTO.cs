namespace MediaPlayer.Service.src.DTO;

using MediaPlayer.Core.src.Entities.PersonEntities;

public class PersonReadDTO
{
  public readonly string Name;
  public readonly int ID;

  public PersonReadDTO(Person person)
  {
    Name = person.Name;
    ID = person.ID;
  }
}