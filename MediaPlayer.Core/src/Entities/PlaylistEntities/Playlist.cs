namespace MediaPlayer.Core.src.Entities.PlaylistEntities;

public class Playlist
{
    private static int _id = 1;
    private int _userId;
    private Dictionary<int, MediaInPlaylist> _mediaFiles;

    public int ID { get; }
    public int UserID { get => _userId; }
    public Dictionary<int, MediaInPlaylist> MediaFiles { get => _mediaFiles; set => _mediaFiles = value; }

    public Playlist(int userId)
    {
        ID = _id;
        _userId = userId;
        _mediaFiles = new Dictionary<int, MediaInPlaylist>();
        _id++;
    }
}
