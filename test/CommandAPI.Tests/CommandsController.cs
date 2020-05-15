using System;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommandAPI.Controllers;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        // "Global" objects
        DbContextOptionsBuilder<CommandContext> optionsBuilder;
        CommandContext  dbContext;
        CommandsController controller;

        // Our constructor
        public CommandsControllerTests()
        {
            optionsBuilder = new DbContextOptionsBuilder<CommandContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestInMemDB");
            dbContext = new CommandContext(optionsBuilder.Options);

            controller = new CommandsController(dbContext);

        }

        // Clean up some stuff
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var cmd in dbContext.CommandItems)
            {
                dbContext.CommandItems.Remove(cmd);
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            controller = null;
        }

        // ACTION 1 Tests: GET      /api/commands

        // TEST 1.1 REQUEST OBJECTS WHEN NONE EXIST - RETURN "NOTHING"
        [Fact]
        public void GetCommandItems_ReturnsZeroItems_WhenDBIsEmpty()
        {
            //Arrange
            
            //act
            var result = controller.GetCommandItems();

            //Assert
            Assert.Empty(result.Value);

        }


        [Fact]
        public void GetCommandItemsReturnOneItemWhenDBHasOneObject()
        {
            //Arrange
            var command = new Command { HowTo="Do Something", Platform="Some Platform", CommandLine="Some Command"};

            dbContext.CommandItems.Add(command);
            dbContext.SaveChanges();

            // Act
            var result = controller.GetCommandItems();

            //Assert
            Assert.Single(result.Value);





        }


        [Fact]
        public void GetCommandItemsReturnNItemsWhenDBHasNObjects() 
        {  
             //Arrange   
             var command = new Command   
             {      
                 HowTo = "Do Somethting",     
                 Platform = "Some Platform",     
                 CommandLine = "Some Command"   
            };   
            
            var command2 = new Command 
            {     
                  HowTo = "Do Somethting",     
                  Platform = "Some Platform",     
                  CommandLine = "Some Command"   
            };   
            dbContext.CommandItems.Add(command);   
            dbContext.CommandItems.Add(command2);   
            dbContext.SaveChanges(); 
 
            //Act 
            var result = controller.GetCommandItems(); 
 
            //Assert   
            Assert.Equal(2, result.Value.Count());
     }


        [Fact]
         public void GetCommandItemsReturnsTheCorrectType()
      {
          //Arrange 
 
          //Act
            var result = controller.GetCommandItems(); 
 
          //Assert  
          Assert.IsType<ActionResult<IEnumerable<Command>>>(result);
    } 
  
  
        [Fact]
         public void GetCommandItemReturnsNullResultWhenInvalidID() 
        {   
            //Arrange   
            
            //DB should be empty, any ID will be invalid 
 
            //Act   
            var result = controller.GetCommandItem(0); 
 
            //Assert   
            Assert.Null(result.Value); 
        }
  
  
    }
}