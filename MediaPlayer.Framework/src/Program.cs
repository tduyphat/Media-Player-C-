using MediaPlayer.Controller.src;
using MediaPlayer.Framework.src.Repositories;
using MediaPlayer.Service.src;

namespace MediaPlayer.Framework.src;

internal class Program
{
    private static void Main(string[] args)
    {
        var database = new Database();
        var mediaPlayerRepo = new MediaPlayerRepository(database);
        var mediaPlayerService = new MediaPlayerService(mediaPlayerRepo);
        var MediaPlayerController = new MediaPlayerController(mediaPlayerService);
        var results = MediaPlayerController.GetAllMedia();
        Console.WriteLine(results);
    }
}
