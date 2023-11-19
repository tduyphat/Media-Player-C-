namespace MediaPlayer.Framework.src;

using MediaPlayer.Controller.src;
using MediaPlayer.Framework.src.Repositories;
using MediaPlayer.Service.src;

internal class Program
{
    private static void Main(string[] args)
    {
        var database = Database.Instance;
        var mediaFilesRepo = new MediaFilesRepository(database);
        var peopleRepository = new PeopleRepository(database);
        var mediaPlayerRepo = new MediaPlayerRepository(database);

        var mediaPlayerService = new MediaPlayerService(mediaPlayerRepo);
        var mediaPlayerController = new MediaPlayerController(mediaPlayerService);

        var mediaFilesService = new MediaFilesService(mediaFilesRepo);
        var mediaFilesController = new MediaFilesController(mediaFilesService);

        var peopleService = new PeopleService(peopleRepository);
        var peopleController = new PeopleController(peopleService);

        var allPeople = peopleController.GetAllPeople();
        var allMedia = mediaFilesController.GetAllMedia();

        foreach (var person in allPeople)
        {
            Console.WriteLine($"Name: {person.Name}, ID: {person.ID}");
        }
        foreach (var media in allMedia)
        {
            Console.WriteLine($"Title: {media.Title}, ID: {media.ID}");
        }
    }
}
