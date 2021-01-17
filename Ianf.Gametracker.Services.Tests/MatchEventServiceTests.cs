#nullable disable
using System;
using System.Linq;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Ianf.Gametracker.Services;
using Ianf.Gametracker.Services.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;
using System.Collections.Generic;
using Ianf.Gametracker.Services.Domain;
using Ianf.Gametracker.Services.Errors;

namespace Ianf.Gametracker.UnitTest.Services
{
    public class MatchEventServiceTests
    {
        private readonly Mock<IMatchEventRepository> _matchEventRepository;
        private readonly IMatchEventService _matchEventService;

        private readonly int userId = 1234;
        private DateTime eventTime = DateTime.Now;
        private readonly MatchEventType matchEventType = MatchEventType.Conversion;

        public Gametracker.Services.Dto.MatchEvent GetSampleMatchEvent() =>
            new Gametracker.Services.Dto.MatchEvent() 
            {
                UserId = userId,
                EventTime = eventTime,
                MatchEventType = matchEventType
            };

        public MatchEventServiceTests()
        {
            _matchEventRepository = new Mock<IMatchEventRepository>();
            _matchEventService = new MatchEventService(_matchEventRepository.Object);
        }

        [Fact]
        public async void TestLoginWithValidUserid() 
        {
            // Assemble
            var userId = 42;

            // Act
            var result = await _matchEventService.LoginWithUserId(userId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void TestLoginWithInvalidUserid() 
        {
            // Assemble
            var userId = -42;

            // Act
            var result = await _matchEventService.LoginWithUserId(userId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void TestAddNewMatchEventAsyncSuccess()
        {
            // Assemble
            var newMatchEvent = GetSampleMatchEvent();
            Either<IEnumerable<Error>, int> returnValue = Right(1);
            _matchEventRepository
                .Setup(w => w.AddNewMatchEventAsync(It.IsAny<Gametracker.Services.Domain.MatchEvent>()))
                .Returns(Task.FromResult(returnValue));

            // Act
            var result = await _matchEventService.AddNewMatchEventAsync(newMatchEvent);

            // Assert
            _matchEventRepository.Verify(w => w.AddNewMatchEventAsync(It.IsAny<Gametracker.Services.Domain.MatchEvent>()));
            result.Match(
                Left: (err) => Assert.False(true, "Expected no errors to be returned."),
                Right: (newId) => Assert.Equal(1, newId)
            );
        }

        [Fact]
        public async void TestAddNewMatchEventAsyncUserIdInvalid()
        {
            // Assemble
            var newMatchEvent = GetSampleMatchEvent();
            newMatchEvent.UserId = -42;

            // Act
            var result = await _matchEventService.AddNewMatchEventAsync(newMatchEvent);

            // Assert
            result.Match(
                Left: (err) => {
                    var dtoError = (DtoValidationError)err.First();
                    Assert.Equal("MatchEvent", dtoError.DtoType);
                    Assert.Equal("UserId", dtoError.DtoProperty);
                },
                Right: (newId) => Assert.False(true, "Expected error.")
            );
        }

        [Fact]
        public async void TestAddNewMatchEventAsyncSqlError()
        {
            // Assemble
            var newMatchEvent = GetSampleMatchEvent();
            var errorMessage = "Sql Connection Exception";
            List<Error> errors = new List<Error> { new SqlError(errorMessage) };
            Either<IEnumerable<Error>, int> returnValue = errors;
            _matchEventRepository
                .Setup(w => w.AddNewMatchEventAsync(It.IsAny<Gametracker.Services.Domain.MatchEvent>()))
                .Returns(Task.FromResult(returnValue));

            // Act
            var result = await _matchEventService.AddNewMatchEventAsync(newMatchEvent);

            // Assert
            result.Match(
                Left: (err) => {
                    var sqlError = (SqlError)err.First();
                    Assert.Equal(errorMessage, sqlError.ErrorMessage);
                },
                Right: (newId) => Assert.False(true, "Expected error.")
            );
        }  
    }
}