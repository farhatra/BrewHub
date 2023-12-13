using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using BrewHub.Application.Contracts.Persistence;
using BrewHub.Application.Features.Commands;
using BrewHub.Application.Features.DtoModels;

namespace BrewHub.Test
{
    // Add necessary using statements

    //public class AddNewBeerCommandTests
    //{
    //    [Fact]
    //    public async Task Handle_ValidInput_AddsNewBeer()
    //    {
    //        // Arrange
    //        var breweryServiceMock = new Mock<IBreweryService>();
    //        var validatorMock = new Mock<IValidator<AddNewBeerCommand>>();

    //        var handler = new AddNewBeerHandler(breweryServiceMock.Object, validatorMock.Object);
    //        var command = new AddNewBeerCommand { BreweryId = 1, NewBeerDto = new BeerDto { Name = "BeerName", Type = "BeerType", Price = 5.99m } };

    //        // Act
    //        await handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        breweryServiceMock.Verify(service => service.AddNewBeerAsync(It.IsAny<int>(), It.IsAny<BeerDto>()), Times.Once);
    //    }

    //    [Fact]
    //    public async Task Handle_InvalidInput_ThrowsValidationException()
    //    {
    //        // Arrange
    //        var breweryServiceMock = new Mock<IBreweryService>();
    //        var validatorMock = new Mock<IValidator<AddNewBeerCommand>>();
    //        validatorMock.Setup(validator => validator.ValidateAsync(It.IsAny<AddNewBeerCommand>(), CancellationToken.None))
    //            .ReturnsAsync(new ValidationResult(new[] { new ValidationFailure("Name", "Beer name cannot be empty.") }));

    //        var handler = new AddNewBeerHandler(breweryServiceMock.Object, validatorMock.Object);
    //        var command = new AddNewBeerCommand { BreweryId = 1, NewBeerDto = new BeerDto() }; // Invalid input

    //        // Act & Assert
    //        await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));
    //    }
    //}

    //public class DeleteBeerCommandTests
    //{
    //    [Fact]
    //    public async Task Handle_ValidInput_DeletesBeer()
    //    {
    //        // Arrange
    //        var breweryServiceMock = new Mock<IBreweryService>();
    //        var handler = new DeleteBeerHandler(breweryServiceMock.Object);
    //        var command = new DeleteBeerCommand { BeerId = 1 };

    //        // Act
    //        await handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        breweryServiceMock.Verify(service => service.DeleteBeerAsync(It.IsAny<int>()), Times.Once);
    //    }

    //    [Fact]
    //    public async Task Handle_InvalidInput_ThrowsValidationException()
    //    {
    //        // Arrange
    //        var breweryServiceMock = new Mock<IBreweryService>();
    //        var validatorMock = new Mock<IValidator<DeleteBeerCommand>>();
    //        validatorMock.Setup(validator => validator.ValidateAsync(It.IsAny<DeleteBeerCommand>(), CancellationToken.None))
    //            .ReturnsAsync(new ValidationResult(new[] { new ValidationFailure("BeerId", "Beer ID must be greater than 0.") }));

    //        var handler = new DeleteBeerHandler(breweryServiceMock.Object, validatorMock.Object);
    //        var command = new DeleteBeerCommand { BeerId = 0 }; // Invalid input

    //        // Act & Assert
    //        await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));
    //    }
    //}
}
