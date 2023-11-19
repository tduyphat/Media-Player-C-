namespace MediaPlayer.Service.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.PlaylistEntities;
using MediaPlayer.Service.src;
using MediaPlayer.Service.src.DTO;
using Moq;

public class MediaPlayerServiceTest
{
  [Fact]
  public void Login_WithValidParameter_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.Login(It.IsAny<int>())).Returns(true);
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    mediaPlayerService.Login(1);
    // Assert
    repo.Verify(repo => repo.Login(1), Times.Once);
  }

  [Fact]
  public void Logout_NoParametersByDefault_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.Logout()).Returns(true);
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    mediaPlayerService.Logout();
    // Assert
    repo.Verify(repo => repo.Logout(), Times.Once);
  }

  [Theory]
  [ClassData(typeof(GetAllMediaInPlaylistData))]
  public void GetAllPlaylists_NoParametersByDefault_ReturnValidData(List<PlaylistReadDTO> result)
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.GetAllPlaylists()).Returns(new List<Playlist>());
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    var playlists = mediaPlayerService.GetAllPlaylists();
    // Assert
    Assert.Equal(result, playlists);
  }

  [Theory]
  [ClassData(typeof(GetAllMediaInPlaylistData))]
  public void GetAllMediaInPlaylist_WithValidParameter_ReturnValidData(int id, List<MediaInPlaylistReadDTO> result)
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.GetAllMediaInPlaylist(It.IsAny<int>())).Returns(new List<MediaInPlaylist>());
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    var mediaInPlaylists = mediaPlayerService.GetAllMediaInPlaylist(id);
    // Assert
    Assert.Equal(result, mediaInPlaylists);
  }

  [Fact]
  public void CreatePlaylist_WithValidParameter_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.CreatePlaylist(It.IsAny<string>())).Returns(true);
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    mediaPlayerService.CreatePlaylist("playlist1");
    // Assert
    repo.Verify(repo => repo.CreatePlaylist("playlist1"), Times.Once);
  }

  [Fact]
  public void RemovePlaylist_WithValidParameter_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.RemovePlaylist(It.IsAny<int>())).Returns(true);
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    mediaPlayerService.RemovePlaylist(1);
    // Assert
    repo.Verify(repo => repo.RemovePlaylist(1), Times.Once);
  }

  [Fact]
  public void AddMediaToPlaylist_WithValidParameters_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.AddMediaToPlaylist(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    mediaPlayerService.AddMediaToPlaylist(1, 1);
    // Assert
    repo.Verify(repo => repo.AddMediaToPlaylist(1, 1), Times.Once);
  }

  [Fact]
  public void RemoveMediaFromPlaylist_WithValidParameters_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaPlayerRepo>();
    repo.Setup(repo => repo.RemoveMediaFromPlaylist(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
    var mediaPlayerService = new MediaPlayerService(repo.Object);
    // Act
    mediaPlayerService.RemoveMediaFromPlaylist(1, 1);
    // Assert
    repo.Verify(repo => repo.RemoveMediaFromPlaylist(1, 1), Times.Once);
  }
}

public class GetAllPlaylistsData : TheoryData<List<PlaylistReadDTO>>
{
  public GetAllPlaylistsData()
  {
    Add(new List<PlaylistReadDTO>());
  }
}

public class GetAllMediaInPlaylistData : TheoryData<int, List<MediaInPlaylistReadDTO>>
{
  public GetAllMediaInPlaylistData()
  {
    Add(1, new List<MediaInPlaylistReadDTO>());
  }
}