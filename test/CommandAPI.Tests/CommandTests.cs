using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                 HowTo = "Do something awesome",
                Platform = "some platform",
                CommandLine = "Some commandline"  
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }



        [Fact]
        public void CanChangeHoTo()
        {
        // Arrange
           
        // Act
        testCommand.HowTo = "Execute Unit Tests";

        //Assert
        Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

         [Fact]
        public void CanChangePlatform()
        {
        // Arrange
           
        // Act
        testCommand.Platform = "xUnit";

        //Assert
        Assert.Equal("xUnit", testCommand.Platform);
        }
        
         [Fact]
        public void CanChangeCmdLine()
        {
        // Arrange
         
        // Act
        testCommand.CommandLine = "dotnet test";

        //Assert
        Assert.Equal("dotnet test", testCommand.CommandLine);
        }

     }
}