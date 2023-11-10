namespace MediaPlayer.Core.src.Entities.PlaylistEntities;

public class Playlist
{
    private static int _id;
    private Dictionary<int, MediaInPlaylist> _mediafiles;

    public int ID { get; }
    public Dictionary<int, MediaInPlaylist> MediaFiles { get => _mediafiles; set => _mediafiles = value; }

    public Playlist()
    {
        ID = _id;
        _mediafiles = new Dictionary<int, MediaInPlaylist>();
        _id++;
    }
}
