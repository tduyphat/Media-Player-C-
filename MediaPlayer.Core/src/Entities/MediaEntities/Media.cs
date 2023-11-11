namespace MediaPlayer.Core.src.Entities.MediaEntities;

public class Media
{
    protected static int _id = 1;
    protected string _title;
    protected int _duration;

    public int ID { get; }
    public string Title { get => _title; set => _title = value; }
    public int Duration { get => _duration; }

    public Media(string title, int duration)
    {
        ID = _id;
        _title = title;
        _duration = duration;
        _id++;
    }
}
