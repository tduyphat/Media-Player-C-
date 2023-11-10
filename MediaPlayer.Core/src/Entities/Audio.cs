namespace MediaPlayer.Core.src.Entities;

public class Audio : Media
{
    private string _artist;

    public string Artist { get => _artist; set => _artist = value; }

    public Audio(string title, int duration, string artist) : base(title, duration)
    {
        _artist = artist;
    }
}
