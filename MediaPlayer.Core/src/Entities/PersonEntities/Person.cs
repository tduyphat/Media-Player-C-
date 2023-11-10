namespace MediaPlayer.Core.src.Entities.PersonEntities;

public class Person
{
    protected static int _id;
    protected string _name;

    public int ID { get; }
    public string Name { get => _name; set => _name = value; }

    public Person(string name)
    {
        ID = _id;
        _name = name;
        _id++;
    }
}
