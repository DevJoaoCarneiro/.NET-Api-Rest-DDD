using Application.Interfaces;
using Application.Request;
using Application.Service;
using Domain.entities;
using Domain.Interfaces;
using Domain.Repository;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Tests;

public class UserServiceTest
{

    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly ISecurityService _userServices = Substitute.For<ISecurityService>();
    private readonly UserService _service;

    public UserServiceTest()
    {
        _service = new UserService(_userRepository, _userServices);
    }

    [Fact]
    public async void Should_Create_New_User_Corretly()
    {
        //Arrange
        var request = new UserRequestDTO
        {
            name = "Joao Victor",
            email = "joao@gmail.com",
            password = "joao123@#$"
        };

        var passwordHashMock = "HIE2233";
        _userServices.HashPassword(request.password).Returns(passwordHashMock);

        //Act

        var result = await _service.createUser(request);

        //Assert
        Assert.Equal("User created successfully", result.message);
        Assert.Equal("Success", result.status);
        Assert.Equal(request.name, result.data.name);
        Assert.Equal(request.email, result.data.email);

    }

    [Fact]
    public async Task Should_Return_Invalid_Argument_When_Request_Is_Null()
    {
        //Arrange
        UserRequestDTO? request = null;

        //Act
        var result = await _service.createUser(request);

        //Assert
        Assert.Equal("Parameters is empty or null", result.message);
        Assert.Equal("invalid_argument", result.status);
        Assert.Null(result.data);
    }

    [Fact]
    public async Task CreateUser_WhenRepositoryThrowsException_ReturnsErrorResponse()
    {
        //Arrange
        var request = new UserRequestDTO
        {
            name = "Joao Victor",
            email = "joao@gmail.com",
            password = "joao123@#$"
        };

        _userServices.HashPassword(Arg.Any<string>())
                       .Returns("hash123");

        _userRepository.AddAsync(Arg.Any<Domain.entities.User>())
                       .ThrowsAsync(new Exception("DB error"));

        // Act
        var result = await _service.createUser(request);

        // Assert
        Assert.Equal("error", result.status);
        Assert.Null(result.data);

    }

}
