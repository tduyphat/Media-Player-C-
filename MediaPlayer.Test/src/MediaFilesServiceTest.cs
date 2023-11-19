namespace MediaPlayer.Test.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.MediaEntities;
using MediaPlayer.Service.src;
using MediaPlayer.Service.src.DTO;
using Moq;

public class MediaFilesServiceTest
{
  [Fact]
  public void GetAllMediaFact_NoParametersByDefault_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.GetAllMedia()).Returns(new List<Media>());
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    mediaFilesService.GetAllMedia();
    // Assert
    repo.Verify(repo => repo.GetAllMedia(), Times.Once);
  }

  [Theory]
  [ClassData(typeof(GetAllMediaData))]
  public void GetAllMediaTheory_NoParametersByDefault_ReturnValidData(List<MediaReadDTO> result)
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.GetAllMedia()).Returns(new List<Media>());
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    var files = mediaFilesService.GetAllMedia();
    // Assert
    Assert.Equal(result, files);
  }

  [Fact]
  public void GetMediaByIDFact_WithID_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.GetMediaByID(It.IsAny<int>())).Returns(new Audio("dywc", 300, "shm"));
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    mediaFilesService.GetMediaByID(1);
    // Assert
    repo.Verify(repo => repo.GetMediaByID(1), Times.Once);
  }

  // [Theory]
  // [ClassData(typeof(GetMediaByIDData))]
  // public void GetMediaByIDTheory_WithID_ReturnValidData(int id, MediaReadDTO result)
  // {
  //   // Arrange
  //   var repo = new Mock<IMediaFilesRepo>();
  //   repo.Setup(repo => repo.GetMediaByID(It.IsAny<int>())).Returns(new Audio("dywc", 300, "shm"));
  //   var mediaFilesService = new MediaFilesService(repo.Object);
  //   // Act
  //   var file = mediaFilesService.GetMediaByID(id);
  //   // Assert
  //   Assert.Equal(result, file);
  // }

  [Fact]
  public void AddAudio_WithValidDuration_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.AddAudio(It.IsAny<string>(), 300, It.IsAny<string>())).Returns(true);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    var newAudioCreated = mediaFilesService.AddAudio("dywc", 300, "shm");
    // Assert
    Assert.True(newAudioCreated);
  }

  [Fact]
  public void AddAudio_WithInValidDuration_ReturnException()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.AddAudio(It.IsAny<string>(), -300, It.IsAny<string>())).Returns(false);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    var newAudioCreated = mediaFilesService.AddAudio("dywc", -300, "shm");
    // Assert
    Assert.False(newAudioCreated);
  }

  [Fact]
  public void AddVideo_WithValidDuration_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.AddVideo(It.IsAny<string>(), 300)).Returns(true);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    var newVideoCreated = mediaFilesService.AddVideo("dywc", 300);
    // Assert
    Assert.True(newVideoCreated);
  }

  [Fact]
  public void AddVideo_WithInValidDuration_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.AddVideo(It.IsAny<string>(), -300)).Returns(false);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    var newVideoCreated = mediaFilesService.AddVideo("dywc", -300);
    // Assert
    Assert.False(newVideoCreated);
  }

  [Fact]
  public void RemoveMedia_WithValidID_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.RemoveMedia(It.IsAny<int>())).Returns(true);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    mediaFilesService.RemoveMedia(1);
    // Assert
    repo.Verify(repo => repo.RemoveMedia(1), Times.Once);
  }

  [Fact]
  public void UpdateAudio_WithValidParameters_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.UpdateAudio(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    mediaFilesService.UpdateAudio(1, "dywc", "shm");
    // Assert
    repo.Verify(repo => repo.UpdateAudio(1, "dywc", "shm"), Times.Once);
  }

  [Fact]
  public void UpdateVideo_WithValidParameters_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IMediaFilesRepo>();
    repo.Setup(repo => repo.UpdateVideo(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
    var mediaFilesService = new MediaFilesService(repo.Object);
    // Act
    mediaFilesService.UpdateVideo(1, "dywc");
    // Assert
    repo.Verify(repo => repo.UpdateVideo(1, "dywc"), Times.Once);
  }
}

public class GetAllMediaData : TheoryData<List<MediaReadDTO>>
{
  public GetAllMediaData()
  {
    Add(new List<MediaReadDTO>());
  }
}

public class GetMediaByIDData : TheoryData<int, MediaReadDTO>
{
  public GetMediaByIDData()
  {
    Add(1, new MediaReadDTO(new Audio("dywc", 300, "shm")));
  }
}