using System;
using Xunit;
using Moq;
using FluentAssertions;
using ToySimulator.Models;

namespace ToySimulator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void Robot_Instantiation_Initializes_The_CurrentPosition_Ojbect() 
        {
            var mock = Mock.Of<Robot>();
            Assert.NotNull(mock.CurrentPosition);
        }

        [Fact]
        public void Robot_Place_Sets_The_CurrentPositions_Properties()
        {            
            var mockPosition = new Mock<IPosition>();

            mockPosition.SetupProperty(a => a.X);
            mockPosition.SetupProperty(a => a.Y);
            mockPosition.SetupProperty(a => a.Facing);

            //mock.Setup(x => x.Place(It.IsAny<Position>())).Returns(true);
            var mockPositionObject = mockPosition.Object;
            mockPositionObject.X = 2;
            mockPositionObject.Y = 1;
            mockPositionObject.Facing = Facing.WEST;
            var robot = new Robot();
            robot.Place(mockPositionObject);

            robot.CurrentPosition.X.Should().Be(2);
            robot.CurrentPosition.Y.Should().Be(1);
            robot.CurrentPosition.Facing.Should().Be(Facing.WEST);            
        }

        
        [Theory]
        [InlineData(0,0)]
        [InlineData(-1 , 1)]
        [InlineData(1, -1)]
        [InlineData(5, 5)]
        [InlineData(6, 1)]
        [InlineData(1, 6)]
        public void Robot_Place_Should_Return_False_If_Any_Of_Position_Coordinates_Are_Less_Than_Zero_Or_Greater_Than_Five(int x, int y)
        {
            var mockPosition = new Mock<IPosition>();

            mockPosition.SetupProperty(a => a.X);
            mockPosition.SetupProperty(a => a.Y);
            mockPosition.SetupProperty(a => a.Facing);

            //mock.Setup(x => x.Place(It.IsAny<Position>())).Returns(true);
            var mockPositionObject = mockPosition.Object;
            mockPositionObject.X = x;
            mockPositionObject.Y = y;
            mockPositionObject.Facing = Facing.WEST;
            var robot = new Robot();
            var result = robot.Place(mockPositionObject);

            if ((x == 5 && y == 5) || (x == 0 && y == 0))
            {
                //as per theory data above
                result.Should().BeTrue();
                robot.CurrentPosition.X.Should().Be(x);
                robot.CurrentPosition.Y.Should().Be(y);                
            }
            else
            {
                result.Should().BeFalse();
                robot.CurrentPosition.X.Should().Be(0);
                robot.CurrentPosition.Y.Should().Be(0);
                robot.CurrentPosition.Facing.Should().Be(Facing.NOTSET);
            }            
        }

        [Theory]
        [InlineData(Facing.NORTH)]
        [InlineData(Facing.SOUTH)]
        [InlineData(Facing.EAST)]
        [InlineData(Facing.WEST)]
        [InlineData(Facing.NOTSET)]        
        public void Robot_Place_Should_Return_False_If_Position_Facing_Is_NOTSET_Otherwise_True(Facing facing)
        {
            var mockPosition = new Mock<IPosition>();

            mockPosition.SetupProperty(a => a.X);
            mockPosition.SetupProperty(a => a.Y);
            mockPosition.SetupProperty(a => a.Facing);

            var mockPositionObject = mockPosition.Object;
            mockPositionObject.X = 1;
            mockPositionObject.Y = 1;
            mockPositionObject.Facing = facing;
            var robot = new Robot();
            var result = robot.Place(mockPositionObject);

            if (facing == Facing.NOTSET)
            {
                //as per theory data above
                result.Should().BeFalse();
                robot.CurrentPosition.Facing.Should().Be(Facing.NOTSET);
            }
            else
            {
                result.Should().BeTrue();
                robot.CurrentPosition.Facing.Should().Be(facing);
            }
        }

        [Fact]
        public void Move_Function_Will_Access_CurrentPostion_Object_And_Its_Facing_Property()
        {            
            var mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.Facing).Returns(Facing.NORTH);
            mockPosition.SetupProperty(a => a.X);
            mockPosition.SetupProperty(a => a.Y);

            mockPosition.Object.X = mockPosition.Object.Y = 0;

            var mockRobot = new Robot();
            mockRobot.Place(mockPosition.Object);
            var result = mockRobot.Move();

            mockPosition.VerifyGet(x => x.Facing);
            mockPosition.VerifyGet(a => a.Y);            
        }

        [Fact]
        public void Left_Function_Will_Access_CurrentPostion_Object_And_Its_Facing_Property()
        {
            var mockPosition = new Mock<IPosition>();
            
            mockPosition.SetupAllProperties();
            mockPosition.Object.Facing = Facing.NORTH;
            var mockRobot = new Robot();
            mockRobot.Place(mockPosition.Object);
            var result = mockRobot.Left();

            mockPosition.VerifyGet(x => x.Facing);
            mockPosition.Verify();
        }

        [Theory]
        [InlineData(Facing.NOTSET)]
        [InlineData(Facing.NORTH)]
        [InlineData(Facing.EAST)]
        [InlineData(Facing.SOUTH)]
        [InlineData(Facing.WEST)]
        public void Left_Function_Will_Set_CurrentPostion_Object_And_Its_Facing_Property(Facing facing)
        {
            var mockRobot = Mock.Of<Robot>();
            mockRobot.Place(new Position() { X = 0, Y = 0, Facing = facing });
            mockRobot.Left();
            mockRobot.CurrentPosition.Should().NotBeNull();
            switch (facing)
            {
                case Facing.NORTH:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.WEST);
                    break;
                case Facing.WEST:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.SOUTH);
                    break;
                case Facing.SOUTH:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.EAST);
                    break;
                case Facing.EAST:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.NORTH);
                    break;
                case Facing.NOTSET:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.NOTSET);
                    break;
            }
        }

        [Theory]
        [InlineData(Facing.NOTSET)]
        [InlineData(Facing.NORTH)]
        [InlineData(Facing.EAST)]
        [InlineData(Facing.SOUTH)]
        [InlineData(Facing.WEST)]
        public void Right_Function_Will_Set_CurrentPostion_Object_And_Its_Facing_Property(Facing facing)
        {
            var mockRobot = Mock.Of<Robot>();
            mockRobot.Place(new Position() { X = 0, Y = 0, Facing = facing });
            mockRobot.Right();
            mockRobot.CurrentPosition.Should().NotBeNull();
            switch (facing)
            {
                case Facing.NORTH:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.EAST);
                    break;
                case Facing.EAST:                
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.SOUTH);
                    break;
                case Facing.SOUTH:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.WEST);
                    break;
                case Facing.WEST:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.NORTH);
                    break;
                case Facing.NOTSET:
                    mockRobot.CurrentPosition.Facing.Should().Be(Facing.NOTSET);
                    break;
            }            
        }
    }
}
