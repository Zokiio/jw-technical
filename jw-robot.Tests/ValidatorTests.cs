using System.Collections.ObjectModel;
using FluentAssertions;
using Xunit;

namespace jw_robot.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("ffr", new Instructions[] {Instructions.F, Instructions.F, Instructions.R})]
        [InlineData("FFL", new Instructions[] {Instructions.F, Instructions.F, Instructions.L})]
        [InlineData(" lFF ", new Instructions[] {Instructions.L, Instructions.F, Instructions.F})]
        [InlineData("F F L", new Instructions[] {Instructions.F, Instructions.F, Instructions.L})]
        public void ValidateInstructions_ShouldReturnTrue(string userInput, Instructions[] expected)
        {
            // Arrange
            Instructions[] instructions;
            // Act
            var result = Validators.ValidateInstructions(userInput, out instructions);
            // Assert
            result.Should().BeTrue();
            instructions.Should().ContainInOrder(expected);
        }
        
        [Theory]
        [InlineData("sf fr")]
        [InlineData("F t L")]
        [InlineData(" ! . L ")]
        public void ValidateInstructions_ShouldReturnFalse(string userInput)
        {
            // Arrange
            Instructions[] instructions;
            // Act
            var result = Validators.ValidateInstructions(userInput, out instructions);
            // Assert
            result.Should().BeFalse();
            instructions.Should().BeNull();
        }

        [Theory]
        [InlineData("1 2 N")]
        [InlineData("13 22 N")]
        public void ValidateStartPosition_GivenValidInput_ShouldReturnTrue(string userInput)
        {
            // Arrange
            var position = new Position();
            var field = new Field(13, 22);
            // Act
            var result = Validators.ValidateInputStartPosition(userInput, position, field);
            // Assert
            result.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("N1 2 N")]
        [InlineData("N 2 N")]
        [InlineData("1 N 1")]
        [InlineData(" ! 2 N ")]
        public void ValidateStartPosition_GivenInvalidInput_ShouldReturnFalse(string userInput)
        {
            // Arrange
            // var expect = new Position(3, 3);
            var position = new Position();
            var field = new Field(3, 3);
            // Act
            var result = Validators.ValidateInputStartPosition(userInput, position, field);
            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateFieldSize_GivenValidInput_ShouldReturnTrue()
        {
            // Arrange
            var expected = new int[]{1, 2};
            var input = "1 2";
            // Act
            var result = Validators.ValidateFieldSize(input, out var inputValue);
            // Assert
            result.Should().BeTrue();
            inputValue.Should().BeEquivalentTo(expected);
        }
    }
}