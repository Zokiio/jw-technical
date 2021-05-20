using FluentAssertions;
using Xunit;

namespace jw_robot.Tests
{
    public class RobotTests
    {
        [Fact]
        public void UpdatePosition_PositionShouldChange()
        {
            var robot = new Robot(new Position(1,1,Directions.N), new Field(3,3));
            var instructions = new Instructions[] {Instructions.F, Instructions.R, Instructions.F, Instructions.L, Instructions.F, Instructions.L, Instructions.F,Instructions.L, Instructions.F};
            // Arrange
            var expected = new Position(1, 2, Directions.S);
            // Act 
            var actual = robot.Move(instructions);
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void EmptyInstructionsArray_PositionShouldNotChange() {
            var robot = new Robot(new Position(1,1,Directions.N), new Field(3,3));
            var instructions = new Instructions[] {};
            // Arrange
            var expected = new Position(1, 1, Directions.N);
            // Act 
            var actual = robot.Move(instructions);
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}