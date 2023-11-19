namespace MediaPlayer.Test.src;

using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities.PersonEntities;
using MediaPlayer.Service.src;
using MediaPlayer.Service.src.DTO;
using Moq;

public class PeopleServiceTest
{
  [Fact]
  public void GetAllPeopleFact_NoParametersByDefault_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.GetAllPeople()).Returns(new List<Person>());
    var peopleService = new PeopleService(repo.Object);
    // Act
    peopleService.GetAllPeople();
    // Assert
    repo.Verify(repo => repo.GetAllPeople(), Times.Once);
  }

  [Theory]
  [ClassData(typeof(GetAllPeopleData))]
  public void GetAllPeopleTheory_NoParametersByDefault_ReturnValidData(List<PersonReadDTO> result)
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.GetAllPeople()).Returns(new List<Person>());
    var peopleService = new PeopleService(repo.Object);
    // Act
    var files = peopleService.GetAllPeople();
    // Assert
    Assert.Equal(result, files);
  }

  [Fact]
  public void GetPersonByIDFact_WithID_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.GetPersonByID(It.IsAny<int>())).Returns(new User("john"));
    var peopleService = new PeopleService(repo.Object);
    // Act
    peopleService.GetPersonByID(1);
    // Assert
    repo.Verify(repo => repo.GetPersonByID(1), Times.Once);
  }

  // [Theory]
  // [ClassData(typeof(GetPersonByIDData))]
  // public void GetPersonByIDTheory_WithID_ReturnValidData(int id, PersonReadDTO result)
  // {
  //   // Arrange
  //   var repo = new Mock<IPersonRepo>();
  //   repo.Setup(repo => repo.GetPersonByID(It.IsAny<int>())).Returns(new User("john"));
  //   var personService = new PeopleService(repo.Object);
  //   // Act
  //   var file = personService.GetPersonByID(id);
  //   // Assert
  //   Assert.Equal(result, file);
  // }

  [Fact]
  public void AddUser_WithValidParameter_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.AddUser(It.IsAny<string>())).Returns(true);
    var personService = new PeopleService(repo.Object);
    // Act
    var newUserCreated = personService.AddUser("john");
    // Assert
    Assert.True(newUserCreated);
  }

  [Fact]
  public void AddAdmin_WithValidParameter_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.AddAdmin(It.IsAny<string>())).Returns(true);
    var personService = new PeopleService(repo.Object);
    // Act
    var newAdminCreated = personService.AddAdmin("john");
    // Assert
    Assert.True(newAdminCreated);
  }

  [Fact]
  public void RemovePerson_WithValidID_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.RemovePerson(It.IsAny<int>())).Returns(true);
    var personService = new PeopleService(repo.Object);
    // Act
    personService.RemovePerson(1);
    // Assert
    repo.Verify(repo => repo.RemovePerson(1), Times.Once);
  }

  [Fact]
  public void UpdatePerson_WithValidParameters_ReturnValidData()
  {
    // Arrange
    var repo = new Mock<IPeopleRepo>();
    repo.Setup(repo => repo.UpdatePerson(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
    var personService = new PeopleService(repo.Object);
    // Act
    personService.UpdatePerson(1, "jim");
    // Assert
    repo.Verify(repo => repo.UpdatePerson(1, "jim"), Times.Once);
  }
}

public class GetAllPeopleData : TheoryData<List<PersonReadDTO>>
{
  public GetAllPeopleData()
  {
    Add(new List<PersonReadDTO>());
  }
}

public class GetPersonByIDData : TheoryData<int, PersonReadDTO>
{
  public GetPersonByIDData()
  {
    Add(1, new PersonReadDTO(new User("john")));
  }
}