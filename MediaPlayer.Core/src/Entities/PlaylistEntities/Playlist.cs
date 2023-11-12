namespace MediaPlayer.Core.src.Entities.PlaylistEntities;

public class Playlist
{
    private static int _id = 1;
    private string _title;
    // private int _userId;
    private int _volume;
    private int _brightness;
    private MediaInPlaylist? _currentTrack;
    private Dictionary<int, MediaInPlaylist> _mediaFiles;

    public int ID { get; }
    public string Title { get => _title; }
    // public int UserID { get => _userId; }
    public int Volume { get => _volume; set => _volume = value; }
    public int Brightness { get => _brightness; set => _brightness = value; }
    public MediaInPlaylist? CurrentTrack { get => _currentTrack; set => _currentTrack = value; }
    public Dictionary<int, MediaInPlaylist> MediaFiles { get => _mediaFiles; set => _mediaFiles = value; }

    public Playlist(string title)
    {
        ID = _id;
        _title = title;
        // _userId = userId;
        _volume = 100;
        _brightness = 100;
        _currentTrack = null;
        _mediaFiles = new Dictionary<int, MediaInPlaylist>();
        _id++;
    }
}
